#pragma checksum "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad18243ffd52bcd005da1204101939871aaf9bda"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Agent_Details), @"mvc.1.0.view", @"/Views/Agent/Details.cshtml")]
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
#line 1 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\_ViewImports.cshtml"
using WebApp.RealEstateApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\_ViewImports.cshtml"
using WebApp.RealEstateApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
using RealEstateApp.Core.Application.ViewModels.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
using RealEstateApp.Core.Application.ViewModels.Property;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad18243ffd52bcd005da1204101939871aaf9bda", @"/Views/Agent/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72394fdb40496eb5af2efc2dca8f56d4e5e04cb7", @"/Views/_ViewImports.cshtml")]
    public class Views_Agent_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("w-100 text-decoration-none text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 4 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
  
    ViewData["Title"] = "Detalles del agente";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\" col col-12 form-control bg-light shadow mx-auto \">\r\n        <div class=\"card bg-transparent mb-3 border-0 m-3\">\r\n            <div class=\"row\">\r\n                <div class=\"col-md-4\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 434, "\"", 462, 1);
#nullable restore
#line 13 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
WriteAttributeValue("", 440, Model.PhotoProfileUrl, 440, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid rounded-start\" alt=\"PhotoProfile\">\r\n                </div>\r\n                <div class=\"col-md-8\">\r\n                    <div class=\"card-body\">\r\n                        <h4 class=\"card-title fs-3\">");
#nullable restore
#line 17 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                               Write(Model.Firstname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 17 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                                                Write(Model.Lastname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        <p class=\"text-body\">\r\n                            ");
#nullable restore
#line 19 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                       Write(Model.Firstname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 19 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                        Write(Model.Lastname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" es uno de nuestros agentes inmbiliarios, tiene un total de ");
#nullable restore
#line 19 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                                                                                                   Write(Model.Properties.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" propiedades de alto calibre a
                            su disposicion, si encuentra alguna que le guste puede comunicarse con el, mediante algunos de los siguientes metodos de comunicacion que le
                            ofrecemos.
                        </p>

                        <div class=""row"">
                            <div class=""col col-5 mt-1"">
                                <h5 class=""card-subtitle fs-6 fw-bolder text-start""> Numero de telefono</h5>
                            </div>
                            <div class=""col col-5"">
                                <p class=""fs-6"">");
#nullable restore
#line 29 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                           Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                            <div class=""col col-5 mt-1"">
                                <h5 class=""card-subtitle fs-6 fw-bolder"">Correo Eletronico </h5>
                            </div>
                            <div class=""col col-5"">
                                <p class=""fs-6""> ");
#nullable restore
#line 35 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                            Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                            <div class=""col col-5 mt-1"">
                                <h5 class=""card-subtitle fs-6 fw-bolder"">Total de propiedades </h5>
                            </div>
                            <div class=""col col-5"">
                                <p class=""fs-6"">");
#nullable restore
#line 41 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                           Write(Model.Properties.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                        </div>                    
                </div>
            </div>
        </div>
        <hr />
        <h5 class=""text-title m-4 ms-5"">Propiedades</h5>
        <div class=""row m-3"">
");
#nullable restore
#line 50 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
             foreach (PropertyViewModel item in Model.Properties)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col col-4\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad18243ffd52bcd005da1204101939871aaf9bda11100", async() => {
                WriteLiteral("\r\n                    <div class=\"card m-1\" style=\"width: 18rem;\">\r\n");
#nullable restore
#line 55 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                          
                            Random random = new Random();

                            int photo = random.Next(0, (item.UrlPhotos.Count - 1));
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <img");
                BeginWriteAttribute("src", " src=\"", 3105, "\"", 3141, 1);
#nullable restore
#line 60 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
WriteAttributeValue("", 3111, item.UrlPhotos[photo].ImagUrl, 3111, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"card-img-top\" alt=\"Imagen Terreno\">\r\n                        <div class=\"card-body\">\r\n                            <small class=\"card-title fw-bolder fs-5\">\r\n                                ");
#nullable restore
#line 63 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                           Write(item.TypeProperty.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </small>\r\n                            <br />\r\n                            <small class=\"text-center text-capitalize fw-bolder text-muted mb-2 \">");
#nullable restore
#line 66 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
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
#line 72 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                                                              Write(item.Code);

#line default
#line hidden
#nullable disable
                WriteLiteral("</small>\r\n                            <br />\r\n                            <small class=\"card-subtitle text-dark fs-6\">\r\n                                ");
#nullable restore
#line 75 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                           Write(item.TypeSale.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </small>\r\n                            <br />\r\n                            <small class=\"text-center text-capitalize fw-bolder text-danger \">RD$ ");
#nullable restore
#line 78 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                                                                             Write(item.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("  - US$ ");
#nullable restore
#line 78 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                                                                                                 Write(item.Price / 54 );

#line default
#line hidden
#nullable disable
                WriteLiteral(" </small>\r\n                            <br />\r\n                            <hr clas />\r\n                            <small class=\"fs-6 d-flex justify-content-evenly\">\r\n\r\n");
#nullable restore
#line 83 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                 if (item.Bathroom != 0)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <div class=\"me-2\"><i class=\"fa-solid fa-hot-tub-person\"></i> ");
#nullable restore
#line 85 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                                                                            Write(item.Bathroom);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 86 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 88 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                 if (item.Room != 0)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <div class=\"me-2\"><i class=\"fa-solid fa-bed\"></i> ");
#nullable restore
#line 90 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                                                                 Write(item.Room);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 91 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div class=\"me-2\"><i class=\"fa-solid fa-building\"></i> ");
#nullable restore
#line 92 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                                                                                   Write(item.Meters);

#line default
#line hidden
#nullable disable
                WriteLiteral("mt</div>\r\n                            </small>\r\n                        </div>\r\n                    </div>\r\n                ");
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
#line 53 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
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
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 98 "C:\Users\Franklyn\source\repos\Proyecto MVC .NET CORE\RealEstateApp\WebApp.RealEstateApp\Views\Agent\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserVM> Html { get; private set; }
    }
}
#pragma warning restore 1591