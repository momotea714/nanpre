$(function () {

    var preSelectTroutId = "0";
    var currentSelectTroutId = "0";
    var possibleInputTrout = true;

    //サーバとの接続オブジェクト作成
    var connection = $.hubConnection();

    //Hubのプロキシ・オブジェクトを作成
    var echo = connection.createHubProxy("myHub");

    //サーバから呼び出される関数を登録
    echo.on("inputNumber", function (id, number) {
        $(id).text(number);
    });

    //数独のマス選択時のイベントハンドラ
    $(".trout").on("click", function (e) {
        //選択しているマスのidを取得
        preSelectTroutId = currentSelectTroutId;
        currentSelectTroutId = "#" + $(e.currentTarget).attr("id");

        //前回選択していたマスの背景色と文字色をデフォルトに設定しなおす
        $(preSelectTroutId).removeClass('cellClicked');

        //選択しているマスの背景色と文字色を選択色に変更する
        $(currentSelectTroutId).addClass('cellClicked');

        //classの値を取得
        var classVal = $(currentSelectTroutId).attr('class');

        //取得したclassを分割
        var classValues = classVal.split(' ');

        //取得したclass内にfixがあれば数字を変更できないように変更する
        if ($.inArray("fix", classValues) >= 0) {
            possibleInputTrout = false;
        } else {
            possibleInputTrout = true;
        }
    });

    //ナンプレに入力する数字クリック時のイベントハンドラ
    $(".sudokuNumber").on("click", function (e) {
        //入力可能セル選択時にのみセルの値を書き換える
        if (possibleInputTrout) {
            var btnText = $(e.currentTarget).text();
            echo.invoke("InputNumber", currentSelectTroutId, btnText, "nngo" + $("#RoomID").val());
        }
    });

    //接続を開始
    connection.start(function () {
        //サーバのメソッドを呼び出し
        echo.invoke("Join", "nngo" + $("#RoomID").val());
    });

});
