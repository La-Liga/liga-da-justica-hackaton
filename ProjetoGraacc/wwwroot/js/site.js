// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ConvertStringToDate(stringDate) {
    var arrDataExclusao = stringDate.split('/');
    var stringFormatada = arrDataExclusao[2] + '-' + arrDataExclusao[1] + '-' + arrDataExclusao[0];
    return stringFormatada;
}