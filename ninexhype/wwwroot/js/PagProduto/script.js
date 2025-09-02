// Adicionar/Cancelar comentário
const botaoAdicionar = document.getElementById('botaoAddComentario');
const areaComentario = document.getElementById('formComentario');

botaoAdicionar.addEventListener('click', () => {
    areaComentario.classList.toggle('oculto');
    botaoAdicionar.textContent = areaComentario.classList.contains('oculto') ? 'Adicionar Comentário' : 'Cancelar';
});

// Avaliação do comentário novo
const stars = document.querySelectorAll('#avaliacaoNova .fa-star');
stars.forEach((star, index) => {
    star.addEventListener('click', () => {
        stars.forEach(s => s.classList.remove('checked'));
        for (let i = 0; i <= index; i++) stars[i].classList.add('checked');
        document.getElementById('notaSelecionada').value = index + 1;
    });
});

// Preview da imagem do comentário
function previewImagem(input) {
    const file = input.files[0];
    const preview = document.getElementById('previewImagem');
    if (file) {
        const reader = new FileReader();
        reader.onload = e => preview.src = e.target.result;
        reader.readAsDataURL(file);
    }
}

// Altura automática do textarea
const textarea = document.getElementById('comentarioAutoAltura');
textarea.addEventListener('input', function () {
    this.style.height = 'auto';
    this.style.height = this.scrollHeight + 'px';
});
textarea.dispatchEvent(new Event('input'));

// Adicionar comentário no container
const formComentario = document.getElementById('formComentario');
const comentariosContainer = document.getElementById('comentariosContainer');

formComentario.addEventListener('submit', function (e) {
    e.preventDefault();

    const nome = document.querySelector('.nomePerfil').textContent;
    const comentario = textarea.value;
    const nota = parseInt(document.getElementById('notaSelecionada').value);
    const inputImagem = document.getElementById('fotoComentario');
    let imgSrc = inputImagem.files[0] ? URL.createObjectURL(inputImagem.files[0]) : '/assets/PagProduto/Perfis/PerfilVazio.png';

    const novoComentario = document.createElement('div');
    novoComentario.classList.add('comentario');
    novoComentario.innerHTML = `
        <div class="infoEscritas">
            <div class="perfil">
                <img src="${imgSrc}" alt="" class="imgPerfil">
                <p class="nomePerfil">${nome}</p>
            </div>
            <div class="avaliacao">
                ${[1,2,3,4,5].map(i => `<span class="fa fa-star ${i <= nota ? 'checked' : ''}"></span>`).join('')}
            </div>
            <div class="txtComentario">
                <p class="paragrafoComentario">${comentario}</p>
            </div>
            <button class="btnDeletarComentario">Deletar Comentário</button>
        </div>
    `;

    comentariosContainer.prepend(novoComentario);

    // Botão deletar
    novoComentario.querySelector('.btnDeletarComentario').addEventListener('click', () => {
        novoComentario.remove();
    });

    // Resetar formulário
    formComentario.reset();
    document.getElementById('notaSelecionada').value = 0;
    document.getElementById('previewImagem').src = '../assets/PagProduto/Cometarios/ImagemVazia.png';
    textarea.style.height = 'auto';
    stars.forEach(s => s.classList.remove('checked'));
    areaComentario.classList.add('oculto');
    botaoAdicionar.textContent = 'Adicionar Comentário';
});
