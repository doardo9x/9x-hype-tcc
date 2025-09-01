var button = document.getElementById('btnDescCompleta');

button.addEventListener('click', function() {
    var descCompleta = document.querySelector('.descricaoCompleta');
    descCompleta.classList.toggle('active');

    if (descCompleta.classList.contains('active')) {
        return button.textContent = 'Mostar Menos';
    }else{
        return button.textContent = 'Descrição Completa'
    }
})