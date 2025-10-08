using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ninexhype.Models;
using System.Threading.Tasks;

namespace ninexhype.Controllers
{
    [Authorize] // garante que só usuários logados acessem
    public class PerfilController : Controller
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;

        public PerfilController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Perfil
        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(User);
            if (usuario == null) return RedirectToAction("Login", "Account");

            return View(usuario);
        }

        // GET: /Perfil/Editar
        public async Task<IActionResult> Editar()
        {
            var usuario = await _userManager.GetUserAsync(User);
            return View(usuario);
        }

        // POST: /Perfil/Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Usuario model)
        {
            var usuario = await _userManager.GetUserAsync(User);
            if (usuario == null) return RedirectToAction("Login", "Account");

            usuario.Nome = model.Nome;
            usuario.Email = model.Email;
            usuario.UserName = model.Email;

            var result = await _userManager.UpdateAsync(usuario);

            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(usuario);
                TempData["Sucesso"] = "Perfil atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            foreach (var erro in result.Errors)
                ModelState.AddModelError("", erro.Description);

            return View(model);
        }

        // GET: /Perfil/AlterarSenha
        public IActionResult AlterarSenha() => View();

        // POST: /Perfil/AlterarSenha
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AlterarSenha(string senhaAtual, string novaSenha)
        {
            var usuario = await _userManager.GetUserAsync(User);
            if (usuario == null) return RedirectToAction("Login", "Account");

            var result = await _userManager.ChangePasswordAsync(usuario, senhaAtual, novaSenha);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(usuario);
                TempData["Sucesso"] = "Senha alterada com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            foreach (var erro in result.Errors)
                ModelState.AddModelError("", erro.Description);

            return View();
        }
    }
}
