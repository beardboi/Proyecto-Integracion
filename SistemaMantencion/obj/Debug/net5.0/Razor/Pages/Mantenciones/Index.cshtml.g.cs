#pragma checksum "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83f513f7204821b0bfd95a1d504d92f1956f22ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SistemaMantencion.Pages.Mantenciones.Pages_Mantenciones_Index), @"mvc.1.0.razor-page", @"/Pages/Mantenciones/Index.cshtml")]
namespace SistemaMantencion.Pages.Mantenciones
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
#line 1 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\_ViewImports.cshtml"
using SistemaMantencion;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Index.cshtml"
using SistemaMantencion.Data.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83f513f7204821b0bfd95a1d504d92f1956f22ef", @"/Pages/Mantenciones/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efad5790cfa68eacc346968fa94f5def37410b88", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Mantenciones_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 6 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Index.cshtml"
  
    ViewData["Title"] = "Mantenciones";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"card\">\n<div class=\"text-center\">\n    <h1 class=\"display-4\">Listado de Mantenciones</h1>\n</div>\n<div>\n    <div class=\"card-header\">\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "83f513f7204821b0bfd95a1d504d92f1956f22ef4384", async() => {
                WriteLiteral("Registrar Nueva Mantención");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
    <div class=""card-body"">
        <table class=""table "">
            <thead class=""table-light"">
                <tr>
                    <th scope=""col"">Patente Vehículo</th>
                    <th scope=""col"">Fecha</th>
                    <th scope=""col"">Observación</th>
                    <th scope=""col"">Estado</th>
                    <th scope=""col"">Acciones</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 29 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Index.cshtml"
                     foreach (Mantencion mantencion in Model.Mantenciones)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\n                        <td scope=\"row\">");
#nullable restore
#line 32 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Index.cshtml"
                                   Write(mantencion.Vehiculo.Patente);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td scope=\"row\">");
#nullable restore
#line 33 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Index.cshtml"
                                   Write(mantencion.Fecha.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 34 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Index.cshtml"
                       Write(mantencion.Observaciones);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>-</td>\n                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "83f513f7204821b0bfd95a1d504d92f1956f22ef7514", async() => {
                WriteLiteral("Detalle");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Index.cshtml"
                                                      WriteLiteral(mantencion.Id);

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
            WriteLiteral("</td>\n                    </tr>\n");
#nullable restore
#line 38 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Index.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\n        </table>\n    </div>\n</div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
