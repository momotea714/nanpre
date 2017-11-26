using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sudoku.Biz
{
    public static class Utility
    {
        public static void WriteLog(string txt) {
            //Shift JISで書き込む
            //書き込むファイルが既に存在している場合は、ファイルの末尾に追加する
            System.IO.StreamWriter sw = new System.IO.StreamWriter(
                 GetAppPath() + @"\log.txt",
                true,
                System.Text.Encoding.GetEncoding("shift_jis"));
            //TextBox1.Textの内容を書き込む
            sw.WriteLine(txt);
            //閉じる
            sw.Close();
        }

        public static string GetAppPath()
        {
            string path =
                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
            //URIを通常のパス形式に変換する
            Uri u = new Uri(path);
            path = u.LocalPath + Uri.UnescapeDataString(u.Fragment);
            return System.IO.Path.GetDirectoryName(path);
        }
    }
}