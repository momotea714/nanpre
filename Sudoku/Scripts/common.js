$(function () {

    var selectId = "0";
    var connection = $.hubConnection();
    var echo = connection.createHubProxy("myHub");
    
    echo.on("SelectTd", function (id) {
        $(".trout").each(function(index, element) {
            $(element).css("color", "black");
            $(element).css("background-color", "");
        });
        $("#" + id).css("color", "white");
        $("#" + id).css("background-color", "#2d89ef");
    });
    echo.on("InputNumber", function (id, number) {
        $("#" + id).text(number);
    });
    echo.on("NextQuestion", function () {
        location.reload();
    });


    $(".target_table td").on("click", function (e) {
        // currentTarget のidを取得
        selectId = $(e.currentTarget).attr("id");
        echo.invoke("SelectTd", selectId);
    });

    $(".sudokuNumber").on("click", function (e) {
        var btnText = $(e.currentTarget).text();
        echo.invoke("InputNumber", selectId, btnText,groupId);
    }); 

    $("#nextQuestion").on("click", function (e) {
        echo.invoke("NextQuestion");
    });

    connection.start(function () {
        echo.invoke("Join", "Room1");
    });
});