#pragma checksum "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaRRHH\Pages\Empleados\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e3441b5706658f2485a3c917e46a143b7250071"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SistemaRRHH.Pages.Empleados.Pages_Empleados_Index), @"mvc.1.0.razor-page", @"/Pages/Empleados/Index.cshtml")]
namespace SistemaRRHH.Pages.Empleados
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
#line 1 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaRRHH\Pages\_ViewImports.cshtml"
using SistemaRRHH;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaRRHH\Pages\Empleados\Index.cshtml"
using Data.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e3441b5706658f2485a3c917e46a143b7250071", @"/Pages/Empleados/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b8dc8b4c4f58fb5be2a5100cf3e01a964c18c8c", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Empleados_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaRRHH\Pages\Empleados\Index.cshtml"
  
    ViewData["Title"] = "Empleados";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col"">
            <div class=""card"">
                <div class=""card-header"">
                     <h1 class=""display-4"">Sistema de RRHH</h1>
                </div>
                <div class=""card-body"">
                    <table class=""table"">
                        <thead class=""thead-light"">
                            <tr>
                                <th>N°</th>
                                <th>Rut</th>
                                <th>Nombre</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 26 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaRRHH\Pages\Empleados\Index.cshtml"
                               int i = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaRRHH\Pages\Empleados\Index.cshtml"
                             foreach (Persona persona in Model.Empleados)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td scope=\"row\">");
#nullable restore
#line 30 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaRRHH\Pages\Empleados\Index.cshtml"
                                           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 31 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaRRHH\Pages\Empleados\Index.cshtml"
                               Write(persona.Rut);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 32 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaRRHH\Pages\Empleados\Index.cshtml"
                               Write(persona.Nombres);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 32 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaRRHH\Pages\Empleados\Index.cshtml"
                                                Write(persona.Apellidos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e3441b5706658f2485a3c917e46a143b72500716451", async() => {
                WriteLiteral("Detalle");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaRRHH\Pages\Empleados\Index.cshtml"
                                                              WriteLiteral(persona.Id);

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
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 35 "C:\Users\Unscarred\Desktop\Proyecto de Desarrollo e Integración de Soluciones\SistemaRRHH\Pages\Empleados\Index.cshtml"
                            i++;
                            }   

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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