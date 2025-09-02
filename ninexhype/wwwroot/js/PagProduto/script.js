document.addEventListener("DOMContentLoaded", () => {
  const carouselList = document.querySelector('.carousel__list-Modal');
  const elems = Array.from(document.querySelectorAll('.carousel__item-Modal'));

  // inicializa posições (0 central, os outros 1 e -1)
  elems.forEach((elem, index) => {
      if(index === 0) elem.dataset.pos = 0;
      else if(index === 1) elem.dataset.pos = 1;
      else if(index === 2) elem.dataset.pos = -1;
  });

  carouselList.addEventListener('click', function (event) {
      const newActive = event.target.closest('.carousel__item-Modal');
      if (!newActive || newActive.classList.contains('carousel__item-Modal_active')) return;

      update(newActive);
  });

  const update = function (newActive) {
      const newActivePos = parseInt(newActive.dataset.pos);

      const current = elems.find(elem => parseInt(elem.dataset.pos) === 0);
      const prev = elems.find(elem => parseInt(elem.dataset.pos) === -1);
      const next = elems.find(elem => parseInt(elem.dataset.pos) === 1);

      current.classList.remove('carousel__item-Modal_active');

      [current, prev, next].forEach(item => {
          if (!item) return;
          const pos = parseInt(item.dataset.pos);
          item.dataset.pos = getPos(pos, newActivePos);
      });

      newActive.classList.add("carousel__item-Modal_active");
  };

  const getPos = function(current, active) {
      const diff = current - active;
      if(diff === 0) return 0;
      if(diff === -1 || diff === 2) return -1;
      if(diff === 1 || diff === -2) return 1;
  };
});
