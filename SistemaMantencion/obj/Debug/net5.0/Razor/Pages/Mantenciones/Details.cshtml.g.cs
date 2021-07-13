#pragma checksum "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42e988f0c53a2c2813e21f52e415e2ade970c00a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SistemaMantencion.Pages.Mantenciones.Pages_Mantenciones_Details), @"mvc.1.0.razor-page", @"/Pages/Mantenciones/Details.cshtml")]
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
#line 3 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
using SistemaMantencion.Data.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42e988f0c53a2c2813e21f52e415e2ade970c00a", @"/Pages/Mantenciones/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efad5790cfa68eacc346968fa94f5def37410b88", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Mantenciones_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 5 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
  
    ViewData["Title"] = "Detalle de Mantencion";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"card\">\n    <div class=\"card-header\">\n        <div class=\"text-center\">\n            <h1 class=\"display-4\">Mantencion</h1>\n        </div>\n    </div>\n    <div class=\"card-body\">\n        <p><b>Fecha: </b>");
#nullable restore
#line 16 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
                    Write(Model.Mantencion.Fecha.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        <p><b>Observaciones: </b>");
#nullable restore
#line 17 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
                            Write(Model.Mantencion.Observaciones);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </p>
        &nbsp
        <br>

        <h4>Materiales utilizados</h4>
        <table class=""table"">
            <thead class=""table-light"">
                <tr>
                    <th scope=""col"">Material</th>
                    <th scope=""col"">Cantidad Usada</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 30 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
                 foreach (MantencionMaterial mantencionProducto in Model.ListaMantencionMateriales)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>");
#nullable restore
#line 33 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
                   Write(mantencionProducto.Material.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 34 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
                   Write(mantencionProducto.Cantidad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                </tr>\n");
#nullable restore
#line 36 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </tbody>
        </table>
        &nbsp
        <h4>Tecnicos involucrados</h4>
        <table class=""table"">
            <thead class=""table-light"">
                <tr>
                    <th scope=""col"">RUT</th>
                    <th scope=""col"">Nombre</th>
                    <th scope=""col"">Horas Trabajadas</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 50 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
                 foreach (MantencionTecnico mantencionEmpleado in Model.ListaMantencionTecnicos)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <th scope=\"row\">");
#nullable restore
#line 53 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
                               Write(mantencionEmpleado.Tecnico.Rut);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\n                    <td>");
#nullable restore
#line 54 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
                   Write(mantencionEmpleado.Tecnico.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 55 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
                   Write(mantencionEmpleado.Horas);

#line default
#line hidden
#nullable disable
            WriteLiteral(" hrs</td>\n                </tr>\n");
#nullable restore
#line 57 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaMantencion\Pages\Mantenciones\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\n        </table>\n    </div>\n    <div class=\"card-header\">\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42e988f0c53a2c2813e21f52e415e2ade970c00a8657", async() => {
                WriteLiteral("Volver");
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
            WriteLiteral("\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<DetailsModel>)PageContext?.ViewData;
        public DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
