// <auto-generated/>
#pragma warning disable 1591
namespace Test
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    public class TestComponent : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 0414
        #pragma warning disable 0169
        private global::Microsoft.AspNetCore.Components.ElementReference myElem;
        #pragma warning restore 0169
        #pragma warning restore 0414
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            builder.OpenElement(0, "elem");
            builder.AddAttribute(1, "attributebefore", "before");
            builder.AddAttribute(2, "attributeafter", "after");
            builder.AddElementReferenceCapture(3, (__value) => {
#nullable restore
#line 1 "x:\dir\subdir\Test\TestComponent.cshtml"
                                     myElem = __value;

#line default
#line hidden
#nullable disable
            }
            );
            builder.AddContent(4, "Hello");
            builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
