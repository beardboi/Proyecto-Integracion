#pragma checksum "C:\Users\Unscarred\Desktop\RRHH\SistemaRRHH\SistemaRRHH\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2d9724755a0a2fa875796f176c57ec573133e148"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SistemaRRHH.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace SistemaRRHH.Pages
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
#line 1 "C:\Users\Unscarred\Desktop\RRHH\SistemaRRHH\SistemaRRHH\Pages\_ViewImports.cshtml"
using SistemaRRHH;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Unscarred\Desktop\RRHH\SistemaRRHH\SistemaRRHH\Pages\Index.cshtml"
using Data.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2d9724755a0a2fa875796f176c57ec573133e148", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bb6dbebce36c0ad45c01e14f10a1357b1a4709a", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Unscarred\Desktop\RRHH\SistemaRRHH\SistemaRRHH\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n&ensp;\r\n\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Sistema de RRHH</h1>\r\n</div>\r\n\r\n<table class=\"table\">\r\n\r\n    <tr>\r\n        <td>Número</td>\r\n        <td>Rut</td>\r\n        <td>Nombre</td>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 22 "C:\Users\Unscarred\Desktop\RRHH\SistemaRRHH\SistemaRRHH\Pages\Index.cshtml"
      int i = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Unscarred\Desktop\RRHH\SistemaRRHH\SistemaRRHH\Pages\Index.cshtml"
     foreach (Persona persona in Model.personas)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 26 "C:\Users\Unscarred\Desktop\RRHH\SistemaRRHH\SistemaRRHH\Pages\Index.cshtml"
           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 27 "C:\Users\Unscarred\Desktop\RRHH\SistemaRRHH\SistemaRRHH\Pages\Index.cshtml"
           Write(persona.Rut);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 28 "C:\Users\Unscarred\Desktop\RRHH\SistemaRRHH\SistemaRRHH\Pages\Index.cshtml"
           Write(persona.Nombres);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 28 "C:\Users\Unscarred\Desktop\RRHH\SistemaRRHH\SistemaRRHH\Pages\Index.cshtml"
                            Write(persona.Apellidos);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 30 "C:\Users\Unscarred\Desktop\RRHH\SistemaRRHH\SistemaRRHH\Pages\Index.cshtml"
        i++;
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n");
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
