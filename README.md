# WebBrowser


https://silveredgold.github.io/beta-protection/developers.html#build
https://github.com/silveredgold/beta-protection/releases/tag/v0.1.2
https://github.com/silveredgold/beta-censoring

https://github.com/Project-Railgun/BetterCensorship



            var requestContext = RequestContext.Configure().WithProxyServer("20.206.106.192", 8123).Create();


            Cef.UIThreadTaskFactory.StartNew(delegate
            {
                string errorMessage;

                if (!requestContext.CanSetPreference("proxy"))
                {
                    //Unable to set proxy, if you set proxy via command line args it cannot be modified.
                }

                requestContext.SetProxy("20.206.106.192", 8123, out errorMessage);
            });


            browser = new ChromiumWebBrowser(txtUrl.Text);
        //    browser.RequestContext = requestContext;

            gridContent.Children.Add(browser);
            browser.AddressChanged += Browser_AddressChanged;




            //teste();

        }
        async void teste()
        {
            //Create a new RequestContext that users a specific proxy server
            //By default an in memory cache is used
            var requestContext = RequestContext
                .Configure()
                .WithProxyServer("202.137.26.6")
                .Create();

            //Create a RequestContext with a proxy and cache path
            //Making sure that CachePath is equal to or a child of CefSettings.RootCachePath
            //See https://github.com/cefsharp/CefSharp/issues/3111#issuecomment-629713608 for more info on cache path
            //var requestContext = RequestContext
            //    .Configure()
            //    .WithProxyServer("127.0.0.1", 8080)
            //    .WithCachePath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache"))
            //    .Create();

            //Set the proxy at runtime, the RequestContext must be initialized
            Cef.UIThreadTaskFactory.StartNew(delegate
            {
                string errorMessage;

                if (!requestContext.CanSetPreference("proxy"))
                {
                    //Unable to set proxy, if you set proxy via command line args it cannot be modified.
                }

                requestContext.SetProxy("127.0.0.1", 8080, out errorMessage);
            });

        }
