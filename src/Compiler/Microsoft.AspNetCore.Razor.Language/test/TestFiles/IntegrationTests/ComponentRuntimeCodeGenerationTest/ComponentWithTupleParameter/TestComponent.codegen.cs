﻿// <auto-generated/>
#pragma warning disable 1591
namespace Test
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
    #line default
    #line hidden
    #nullable restore
    public partial class TestComponent : global::Microsoft.AspNetCore.Components.ComponentBase
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<global::Test.TestComponent>(0);
            __builder.AddComponentParameter(1, "Gutter", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<(System.Int32 Horizontal, System.Int32 Vertical)>(
#nullable restore
#line (5,24)-(5,32) "x:\dir\subdir\Test\TestComponent.cshtml"
(32, 16)

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line (1,8)-(3,1) "x:\dir\subdir\Test\TestComponent.cshtml"

    [Parameter] public (int Horizontal, int Vertical) Gutter { get; set; }

#line default
#line hidden
#nullable disable

    }
}
#pragma warning restore 1591
