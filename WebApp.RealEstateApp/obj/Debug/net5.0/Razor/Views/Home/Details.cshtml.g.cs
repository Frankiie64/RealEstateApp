#pragma checksum "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e12b2f74940c10c069b339638b28c0382a4ed8f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Details), @"mvc.1.0.view", @"/Views/Home/Details.cshtml")]
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
#line 1 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\_ViewImports.cshtml"
using WebApp.RealEstateApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\_ViewImports.cshtml"
using WebApp.RealEstateApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
using RealEstateApp.Core.Application.ViewModels.Property;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e12b2f74940c10c069b339638b28c0382a4ed8f3", @"/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72394fdb40496eb5af2efc2dca8f56d4e5e04cb7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PropertyViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control bg-light shadow"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-decoration-none text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Agent", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
  
    ViewData["Title"] = "Detalles de la vivienda";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row mx-auto mt-1 p-2\">\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e12b2f74940c10c069b339638b28c0382a4ed8f35883", async() => {
                WriteLiteral("\r\n        <div class=\"col col-12 p-3\">\r\n");
                WriteLiteral("            <div class=\"card mb-3 bg-transparent border-0\" >\r\n                <div class=\"row g-0\">\r\n");
                WriteLiteral("                    <div class=\"col-md-4 border-2 my-auto  border-dark\">\r\n                        <div id=\"carouselExampleControls\" class=\"carousel slide\" data-bs-ride=\"carousel\">\r\n                            <div class=\"carousel-inner\">\r\n\r\n");
#nullable restore
#line 20 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                 if (Model.UrlPhotos.Count == 0)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <div class=\"carousel-item active\">\r\n                                        <img src=\"https://th.bing.com/th/id/OIP.1UFgwhEydHwcymjLxLa9iAHaFj?pid=ImgDet&rs=1\" class=\"d-block w-100\"");
                BeginWriteAttribute("alt", " alt=\"", 1021, "\"", 1042, 1);
#nullable restore
#line 23 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
WriteAttributeValue("", 1027, Model.Location, 1027, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                    </div>\r\n");
#nullable restore
#line 25 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                }
                                else
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                     foreach (var item in Model.UrlPhotos)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <div class=\"carousel-item active\">\r\n                                            <img");
                BeginWriteAttribute("src", " src=\"", 1437, "\"", 1456, 1);
#nullable restore
#line 31 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
WriteAttributeValue("", 1443, item.ImagUrl, 1443, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"d-block w-100\"");
                BeginWriteAttribute("alt", " alt=\"", 1479, "\"", 1500, 1);
#nullable restore
#line 31 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
WriteAttributeValue("", 1485, Model.Location, 1485, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        </div>\r\n");
#nullable restore
#line 33 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                     
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </div>\r\n");
#nullable restore
#line 36 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                             if (Model.UrlPhotos.Count != 0)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <button class=""carousel-control-prev"" type=""button"" data-bs-target=""#carouselExampleControls"" data-bs-slide=""prev"">
                                    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
                                    <span class=""visually-hidden"">Previous</span>
                                </button>
                                <button class=""carousel-control-next"" type=""button"" data-bs-target=""#carouselExampleControls"" data-bs-slide=""next"">
                                    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
                                    <span class=""visually-hidden"">Next</span>
                                </button>
");
#nullable restore
#line 46 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </div>\r\n                    </div>\r\n                    <div class=\"col-md-8\">\r\n                        <div class=\"card-body\">\r\n                            <h5 class=\"card-title\">\r\n                                ");
#nullable restore
#line 52 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                           Write(Model.TypeProperty.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 52 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                                      Write(Model.TypeSale.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </h5>\r\n                            <h5 class=\"card-subtitle\">\r\n                                <small class=\"fs-6\">\r\n                                    Esta propiedad esta ubicada en ");
#nullable restore
#line 56 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                                              Write(Model.Location.ToLower());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                </small>
                            </h5>
                            <hr />
                                <small class=""fs-6 d-flex justify-content-lg-evenly"">
                                    <div class=""text-danger"">
                                        PRECIO : RD$ ");
#nullable restore
#line 62 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                                Write(Model.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - US$ ");
#nullable restore
#line 62 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                                                    Write(Model.Price / 54);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </div>\r\n\r\n");
#nullable restore
#line 65 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                     if (Model.Bathroom != 0)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <div class=\"me-2\"><i class=\"fa-solid fa-hot-tub-person\"></i> ");
#nullable restore
#line 67 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                                                                                Write(Model.Bathroom);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 68 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
#nullable restore
#line 70 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                     if (Model.Room != 0)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <div class=\"me-2\"><i class=\"fa-solid fa-bed\"></i> ");
#nullable restore
#line 72 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                                                                     Write(Model.Room);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n");
#nullable restore
#line 73 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <div class=\"me-2\"><i class=\"fa-solid fa-building\"></i> ");
#nullable restore
#line 74 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                                                                       Write(Model.Meters);

#line default
#line hidden
#nullable disable
                WriteLiteral("mt</div>\r\n                                </small>\r\n                            <hr />\r\n                            <p class=\"card-text\">");
#nullable restore
#line 77 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                            Write(Model.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                            <div class=\"d-flex justify-content-lg-around gap-3 my-auto\">\r\n                                <p class=\"card-text text-start\"><small class=\"text-muted\">Fecha de publicación ");
#nullable restore
#line 79 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                                                                                          Write(Model.Creadted.Date.ToString());

#line default
#line hidden
#nullable disable
                WriteLiteral("</small></p>\r\n                                <small>\r\n                                    <a class=\"btn btn-outline-success btn-sm \">");
#nullable restore
#line 81 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                                                          Write(Model.Code);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n                                </small>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>

<div class=""row d-flex gap-3  mx-auto mt-1"">
    <div class=""col flex-column bg-light shadow border-1 rounded-1 rounded"">
        <div class=""row p-2 m-1"">
            <div class=""col col-4 mx-auto my-auto"">
                <small class=""text-dark fw-bolder fs-4 pt-5 text-center"">
                    Mejoras <i class=""fa-solid fa-circle-check""></i>
                </small>
            </div>
        </div>
        <hr />
        <div class=""row p-1 m-2"">
");
#nullable restore
#line 103 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
             foreach (var item in Model.Improvements)          
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col col-sm-3 my-2\">\r\n                    <small class=\"btn btn-sm btn-dark text-light text-center\">\r\n                        ");
#nullable restore
#line 107 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <i class=\"fa-solid fa-pencil\"></i>\r\n                    </small>\r\n                </div>\r\n");
#nullable restore
#line 110 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n    <div class=\"col flex-column bg-light shadow border-1 rounded-1 rounded\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e12b2f74940c10c069b339638b28c0382a4ed8f321005", async() => {
                WriteLiteral("\r\n            <div class=\"card mb-3 bg-transparent border-0 my-auto\">\r\n                <div class=\"row g-0 \">\r\n                    <div class=\"col-md-4\">\r\n                        <img");
                BeginWriteAttribute("src", " src=\"", 6101, "\"", 6135, 1);
#nullable restore
#line 118 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
WriteAttributeValue("", 6107, Model.agent.PhotoProfileUrl, 6107, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-fluid rounded pt-3 m-1 w-100\" alt=\"agente\">\r\n                    </div>\r\n                    <div class=\"col-md-8\">\r\n                        <div class=\"card-body p-3\">\r\n                            <h5 class=\"card-title\">");
#nullable restore
#line 122 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                               Write(Model.agent.Firstname + " " + Model.agent.Lastname);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h5>\r\n                            <small class=\"card-text fs-6 fw-bolder\">Informaciones Generales</small>\r\n                            <br />\r\n                            <small class=\" card-text \">Numero de telefono  <br /> ");
#nullable restore
#line 125 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                                                             Write(Model.agent.PhoneNumber);

#line default
#line hidden
#nullable disable
                WriteLiteral("</small>\r\n                            <br />\r\n                            <small class=\" card-text\">Correo Electronico  <br />  ");
#nullable restore
#line 127 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                                                             Write(Model.agent.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</small>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 114 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate APP\RealEstateApp\WebApp.RealEstateApp\Views\Home\Details.cshtml"
                                                                                                              WriteLiteral(Model.agent.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PropertyViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
