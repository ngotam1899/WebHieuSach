#pragma checksum "C:\Users\Admin\Desktop\Update\BookShop\Views\Shared\_TableButtonPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e4d327a653da419d86480b1fe899e71d89651073"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TableButtonPartial), @"mvc.1.0.view", @"/Views/Shared/_TableButtonPartial.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Update\BookShop\Views\_ViewImports.cshtml"
using BookShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Update\BookShop\Views\_ViewImports.cshtml"
using BookShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e4d327a653da419d86480b1fe899e71d89651073", @"/Views/Shared/_TableButtonPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee4735df80bb67d1ce7d40fc94d37240032cc50", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TableButtonPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<td style=\"width:150px\">\r\n    <div class=\"btn-group\" role=\"group\">\r\n        <a type=\"button\" class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 252, "\"", 304, 1);
#nullable restore
#line 8 "C:\Users\Admin\Desktop\Update\BookShop\Views\Shared\_TableButtonPartial.cshtml"
WriteAttributeValue("", 259, Url.Action("Edit/"+Model).Replace("%2F","/"), 259, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fas fa-edit\"></i>\r\n        </a>\r\n        <a type=\"button\" class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 411, "\"", 466, 1);
#nullable restore
#line 11 "C:\Users\Admin\Desktop\Update\BookShop\Views\Shared\_TableButtonPartial.cshtml"
WriteAttributeValue("", 418, Url.Action("Details/"+Model).Replace("%2F","/"), 418, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fas fa-list\"></i>\r\n        </a>\r\n        <a type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 572, "\"", 626, 1);
#nullable restore
#line 14 "C:\Users\Admin\Desktop\Update\BookShop\Views\Shared\_TableButtonPartial.cshtml"
WriteAttributeValue("", 579, Url.Action("Delete/"+Model).Replace("%2F","/"), 579, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fas fa-trash-alt\"></i>\r\n        </a>\r\n    </div>\r\n</td>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591