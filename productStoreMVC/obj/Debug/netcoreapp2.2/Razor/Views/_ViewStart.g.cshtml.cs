#pragma checksum "/Users/i506272/Documents/GitHub/NordiskLuksus/productStoreMVC/Views/_ViewStart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3eb93ca9f58b745b7a35b311aef33ea40216e31b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views__ViewStart), @"mvc.1.0.view", @"/Views/_ViewStart.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/_ViewStart.cshtml", typeof(AspNetCore.Views__ViewStart))]
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
#line 1 "/Users/i506272/Documents/GitHub/NordiskLuksus/productStoreMVC/Views/_ViewImports.cshtml"
using productStoreMVC.models;

#line default
#line hidden
#line 2 "/Users/i506272/Documents/GitHub/NordiskLuksus/productStoreMVC/Views/_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3eb93ca9f58b745b7a35b311aef33ea40216e31b", @"/Views/_ViewStart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaa770cd1951cf9652b4f1083c95decd496fc00e", @"/Views/_ViewImports.cshtml")]
    public class Views__ViewStart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "/Users/i506272/Documents/GitHub/NordiskLuksus/productStoreMVC/Views/_ViewStart.cshtml"
  
    var controller = ViewContext.RouteData.Values["Controller"].ToString();
    string controllerLayout = "";
    if(controller == "Admin"){
        controllerLayout = "~/Views/Shared/_AdminLayout.cshtml";
    }else{
        controllerLayout = "~/Views/Shared/_CustomerLayout.cshtml";
    }
    Layout = controllerLayout;

#line default
#line hidden
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
