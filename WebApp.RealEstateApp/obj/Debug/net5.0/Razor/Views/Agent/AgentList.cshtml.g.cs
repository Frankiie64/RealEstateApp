#pragma checksum "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94ff36bd3e25072615f21131e625a072f8c4601b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Agent_AgentList), @"mvc.1.0.view", @"/Views/Agent/AgentList.cshtml")]
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
#line 1 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\_ViewImports.cshtml"
using WebApp.RealEstateApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\_ViewImports.cshtml"
using WebApp.RealEstateApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
using RealEstateApp.Core.Application.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
using RealEstateApp.Core.Application.ViewModels.Agent;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
using RealEstateApp.Core.Application.ViewModels.Users;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94ff36bd3e25072615f21131e625a072f8c4601b", @"/Views/Agent/AgentList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72394fdb40496eb5af2efc2dca8f56d4e5e04cb7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Agent_AgentList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AgentVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Agent", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "IsActive", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-labeled btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
 if (ViewBag.AgentList.Count == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2 class=\"text-center mt-5\">No se encontro ningun Agente Registrado </h2>\r\n");
#nullable restore
#line 9 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <link rel=""stylesheet"" type=""text/css"" href=""//netdna.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css"">
    <hr>
    <div class=""col"">
        <h2 class=""text-center mb-5 display-5""> Lista de Agentes</h2>
    </div>
    <hr>
    <div class=""container-fluid bootstrap snippets bootdey mt-4"">
        <div class=""row"">
            <div class=""col"">
                <div class=""main-box no-header clearfix"">
                    <div class=""main-box-body clearfix"">
                        <div class=""table-responsive shadow-lg p-3 mb-5 bg-white rounded"">
                            <table class=""table user-list"">
                                <thead>
                                    <tr>
                                        <th>Nombre</th>
                                        <th>Apellido</th>
                                        <th>Correo</th>
                                        <th>Cantidad de Propiedades</th>
                                        <th>Estado<");
            WriteLiteral("/th>\r\n                                        <td class=\"fw-bolder\"");
            BeginWriteAttribute("style", " style=\"", 1398, "\"", 1406, 0);
            EndWriteAttribute();
            WriteLiteral(">Acciones</td>\r\n                                    </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 36 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                     foreach (AgentVM item in ViewBag.AgentList)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 39 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                           Write(item.Firstname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 40 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                           Write(item.Lastname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td><a href=\"#\"> ");
#nullable restore
#line 41 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                                        Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                                            <td>");
#nullable restore
#line 42 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                           Write(item.PropertyQuantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>\r\n");
#nullable restore
#line 44 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                                 if (item.IsActive == true)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"label label-active\"> Activa</span>\r\n");
#nullable restore
#line 47 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                                }
                                                else
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"label label-disabled\"> Inactiva</span>\r\n");
#nullable restore
#line 51 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                            </td>
                                            <td class=""justify-content-end"">
                                                <button type=""button"" class=""btn btn-warning btn-sm"" data-bs-toggle=""modal"" data-bs-target=""");
#nullable restore
#line 55 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                                                                                                                        Write($"#{item.Username}");

#line default
#line hidden
#nullable disable
            WriteLiteral("\" )\">\r\n                                                    ");
#nullable restore
#line 56 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                                Write(item.IsActive == true ? "Inactivar" : "Activar");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </button>\r\n\r\n                                                <div class=\"modal fade\"");
            BeginWriteAttribute("id", " id=\"", 3142, "\"", 3161, 1);
#nullable restore
#line 59 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
WriteAttributeValue("", 3147, item.Username, 3147, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" tabindex=\"-1\" aria-labelledby=\"exampleModalLabel\" aria-hidden=\"true\">\r\n\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94ff36bd3e25072615f21131e625a072f8c4601b13394", async() => {
                WriteLiteral(@"
                                                        <div class=""modal-dialog"">
                                                            <div class=""modal-content"">
                                                                <div class=""modal-header"">
                                                                    <h5 class=""modal-title"" id=""exampleModalLabel"">Atencion</h5>
                                                                    <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
                                                                </div>
                                                                <div class=""modal-body"">
                                                                    Estas seguro de que deseas ");
#nullable restore
#line 69 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                                                                           Write(item.IsActive == true ? "Inactivar" : "Activar");

#line default
#line hidden
#nullable disable
                WriteLiteral(" esta cuenta ?\r\n                                                                </div>\r\n                                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "94ff36bd3e25072615f21131e625a072f8c4601b15031", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
#nullable restore
#line 71 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                                                                      WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                                                <div class=""modal-footer"">
                                                                    <button type=""button"" class=""btn btn-warning"" data-bs-dismiss=""modal"">Cancelar</button>
                                                                    <button type=""submit"" class=""btn btn-danger"">Aceptar</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                </div>\r\n                                            </td>\r\n                                            <td>\r\n                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94ff36bd3e25072615f21131e625a072f8c4601b20086", async() => {
                WriteLiteral(@"
                                                    <span class=""btn-label"">
                                                        <i class=""fa fa-times""></i>
                                                    </span>Eliminar
                                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 82 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                            </td>\r\n\r\n                                        </tr>\r\n");
#nullable restore
#line 91 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 100 "C:\Users\Eleikel\Desktop\ITLA\Programacion III\Real Estate 5\RealEstateApp\WebApp.RealEstateApp\Views\Agent\AgentList.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AgentVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
