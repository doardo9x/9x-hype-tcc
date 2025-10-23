document.addEventListener('DOMContentLoaded', () => {
    const botaoAdicionar = document.getElementById('botaoAddComentario');
    const areaComentario = document.getElementById('comentarioNovo');

    botaoAdicionar.addEventListener('click', () => {
        areaComentario.classList.toggle('oculto');
        botaoAdicionar.textContent = areaComentario.classList.contains('oculto') ? 'Adicionar Comentário' : 'Cancelar';
    });

    const stars = document.querySelectorAll('#avaliacaoNova .fa-star');
    const notaSelecionadaInput = document.getElementById('notaSelecionada');

    stars.forEach((star, index) => {
        star.addEventListener('click', () => {
            stars.forEach(s => s.classList.remove('checked'));
            for (let i = 0; i <= index; i++) stars[i].classList.add('checked');
            notaSelecionadaInput.value = index + 1;
        });
    });

    const textarea = document.getElementById('comentarioAutoAltura');
    textarea.addEventListener('input', function () {
        this.style.height = 'auto';
        this.style.height = this.scrollHeight + 'px';
    });
    textarea.dispatchEvent(new Event('input'));

    const formComentario = document.getElementById('comentarioNovo');
    const comentariosContainer = document.getElementById('comentariosContainer');

    formComentario.addEventListener('submit', function (e) {
        e.preventDefault();

        const nome = document.querySelector('.nomePerfil').textContent;
        const comentario = textarea.value.trim();
        const nota = parseInt(notaSelecionadaInput.value);
        const inputImagem = document.getElementById('fotoComentario');
        const imgSrc = inputImagem.files[0] ? URL.createObjectURL(inputImagem.files[0]) : '/assets/PagProduto/Perfis/PerfilVazio.png';

        const novoComentario = document.createElement('div');
        novoComentario.classList.add('comentario');
        novoComentario.innerHTML = `
                <div class="infoEscritas">
                    <div class="perfil">
                        <img src="/assets/PagProduto/Perfis/exemploImgPerfil2.jpg" alt="" class="imgPerfil">
                        <p class="nomePerfil">${nome}</p>
                    </div>
                    <div class="avaliacao">
                        ${[1,2,3,4,5].map(i => `<span class="fa fa-star ${i <= nota ? 'checked' : ''}"></span>`).join('')}
                    </div>
                    <div class="txtComentario">
                        <p class="paragrafoComentario">${comentario}</p>
                    </div>
                </div>
                <div class="imgComentario">
                    <img src="${imgSrc}" alt="" class="imgReviewComentario">
                </div>
                <button type="button" class="btnDeletarComentario">Deletar Comentário</button>
        `;

        novoComentario.querySelector('.btnDeletarComentario').addEventListener('click', () => {
            novoComentario.remove();
        });

        comentariosContainer.prepend(novoComentario);

        formComentario.reset();
        notaSelecionadaInput.value = 0;
        document.getElementById('previewImagem').src = '../assets/PagProduto/Cometarios/ImagemVazia.png';
        textarea.style.height = 'auto';
        stars.forEach(s => s.classList.remove('checked'));
        areaComentario.classList.add('oculto');
        botaoAdicionar.textContent = 'Adicionar Comentário';
    });
});
    