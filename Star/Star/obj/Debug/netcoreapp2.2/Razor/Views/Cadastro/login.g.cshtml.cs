#pragma checksum "C:\Users\isaque.alves\Documents\GitHub\Starc\Star\Star\Views\Cadastro\login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62041d7515786ff4c3737ea8d289784e2b65d556"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cadastro_login), @"mvc.1.0.view", @"/Views/Cadastro/login.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cadastro/login.cshtml", typeof(AspNetCore.Views_Cadastro_login))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62041d7515786ff4c3737ea8d289784e2b65d556", @"/Views/Cadastro/login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46adf39f546d99c342cfac097f0c16d878bb3aea", @"/Views/_ViewImports.cshtml")]
    public class Views_Cadastro_login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2435, true);
            WriteLiteral(@"<!--
<div class='modal fade' id='ModalCenter' tabindex='-1' role='dialog' aria-labelledby='exampleModalCenterTitle' aria-hidden='true'>
				  <div class='modal-dialog modal-dialog-centered' role='document'>
				    <div class='modal-content'>
				      <div class='modal-header'>
				        <h5 class='modal-title' id='exampleModalLongTitle'>Login</h5>
				        <button type='button' class='close' data-dismiss='modal' aria-label='Close'>
				          <span aria-hidden='true'>&times;</span>
				        </button>
				      </div>
				      <div class='modal-body'>
				        	Login ou senha incorretos!
				      </div>
				      <div class='modal-footer'>
				        <button type='button' class='btn btn-secondary' data-dismiss='modal'>Close</button>
				      </div>
				    </div>
				  </div>
				</div>  
				<script>
					window.onload =  function abre (){
    				$('#ModalCenter').modal();};
				</script>



	
	<div class=""limiter"">
		<div class=""container-login100"">
			<div c");
            WriteLiteral(@"lass=""wrap-login100"">
				<div class=""login100-pic js-tilt"" data-tilt>
					<img src=""~/images/img-01.png"" alt=""IMG"">
				</div>

				<form class=""login100-form validate-form"" method=""post"">
					<span class=""login100-form-title"">
						Login
					</span>

					<div class=""wrap-input100 validate-input"" data-validate = ""Digite um email valido: exemplo@exemplo.com"">
						<input asp-for=""e"" class=""input100"" type=""text""  placeholder=""Email"">
						<span class=""focus-input100""></span>
						<span class=""symbol-input100"">
							<i class=""fa fa-envelope"" aria-hidden=""true""></i>
						</span>
					</div>

					<div class=""wrap-input100 validate-input"" data-validate = ""Digite uma senha válida"">
						<input asp-for=""s"" class=""input100"" type=""password""  placeholder=""Senha"">
						<span class=""focus-input100""></span>
						<span class=""symbol-input100"">
							<i class=""fa fa-lock"" aria-hidden=""true""></i>
						</span>
					</div>
					
					<div class=""container-login100-form-btn"">
						<i");
            WriteLiteral(@"nput type=""submit""  value=""Login""class=""login100-form-btn"" >
					</div>

					

					<div class=""text-center p-t-136"">
						<a asp-controller=""Usuario"" asp-action=""Cadastro"" class=""txt2"" href="""">
							Criar uma conta
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
