﻿using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;


[assembly: OwinStartup(typeof(Sudoku.Startup))]

namespace Sudoku
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // アプリケーションの構成方法の詳細については、https://go.microsoft.com/fwlink/?LinkID=316888 を参照してください
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
}
