function press() {
    var g;
    if ($('#max').html() != 0) {
        g = $('#max').html();
    }
    else {
        g = 1000000;
    }
    let metka = [];
    for (i = 0; i <= g; i++) {
        if ($("#" + i).prop("checked") == true) {
            metka[i] = i;
            var t = i;
        }

      
    }


    if (metka.length != 0)
    {
        for (i = 0; i <= g; i++)
        {
            if (metka[i] == i)
            {
         $('#content').load('/Basket/Del?Id=' + i);
            }
        }
    }
    else
    {
 $('#content').load('/Basket/Del?Id=' + t);
    }
    $('#Kol').load('/Basket/Kol', reset());
    $('#content').load('/Basket/Basket', reset());
    $('#max').load('/Basket/Max', reset());
}

function reset() {
    $('#Kol').load('/Basket/Kol');
    $('#content').load('/Basket/Basket');
    $('#max').load('/Basket/Max');
}