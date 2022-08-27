#pragma checksum "C:\Users\Franklyn\Source\Repos\RealEstateApp\WebApp.RealEstateApp\Views\Home\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f4a1d8159ab7e86cdc2beabeb84b76937dc5525"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Dashboard), @"mvc.1.0.view", @"/Views/Home/Dashboard.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Franklyn\Source\Repos\RealEstateApp\WebApp.RealEstateApp\Views\_ViewImports.cshtml"
using WebApp.RealEstateApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Franklyn\Source\Repos\RealEstateApp\WebApp.RealEstateApp\Views\_ViewImports.cshtml"
using WebApp.RealEstateApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Franklyn\Source\Repos\RealEstateApp\WebApp.RealEstateApp\Views\Home\Dashboard.cshtml"
using RealEstateApp.Core.Application.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f4a1d8159ab7e86cdc2beabeb84b76937dc5525", @"/Views/Home/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72394fdb40496eb5af2efc2dca8f56d4e5e04cb7", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DashboardViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Franklyn\Source\Repos\RealEstateApp\WebApp.RealEstateApp\Views\Home\Dashboard.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<link href=""https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css"" rel=""stylesheet"">
<div class=""container bootstrap snippets bootdey"">
    <div class=""row"">

        <div class=""col-md-3 col-sm-6 col-xs-6"">
            <div class=""panel panel-info panel-colorful"">
                <div class=""panel-body text-center"">
                    <h3 class=""text-uppercase mar-btm text-sm"">Propiedades Registradas</h3>
                    <i class=""fa fa-home fa-5x""></i>
                    <hr>
                    <p class=""h1 text-thin"">");
#nullable restore
#line 18 "C:\Users\Franklyn\Source\Repos\RealEstateApp\WebApp.RealEstateApp\Views\Home\Dashboard.cshtml"
                                       Write(Model.PropertiesQuantity);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
        </div>

        <div class=""col-md-3 col-sm-6 col-xs-6"">
            <div class=""panel panel-dark panel-colorful"">
                <div class=""panel-body text-center"">
                    <h3 class=""text-uppercase mar-btm text-sm"">Agentes Activos</h3>
                    <i class=""fa fa-users fa-5x""></i>
                    <hr>
                    <p class=""h1 text-thin"">");
#nullable restore
#line 29 "C:\Users\Franklyn\Source\Repos\RealEstateApp\WebApp.RealEstateApp\Views\Home\Dashboard.cshtml"
                                       Write(Model.AgentActive);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
        </div>

        <div class=""col-md-3 col-sm-6 col-xs-6"">
            <div class=""panel panel-danger panel-colorful"">
                <div class=""panel-body text-center"">
                    <h3 class=""text-uppercase mar-btm text-sm"">Agentes Inactivos</h3>
                    <i class=""fa fa-user-times fa-5x""></i>
                    <hr>
                    <p class=""h1 text-thin"">");
#nullable restore
#line 40 "C:\Users\Franklyn\Source\Repos\RealEstateApp\WebApp.RealEstateApp\Views\Home\Dashboard.cshtml"
                                       Write(Model.AgentDisabled);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
        </div>



        <div class=""col-md-3 col-sm-6 col-xs-6"">
            <div class=""panel panel-primary panel-colorful"">
                <div class=""panel-body text-center"">
                    <h3 class=""text-uppercase mar-btm text-sm"">Clientes Activos</h3>
                    <i class=""fa fa-users fa-5x""></i>
                    <hr>
                    <p class=""h1 text-thin"">");
#nullable restore
#line 53 "C:\Users\Franklyn\Source\Repos\RealEstateApp\WebApp.RealEstateApp\Views\Home\Dashboard.cshtml"
                                       Write(Model.ClientActive);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
        </div>


        <div class=""col-md-3 col-sm-6 col-xs-6"">
            <div class=""panel panel-danger panel-colorful"">
                <div class=""panel-body text-center"">
                    <h3 class=""text-uppercase mar-btm text-sm"">Clientes Inactivos</h3>
                    <i class=""fa fa-user-times fa-5x""></i>
                    <hr>
                    <p class=""h1 text-thin"">");
#nullable restore
#line 65 "C:\Users\Franklyn\Source\Repos\RealEstateApp\WebApp.RealEstateApp\Views\Home\Dashboard.cshtml"
                                       Write(Model.ClientDisabled);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
        </div>

        <div class=""col-md-3 col-sm-6 col-xs-6"">
            <div class=""panel panel-purple panel-colorful"">
                <div class=""panel-body text-center"">
                    <h3 class=""text-uppercase mar-btm text-sm"">Desarroladores Activos</h3>
                    <i class=""fa fa-users fa-5x""></i>
                    <hr>
                    <p class=""h1 text-thin"">");
#nullable restore
#line 76 "C:\Users\Franklyn\Source\Repos\RealEstateApp\WebApp.RealEstateApp\Views\Home\Dashboard.cshtml"
                                       Write(Model.DeveloperActive);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                </div>
            </div>
        </div>

        <div class=""col-md-3 col-sm-6 col-xs-6"">
            <div class=""panel panel-danger panel-colorful"">
                <div class=""panel-body text-center"">
                    <p class=""text-uppercase mar-btm text-sm"">Desarroladores Inactivos</p>
                    <i class=""fa fa-user-times fa-5x""></i>
                    <hr>
                    <p class=""h1 text-thin"">");
#nullable restore
#line 87 "C:\Users\Franklyn\Source\Repos\RealEstateApp\WebApp.RealEstateApp\Views\Home\Dashboard.cshtml"
                                       Write(Model.DeveloperDisabled);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DashboardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
