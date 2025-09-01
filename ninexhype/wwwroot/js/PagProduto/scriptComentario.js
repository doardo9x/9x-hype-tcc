// Add ou Cancelar Comentário Novo
const botaoAdicionar = document.getElementById('botaoAddComentario');
const areaComentario = document.getElementById('comentarioNovo');

botaoAdicionar.addEventListener('click', () => {
    areaComentario.classList.toggle('oculto');
    botaoAdicionar.textContent = areaComentario.classList.contains('oculto')
        ? 'Adicionar'
        : 'Cancelar';
});


// Avaliação do Comentário Novo
const stars = document.querySelectorAll('#avaliacaoNova .fa-star');

stars.forEach((star, index) => {
    star.addEventListener('click', () => {
        // Remove a classe "checked" de todas as estrelas dentro de #avaliacaoNova
        stars.forEach(s => s.classList.remove('checked'));

        // Adiciona a classe "checked" até a estrela clicada
        for (let i = 0; i <= index; i++) {
            stars[i].classList.add('checked');
        }

        // Você pode pegar a nota aqui:
        const nota = index + 1;
        console.log('Nota selecionada:', nota);
    });
});


// Preview da imagem Comentário Novo
function previewImagem(input) {
    const file = input.files[0];
    const preview = document.getElementById('previewImagem');
    if (file) {
        const reader = new FileReader();
        reader.onload = e => {
            preview.src = e.target.result;
        };
        reader.readAsDataURL(file);
    }
}

// Altura do Textarea do Comentário Novo
const textarea = document.getElementById('comentarioAutoAltura');

textarea.addEventListener('input', function () {
    this.style.height = 'auto'; // resetar altura
    this.style.height = this.scrollHeight + 'px'; // ajustar para altura do conteúdo
});

// Dispara uma vez no carregamento (caso já tenha conteúdo)
textarea.dispatchEvent(new Event('input'));