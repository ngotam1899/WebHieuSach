#pragma checksum "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a46f5606c52abaa118a1758b3271c10f87153034"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shipments_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Shipments/Index.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\_ViewImports.cshtml"
using BookShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\_ViewImports.cshtml"
using BookShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a46f5606c52abaa118a1758b3271c10f87153034", @"/Areas/Admin/Views/Shipments/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ee4735df80bb67d1ce7d40fc94d37240032cc50", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shipments_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BookShop.Models.ViewModel.ShipmentViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a46f5606c52abaa118a1758b3271c10f871530344020", async() => {
                WriteLiteral("\r\n    <br /><br />\r\n    <h2 class=\"text-info\">Shipment List</h2>\r\n    <br />\r\n\r\n    <div style=\"height:150px; background-color:aliceblue\" class=\"container\">\r\n");
                WriteLiteral("        <div class=\"col-12\">\r\n            <div class=\"row\" style=\"padding-top:10px;\">\r\n                <div class=\"col-sm-2\">\r\n                    Customer Name\r\n                </div>\r\n                <div class=\"col-sm-3\">\r\n                    ");
#nullable restore
#line 15 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
               Write(Html.Editor("searchName", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"col-2\">\r\n\r\n                </div>\r\n                <div class=\"col-sm-2\">\r\n                    Email\r\n                </div>\r\n                <div class=\"col-sm-3\">\r\n                    ");
#nullable restore
#line 24 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
               Write(Html.Editor("searchEmail", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
            </div>

            <div class=""row"" style=""padding-top:10px;"">
                <div class=""col-sm-2"">
                    Phone Number
                </div>
                <div class=""col-sm-3"">
                    ");
#nullable restore
#line 33 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
               Write(Html.Editor("searchPhone", new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n                <div class=\"col-2\">\r\n\r\n                </div>\r\n                <div class=\"col-sm-2\">\r\n                    Shipment Date\r\n                </div>\r\n                <div class=\"col-sm-3\">\r\n                    ");
#nullable restore
#line 42 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
               Write(Html.Editor("searchDate", new { htmlAttributes = new { @class = "form-control", @id = "datepicker" } }));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                </div>
            </div>

            <div class=""row"" style=""padding-top:10px;"">
                <div class=""col-sm-2"">
                </div>
                <div class=""col-sm-3"">
                </div>
                <div class=""col-2"">

                </div>
                <div class=""col-sm-2"">
                </div>
                <div class=""col-sm-3"">
                    <button type=""submit"" name=""submit"" value=""Search"" class=""btn btn-primary form-control"">
                        <i class=""fas fa-search""></i> Search
                    </button>
                </div>
            </div>
        </div>
    </div>

    <br /><br />

    <div>
        <table class=""table table-striped border"">
            <tr class=""table-info"">
                <th>
                    ");
#nullable restore
#line 71 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Shipments.FirstOrDefault().SalesPerson.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 74 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Shipments.FirstOrDefault().ShipmentDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 77 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Shipments.FirstOrDefault().CustomerName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 80 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Shipments.FirstOrDefault().CustomerPhone));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 83 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Shipments.FirstOrDefault().CustomerEmail));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 86 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Shipments.FirstOrDefault().isConfirmed));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </th>\r\n                <th>\r\n\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n");
#nullable restore
#line 93 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
             foreach (var item in Model.Shipments)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 97 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
                   Write(Html.DisplayFor(m => item.SalesPerson.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 100 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
                   Write(Html.DisplayFor(m => item.ShipmentDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 103 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CustomerName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 106 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CustomerPhone));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 109 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CustomerEmail));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 112 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
                   Write(Html.DisplayFor(m => item.isConfirmed));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a46f5606c52abaa118a1758b3271c10f8715303412340", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 115 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.ID;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 118 "C:\Users\Admin\Desktop\Update\BookShop\Areas\Admin\Views\Shipments\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </table>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>       \r\n        $(function () {\r\n            $(\"#datepicker\").datepicker({\r\n                minDate: +1, maxDate: \"+3M\"\r\n            });\r\n        });\r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookShop.Models.ViewModel.ShipmentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591