document.addEventListener('DOMContentLoaded', () => {
    const botaoAdicionar = document.getElementById('botaoAddComentario');
    const areaComentario = document.getElementById('comentarioNovo');

    const stars = document.querySelectorAll('#avaliacaoNova .fa-star');
    const notaSelecionadaInput = document.getElementById('notaSelecionada');
    const textarea = document.getElementById('comentarioAutoAltura');
    const formComentario = document.getElementById('comentarioNovo');
    const comentariosContainer = document.getElementById('comentariosContainer');

    // 🔹 variável de controle
    let comentarioEnviado = false;

    // 🔹 controle do botão "Adicionar Comentário"
    botaoAdicionar.addEventListener('click', () => {
        // se já foi enviado, mostra alerta e não abre o campo
        if (comentarioEnviado) {
            alert('Você já enviou um comentário. Só é permitido um por vez.');
            return;
        }

        areaComentario.classList.toggle('oculto');
        botaoAdicionar.textContent = areaComentario.classList.contains('oculto') ? 'Adicionar Comentário' : 'Cancelar';
    });

    // lógica das estrelas
    stars.forEach((star, index) => {
        star.addEventListener('click', () => {
            stars.forEach(s => s.classList.remove('checked'));
            for (let i = 0; i <= index; i++) stars[i].classList.add('checked');
            notaSelecionadaInput.value = index + 1;
        });
    });

    // textarea autoajustável
    textarea.addEventListener('input', function () {
        this.style.height = 'auto';
        this.style.height = this.scrollHeight + 'px';
    });
    textarea.dispatchEvent(new Event('input'));

    // envio do comentário
    formComentario.addEventListener('submit', function (e) {
        e.preventDefault();

        const nome = document.querySelector('.nomePerfil').textContent;
        const comentario = textarea.value.trim();
        const nota = parseInt(notaSelecionadaInput.value);
        const inputImagem = document.getElementById('fotoComentario');
        const imgSrc = inputImagem.files[0] ? URL.createObjectURL(inputImagem.files[0]) : '~/img/Comentarios/Reviews/ImagemVazia.png';

        const novoComentario = document.createElement('div');
        novoComentario.classList.add('comentarioNovo');
        novoComentario.innerHTML =
            `
        <div class="comentario">
            <div class="infoEscritas">
                <div class="perfil">
                    <img src="~/img/Comentarios/Perfis/exemploImgPerfil.jpg" alt="" class="imgPerfil">
                    <p class="nomePerfil">${nome}</p>
                </div>
                <div class="avaliacao">
                    ${[1, 2, 3, 4, 5].map(i => `<span class="fa fa-star ${i <= nota ? 'checked' : ''}"></span>`).join('')}
                </div>
                <div class="txtComentario">
                    <p class="paragrafoComentario">${comentario}</p>
                </div>
            </div>
            <div class="imgComentario">
                <img src="${imgSrc}" alt="" class="imgReviewComentario">
            </div>
        </div>
        <div class="containerBotaoDeletar">
            <button type="button" class="btnDeletarComentario">Deletar Comentário</button>
        </div>
        `;

        novoComentario.querySelector('.btnDeletarComentario').addEventListener('click', () => {
            novoComentario.remove();
            // 🔹 permite novo comentário após deletar
            comentarioEnviado = false;

            // 🔹 Reseta o estado da imagem de pré-visualização e do input de imagem
            document.getElementById('previewImagem').src = '~/img/Comentarios/Reviews/ImagemVazia.png';
            document.getElementById('fotoComentario').value = '';
        });

        comentariosContainer.prepend(novoComentario);

        // 🔹 marca que o usuário já enviou
        comentarioEnviado = true;

        formComentario.reset();
        notaSelecionadaInput.value = 0;
        document.getElementById('previewImagem').src = '~/img/Comentarios/Reviews/ImagemVazia.png';
        textarea.style.height = 'auto';
        stars.forEach(s => s.classList.remove('checked'));
        areaComentario.classList.add('oculto');
        botaoAdicionar.textContent = 'Adicionar Comentário';
    });
});

function previewImagem(input) {
    const preview = document.getElementById('previewImagem');

    if (input.files && input.files[0]) {
        const leitor = new FileReader();

        leitor.onload = function (e) {
            preview.src = e.target.result;
        }

        leitor.readAsDataURL(input.files[0]);
    } else {
        preview.src = '~/img/Comentarios/Reviews/ImagemVazia.png'; // caminho da imagem padrão
    }
}