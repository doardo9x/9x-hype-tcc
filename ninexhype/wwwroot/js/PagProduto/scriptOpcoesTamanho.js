document.addEventListener("DOMContentLoaded", () => {
    const menuItems = document.querySelectorAll('.btnOpcoesTamanho'); // ajuste se a classe for diferente
  
    if (menuItems.length > 0) {
      menuItems.forEach(item => {
        item.classList.remove('first-item', 'last-item'); // limpa classes antigas
      });
  
      menuItems[0].classList.add('first-item');
      menuItems[menuItems.length - 1].classList.add('last-item');
    }
  });