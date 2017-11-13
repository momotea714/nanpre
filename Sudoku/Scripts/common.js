$(function () {

    var preSelectTroutId = "0";
    var currentSelectTroutId = "0";

    //サーバとの接続オブジェクト作成
    var connection = $.hubConnection();

    //Hubのプロキシ・オブジェクトを作成
    var echo = connection.createHubProxy("myHub");

    //サーバから呼び出される関数を登録
    echo.on("InputNumber", function (id, number) {
        $("#" + id).text(number);
    });

    //数独のマス選択時のイベントハンドラ
    $(".target_table td").on("click", function (e) {
        //選択しているマスのidを取得
        preSelectTroutId = currentSelectTroutId;
        currentSelectTroutId = $(e.currentTarget).attr("id");

        //前回選択していたマスの背景色と文字色をデフォルトに設定しなおす
        $("#" + preSelectTroutId).addclcss({
            color: "black",
            'background-color': "",
        });

        //選択しているマスの背景色と文字色を選択色に変更する
        $("#" + currentSelectTroutId).css({
            color: "white",
            'background-color': "#2d89ef",
        });
    });

    $(".sudokuNumber").on("click", function (e) {
        var btnText = $(e.currentTarget).text();
        echo.invoke("InputNumber", currentSelectTroutId, btnText, "nngo" + $("#RoomID").val());
    });

    //接続を開始
    connection.start(function () {
        //サーバのメソッドを呼び出し
        echo.invoke("Join", "nngo" + $("#RoomID").val());
    });
});