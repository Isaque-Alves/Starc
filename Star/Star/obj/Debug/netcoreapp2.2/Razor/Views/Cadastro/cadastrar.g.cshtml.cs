#pragma checksum "C:\Users\isaque.alves\Documents\GitHub\Starc\Star\Star\Views\Cadastro\cadastrar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12e7a3b2fcc0eb682974baf00a06079253cb09a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cadastro_cadastrar), @"mvc.1.0.view", @"/Views/Cadastro/cadastrar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cadastro/cadastrar.cshtml", typeof(AspNetCore.Views_Cadastro_cadastrar))]
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
#line 1 "C:\Users\isaque.alves\Documents\GitHub\Starc\Star\Star\Views\_ViewImports.cshtml"
using Star;

#line default
#line hidden
#line 2 "C:\Users\isaque.alves\Documents\GitHub\Starc\Star\Star\Views\_ViewImports.cshtml"
using Star.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12e7a3b2fcc0eb682974baf00a06079253cb09a8", @"/Views/Cadastro/cadastrar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46adf39f546d99c342cfac097f0c16d878bb3aea", @"/Views/_ViewImports.cshtml")]
    public class Views_Cadastro_cadastrar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 3404, true);
            WriteLiteral(@"<!--
	
	<div class=""limiter"">
		<div class=""container-login100"">
			<div class=""wrap-login100"">
				<div class=""login100-pic js-tilt"" data-tilt>
					<img src=""~/images/img-01.png"" alt=""IMG"">
				</div>

                <form class=""login100-form validate-form"" method=""post"">
                    <span class=""login100-form-title"">
                        Criar Conta
                    </span>

                    <div class=""wrap-input100 validate-input"" data-validate=""Digite um nome. Exemplo: Família Starc"">
                        <input asp-for=""NomeCadastro"" class=""input100"" type=""text"" placeholder=""Nome"">
                        <span class=""focus-input100""></span>
                        <span class=""symbol-input100"">
                            <i class=""fa fa-user-circle"" aria-hidden=""true""></i>
                        </span>
                    </div>

                    <div class=""wrap-input100 validate-input"" data-validate=""Digite seu nome. Exemplo: José"">
                ");
            WriteLiteral(@"        <input asp-for=""Nome"" class=""input100"" type=""text"" placeholder=""Nome"">
                        <span class=""focus-input100""></span>
                        <span class=""symbol-input100"">
                            <i class=""fa fa-user-circle"" aria-hidden=""true""></i>
                        </span>
                    </div>


                    <div class=""wrap-input100 validate-input"" data-validate=""Digite um email valido: exemplo@exemplo.com"">
                        <input asp-for=""Email"" class=""input100"" type=""text"" placeholder=""Email"">
                        <span class=""focus-input100""></span>
                        <span class=""symbol-input100"">
                            <i class=""fa fa-envelope"" aria-hidden=""true""></i>
                        </span>
                    </div>

                    <div class=""wrap-input100 validate-input"" data-validate=""Digite uma senha válida"">
                        <input asp-for=""Senha"" class=""input100"" type=""password"" placeholder=""");
            WriteLiteral(@"Senha"">
                        <span class=""focus-input100""></span>
                        <span class=""symbol-input100"">
                            <i class=""fa fa-lock"" aria-hidden=""true""></i>
                        </span>
                    </div>

                    <div class=""wrap-input100 validate-input"" data-validate=""Digite uma senha válida"">
                        <input asp-for=""Senha"" class=""input100"" type=""password"" placeholder=""Confirmar senha"">
                        <span class=""focus-input100""></span>
                        <span class=""symbol-input100"">
                            <i class=""fa fa-lock"" aria-hidden=""true""></i>
                        </span>
                    </div>

                    <div class=""container-login100-form-btn"">
                        <input type=""submit"" value=""Criar conta"" class=""login100-form-btn"" data-toggle=""modal"" data-target=""#exampleModalCenter"">
                    </div>
                    <div class=""text-center p-t-1");
            WriteLiteral(@"36"">
                        <a class=""txt2"" >
                            Já possui uma conta? Faça o login
                            <i class=""fa fa-long-arrow-right m-l-5"" aria-hidden=""true""></i>
                        </a>
                    </div>
                </form>
			</div>
		</div>
	</div>
	
	-->

	
");
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
