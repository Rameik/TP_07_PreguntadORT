// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const toggleBtn = document.querySelector('.toggle_btn');
const toggleBtnIcon = document.querySelector('.toggle_btn i');
const dropDownMenu = document.querySelector('.menu-desplegado');

toggleBtn.onclick = function(){
    dropDownMenu.classList.toggle('open');
    const isOpen = dropDownMenu.classList.contains('open');


    toggleBtnIcon.classList = isOpen
        ? 'fa-solid fa-xmark'
        : 'fa-solid fa-bars';
}

