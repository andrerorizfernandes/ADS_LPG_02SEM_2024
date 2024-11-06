const menuItems = document.querySelectorAll('.submenu li a');

menuItems.forEach(item => {
    item.addEventListener('mouseover', function () {
        this.classList.add('highlight'); // Adiciona a classe de destaque
    });

    item.addEventListener('mouseout', function () {
        this.classList.remove('highlight'); // Remove a classe de destaque
    });
});
