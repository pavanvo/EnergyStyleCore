// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function addCharClick() {
    let elem = document.getElementById('characteristics');
    let i = $(elem).children('div').length;
    let parent = document.createElement('div');

    let inputName = document.createElement('input');
    inputName.className = 'form-control';
    inputName.setAttribute('type', `text`);
    inputName.setAttribute('name', `Characteristics[${i}].Name`);
    inputName.setAttribute('placeholder', `Введите название`);
    inputName.style = 'margin-top:10px;margin-bottom:5px;';
    parent.appendChild(inputName);

    let inputValue = document.createElement('input');
    inputValue.className = 'form-control';
    inputValue.setAttribute('type', `text`);
    inputValue.setAttribute('name', `Characteristics[${i}].Value`);
    inputValue.setAttribute('placeholder', `Введите значение`);
    inputValue.style = 'margin-top:5px;margin-bottom:10px;';
    parent.appendChild(inputValue);
    elem.appendChild(parent);
}

function FileUploaded(xhr) {
    let path = `/images/${xhr.responseText}`;
    $('#imgSrc').attr('src', path).show();
    $('#imgPath').val(path);
};

function FilesUploaded(xhr) {
    for (var i = 0; i < xhr.responseJSON.length; i++) {

        let path = `/images/${xhr.responseJSON[i]}`;
        let img = document.createElement('img');
        img.src = path;
        $('#imgSrc').append(img);

        let imgPath = $('#imgPath');
        let count = imgPath.children('input').length;

        let input = document.createElement('input');
        input.className = 'form-control';
        input.setAttribute('type', `text`);
        input.setAttribute('name', `Images[${count}]`);
        input.value = path;
        imgPath.append(input);
    }
    refreshSlider();
}