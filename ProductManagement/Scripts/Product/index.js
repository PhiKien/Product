var productController = function () {

    this.init = function () {
        //loadData();
        registerEvents();
    }

    var registerEvents = function () {
        $('body').on('click', '#home', function (e) {
            e.preventDefault();
            location.reload(true);
        });

        $('body').on('click', '#accessories', function (e) {
            e.preventDefault();
            var page = 1;
            var id = 1;
            findById(page, id);
        });

        $('body').on('click', '#desktop', function (e) {
            e.preventDefault();
            var page = 1;
            var id = 2;
            findById(page, id);
        });

        $('body').on('click', '#ip_phone', function (e) {
            e.preventDefault();
            var page = 1;
            var id = 3;
            findById(page, id);
        });

        $('body').on('click', '#laptop', function (e) {
            e.preventDefault();
            var page = 1;
            var id = 4;
            findById(page, id);
        });

        $('body').on('click', '#monitor', function (e) {
            e.preventDefault();
            var page = 1;
            var id = 5;
            findById(page, id);
        });

        $('body').on('click', '#server', function (e) {
            e.preventDefault();
            var page = 1;
            var id = 6;
            findById(page, id);
        });

        $('body').on('click', '#smartphone', function (e) {
            e.preventDefault();
            var page = 1;
            var id = 7;
            findById(page, id);
        });

        $('body').on('click', '#btnEdit', function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            window.location.href = "/Product/Edit/" + id;
        });
    }

    //function loadData() {

    //}

    function findById(page, id) {
        var html1 = '';
        var template = $('#dataProduct').html();
        $.ajax({
            url: '/Product/FindProductByCategoryID',
            data: {  
                page: page,
                id: id
            },
            type: 'GET',
            dataType: 'json',
            success: function (response) {
                $("#list_product").empty();
                console.log(response);
                $.each(response, function (i, item) {
                    html1 += Mustache.render(template, {
                        ID: item.ID,
                        Name: item.Name,
                        Description: item.Description,
                        NumberInStock: item.NumberInStock,
                        CategoryID: item.CategoryID
                    });
                });
                $('#lstProduct').html(html1);
            },
            error: function (err) {
                console.log('error');
            }
        });
    }
}