#pragma checksum "C:\Users\0033966\Documents\GitHub\Starc\Star\Star\Views\Componente\Consulta.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a45e9bd098e66bc59a8e7158a84a9976d0a1c1c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Componente_Consulta), @"mvc.1.0.view", @"/Views/Componente/Consulta.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Componente/Consulta.cshtml", typeof(AspNetCore.Views_Componente_Consulta))]
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
#line 1 "C:\Users\0033966\Documents\GitHub\Starc\Star\Star\Views\_ViewImports.cshtml"
using Star;

#line default
#line hidden
#line 2 "C:\Users\0033966\Documents\GitHub\Starc\Star\Star\Views\_ViewImports.cshtml"
using Star.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a45e9bd098e66bc59a8e7158a84a9976d0a1c1c", @"/Views/Componente/Consulta.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46adf39f546d99c342cfac097f0c16d878bb3aea", @"/Views/_ViewImports.cshtml")]
    public class Views_Componente_Consulta : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\0033966\Documents\GitHub\Starc\Star\Star\Views\Componente\Consulta.cshtml"
 if (ViewBag.Consulta.Status == true)
{

#line default
#line hidden
            BeginContext(44, 19, true);
            WriteLiteral("    <h5>rec1</h5>\r\n");
            EndContext();
#line 5 "C:\Users\0033966\Documents\GitHub\Starc\Star\Star\Views\Componente\Consulta.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(75, 19, true);
            WriteLiteral("    <h5>rec0</h5>\r\n");
            EndContext();
#line 9 "C:\Users\0033966\Documents\GitHub\Starc\Star\Star\Views\Componente\Consulta.cshtml"
}

#line default
#line hidden
            BeginContext(97, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
