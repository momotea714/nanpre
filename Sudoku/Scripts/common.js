$(function () {

    var preSelectTroutId = "0";
    var currentSelectTroutId = "0";
    var possibleInputTrout = true;

    //サーバとの接続オブジェクト作成
    var connection = $.hubConnection();

    //Hubのプロキシ・オブジェクトを作成
    var echo = connection.createHubProxy("myHub");

    //サーバから呼び出される関数を登録
    echo.on("inputNumber", function (id, number, ConnectionId) {
        $(id).text(number);
    });

    echo.on("joinNotify", function (connectionID) {
        $('#lblJoin').text(connectionID + "さんが参加しました");
    });


    //数独のマス選択時のイベントハンドラ
    $(".trout").on("click", function (e) {
        //選択しているマスのidを取得
        preSelectTroutId = currentSelectTroutId;
        currentSelectTroutId = "#" + $(e.currentTarget).attr("id");

        //前回選択したセルと今回選択しているセルが同じ場合は以降の処理を中断
        if (preSelectTroutId === currentSelectTroutId) return;

        //選択しているマスのクラスの値を取得
        var currentSelectTroutClasses = $(currentSelectTroutId).attr("class").split(" ");
        var currentSelectTroutRowClassName = "";
        var currentSelectTroutColumnClassName = "";
        var currentSelectTroutGroupClassName = "";

        //クラスの数を取得
        var length = currentSelectTroutClasses.length | 0;

        //現在選択しているセルのクラスの取得
        for (var i = 0; i < length; i = i + 1 | 0) {
            if (currentSelectTroutClasses[i].indexOf("rowClass") >= 0) {
                //現在選択しているセルの行クラス名を取得
                currentSelectTroutRowClassName = currentSelectTroutClasses[i];
            } else if (currentSelectTroutClasses[i].indexOf("columnClass") >= 0) {
                //現在選択しているセルの列クラス名を取得
                currentSelectTroutColumnClassName = currentSelectTroutClasses[i];
            } else if (currentSelectTroutClasses[i].indexOf("groupClass") >= 0) {
                //現在選択しているセルのグループクラス名を取得
                currentSelectTroutGroupClassName = currentSelectTroutClasses[i];
            }
        }

        //数独のマス全体に対して背景色を設定する
        $(".trout").each(function () {
            var classes = $(this).attr("class").split(" ");
            var hasSameClass = classes.some(function(value) {
                if (value === currentSelectTroutRowClassName ||
                    value === currentSelectTroutColumnClassName ||
                    value === currentSelectTroutGroupClassName) {
                    return true;
                }
                return false;
            });

            //選択しているセルと同じクラスを持っていれば背景色を変更する
            if (hasSameClass) {
                $(this).addClass("sameGroupCell");
            } else {
                $(this).removeClass("sameGroupCell");
            }
        });

        //選択しているセルの背景色を変更する
        $(preSelectTroutId).removeClass("cellClicked");
        $(currentSelectTroutId).removeClass("sameGroupCell");
        $(currentSelectTroutId).addClass("cellClicked");

        //取得したclass内にfixがあれば数字を変更できないように変更する
        if ($.inArray("fix", currentSelectTroutClasses) >= 0) {
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
