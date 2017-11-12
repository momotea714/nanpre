$(function () {

    var selectId = "0";
    var connection = $.hubConnection();
    var echo = connection.createHubProxy("myHub");

    echo.on("InputNumber", function (id, number) {
        $("#" + id).text(number);
    });

    //数独のマス選択時のイベントハンドラ
    $(".target_table td").on("click", function (e) {
        //選択しているマスのidを取得
        selectId = $(e.currentTarget).attr("id");

        //数独のマス全てに背景色と文字色をデフォルトに設定しなおす
        $(".trout").each(function (index, element) {
            $(element).css("color", "black");
            $(element).css("background-color", "");
        });

        //選択しているマスのみ背景色と文字色を選択色に変更する
        $("#" + selectId).css("color", "white");
        $("#" + selectId).css("background-color", "#2d89ef");
    });

    $(".sudokuNumber").on("click", function (e) {
        var btnText = $(e.currentTarget).text();
        echo.invoke("InputNumber", selectId, btnText, "nngo" + $("#RoomID").val());
    });

    connection.start(function () {
        echo.invoke("Join", "nngo" + $("#RoomID").val());
    });
});