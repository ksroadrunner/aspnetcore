#pragma checksum "/Users/roadrunner/Projects/BookStore/BookStore/Views/Service/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a40f8b207d66137ae391808c982d9a1729172e50"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Service_Index), @"mvc.1.0.view", @"/Views/Service/Index.cshtml")]
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
#line 1 "/Users/roadrunner/Projects/BookStore/BookStore/Views/_ViewImports.cshtml"
using BookStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/roadrunner/Projects/BookStore/BookStore/Views/_ViewImports.cshtml"
using BookStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a40f8b207d66137ae391808c982d9a1729172e50", @"/Views/Service/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7405129f38e4334088c9f99aab64f77db16eae6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Service_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string[]>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/Users/roadrunner/Projects/BookStore/BookStore/Views/Service/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>\n    Singleton\n</h1>\n");
#nullable restore
#line 9 "/Users/roadrunner/Projects/BookStore/BookStore/Views/Service/Index.cshtml"
   print(Model[0..2]); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>\n    Transient\n</h1>\n");
#nullable restore
#line 14 "/Users/roadrunner/Projects/BookStore/BookStore/Views/Service/Index.cshtml"
   print(Model[2..4]); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>\n    Scoped\n</h1>\n");
#nullable restore
#line 19 "/Users/roadrunner/Projects/BookStore/BookStore/Views/Service/Index.cshtml"
   print(Model[4..]); 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
        }
        #pragma warning restore 1998
#nullable restore
#line 21 "/Users/roadrunner/Projects/BookStore/BookStore/Views/Service/Index.cshtml"
            
    void print(string[] arr)
    {
        foreach (var item in arr)
        {

#line default
#line hidden
#nullable disable
        WriteLiteral("            <p>");
#nullable restore
#line 26 "/Users/roadrunner/Projects/BookStore/BookStore/Views/Service/Index.cshtml"
          Write(item);

#line default
#line hidden
#nullable disable
        WriteLiteral("</p>\n");
#nullable restore
#line 27 "/Users/roadrunner/Projects/BookStore/BookStore/Views/Service/Index.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string[]> Html { get; private set; }
    }
}
#pragma warning restore 1591