#pragma checksum "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae875a8dcaaa0edef6901ed59cffc95d90fcdb39"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RAgent_Index), @"mvc.1.0.view", @"/Views/RAgent/Index.cshtml")]
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
#line 1 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\_ViewImports.cshtml"
using WebApp.RealEstateApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\_ViewImports.cshtml"
using WebApp.RealEstateApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae875a8dcaaa0edef6901ed59cffc95d90fcdb39", @"/Views/RAgent/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72394fdb40496eb5af2efc2dca8f56d4e5e04cb7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_RAgent_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("w-100 text-decoration-none text-dark mb-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration:none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col d-flex"">
        <div class=""col-6 mt-1"">
            <h5 class=""fs-5""> Ultimas Propiedades Añadidas <i class=""fa-solid fa-clock""></i></h5>
        </div>              
    </div>
    <hr class=""m-3""/>
    <div class=""col-4"">
");
#nullable restore
#line 12 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
         foreach (var item in ViewBag.Properties)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-4 \">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae875a8dcaaa0edef6901ed59cffc95d90fcdb395811", async() => {
                WriteLiteral("\r\n                <div class=\"card\" style=\"width: 16rem;\">\r\n");
#nullable restore
#line 17 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                      
                        Random random = new Random();

                        int photo = random.Next(0, (item.UrlPhotos.Count - 1));
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <img");
                BeginWriteAttribute("src", " src=\"", 841, "\"", 877, 1);
#nullable restore
#line 22 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
WriteAttributeValue("", 847, item.UrlPhotos[photo].ImagUrl, 847, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"card-img-top\" alt=\"Imagen Terreno\">\r\n                    <div class=\"card-body\">\r\n                        <div class=\"d-flex\">\r\n                            <small class=\"card-title fw-bolder fs-5\">\r\n                                ");
#nullable restore
#line 26 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                           Write(item.TypeProperty.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </small>\r\n                        </div>\r\n                        <small class=\"text-center text-capitalize fw-bolder text-muted mb-2 \">");
#nullable restore
#line 29 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                                                                                         Write(item.Location);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</small>
                        <br />
                        <small class=""card-subtitle text-dark fs-6"">
                            Codigo
                        </small>
                        <br />
                        <small class=""text-center text-capitalize fw-bolder  "">");
#nullable restore
#line 35 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                                                                          Write(item.Code);

#line default
#line hidden
#nullable disable
                WriteLiteral("</small>\r\n                        <br />\r\n                        <small class=\"card-subtitle text-dark fs-6\">\r\n                            ");
#nullable restore
#line 38 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                       Write(item.TypeSale.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </small>\r\n                        <br />\r\n                        <small class=\"text-center text-capitalize fw-bolder text-danger \">RD$ ");
#nullable restore
#line 41 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                                                                                         Write(item.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("  - US$ ");
#nullable restore
#line 41 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                                                                                                             Write(item.Price / 54 );

#line default
#line hidden
#nullable disable
                WriteLiteral(" </small>\r\n                        <br />\r\n                        <hr clas />\r\n                        <small class=\"fs-6 d-flex justify-content-evenly\">\r\n\r\n");
#nullable restore
#line 46 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                             if (item.Bathroom != 0)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div class=\"me-2\"><i class=\"fa-solid fa-hot-tub-person\"></i> ");
#nullable restore
#line 48 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                                                                                        Write(item.Bathroom);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 49 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 51 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                             if (item.Room != 0)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div class=\"me-2\"><i class=\"fa-solid fa-bed\"></i> ");
#nullable restore
#line 53 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                                                                             Write(item.Room);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 54 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"me-2\"><i class=\"fa-solid fa-building\"></i> ");
#nullable restore
#line 55 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                                                                               Write(item.Meters);

#line default
#line hidden
#nullable disable
                WriteLiteral("mt</div>\r\n                        </small>                                           \r\n                    </div>\r\n                </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
                                                            WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("            \r\n        </div>\r\n");
#nullable restore
#line 61 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 3\RealEstateApp\WebApp.RealEstateApp\Views\RAgent\Index.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
