function press() {
    var g;
    if ($('#max').html() != 0) {
        g = $('#max').html();
    }
    else {
        g = 1000000;
    }
    for (i = 0; i <= g; i++) {
        if ($("#" + i).prop("checked") == true) {
            var t = i;
        }

      
    }

    $('#content').load('/Basket/Del?Id=' + t);
    $('#content').load('/Basket/Basket', showNewContent)//Запрос к странице
    function showNewContent() {
        $('#content').show('normal');
    }
    $('#Kol').load('/Basket/Kol', showNewContent)//Запрос к странице
    function showNewContent() {
        $('#Kol').show('normal');
    }
}