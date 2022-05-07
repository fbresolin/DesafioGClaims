#pragma checksum "D:\Users\breso\Documents\DesafioGClaims\DesafioGClaims\Views\Characters\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9a6cd72d5af3900ffc0655b618eb22e3c078fc4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Characters_Index), @"mvc.1.0.view", @"/Views/Characters/Index.cshtml")]
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
#line 1 "D:\Users\breso\Documents\DesafioGClaims\DesafioGClaims\Views\_ViewImports.cshtml"
using DesafioGClaims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\breso\Documents\DesafioGClaims\DesafioGClaims\Views\_ViewImports.cshtml"
using DesafioGClaims.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9a6cd72d5af3900ffc0655b618eb22e3c078fc4d", @"/Views/Characters/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ea2cb22d238ce25545318a245644e404ae1286e", @"/Views/_ViewImports.cshtml")]
    public class Views_Characters_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DesafioGClaims.MarvelApi.Schemas.CharacterDataWrapper>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Users\breso\Documents\DesafioGClaims\DesafioGClaims\Views\Characters\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container p-3"">
    <div class=""row pt-4"">
        <div class=""col-6"">
            <h2 class=""text-primary"">Lista de heróis </h2>
        </div>
    </div>
    <br /><br />
</div>



<table class=""table table-bordered table-striped"" style=""width:100%"">
    <thead>
        <tr>
            <th>
                Personagem
            </th>
            <th>
                Descrição
            </th>
            <th>
                Favoritar
            </th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 32 "D:\Users\breso\Documents\DesafioGClaims\DesafioGClaims\Views\Characters\Index.cshtml"
         foreach (var character in Model.Data.Results)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td width=\"20%\">\r\n                    ");
#nullable restore
#line 36 "D:\Users\breso\Documents\DesafioGClaims\DesafioGClaims\Views\Characters\Index.cshtml"
               Write(Html.ActionLink(linkText: character.Name,
                        actionName: "Details",
                        controllerName: "Characters",
                        routeValues: new { characterId = character.Id },
                        htmlAttributes: new { @class = "btn btn-link" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td width=\"50%\">\r\n                    ");
#nullable restore
#line 43 "D:\Users\breso\Documents\DesafioGClaims\DesafioGClaims\Views\Characters\Index.cshtml"
               Write(character.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td width=\"15%\">\r\n");
#nullable restore
#line 46 "D:\Users\breso\Documents\DesafioGClaims\DesafioGClaims\Views\Characters\Index.cshtml"
                     using (Html.BeginForm(
                        actionName:"Favorite",
                        controllerName:"Characters",
                        routeValues:  new { characterId = character.Id }, 
                        FormMethod.Post))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <button>Favoritar</button>\r\n");
#nullable restore
#line 53 "D:\Users\breso\Documents\DesafioGClaims\DesafioGClaims\Views\Characters\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n            </tr>\r\n");
#nullable restore
#line 56 "D:\Users\breso\Documents\DesafioGClaims\DesafioGClaims\Views\Characters\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n<footer>\r\n    ");
#nullable restore
#line 61 "D:\Users\breso\Documents\DesafioGClaims\DesafioGClaims\Views\Characters\Index.cshtml"
Write(Html.Raw(Model.AttributionHTML));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</footer>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DesafioGClaims.MarvelApi.Schemas.CharacterDataWrapper> Html { get; private set; }
    }
}
#pragma warning restore 1591
