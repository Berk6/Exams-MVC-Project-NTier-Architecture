$('textarea').each(function () {
}).on('input', function () {
    this.style.height = 'auto';
    this.style.height = (this.scrollHeight - 30) + 'px';
});