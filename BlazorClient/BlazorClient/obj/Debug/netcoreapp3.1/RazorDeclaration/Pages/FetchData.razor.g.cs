#pragma checksum "E:\programming\Projects\IdentifyImages\BlazorClient\BlazorClient\Pages\FetchData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9260eb1cc29f914b38d992a1c01015ed6e8c9ba"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorClient.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\programming\Projects\IdentifyImages\BlazorClient\BlazorClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\programming\Projects\IdentifyImages\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\programming\Projects\IdentifyImages\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\programming\Projects\IdentifyImages\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\programming\Projects\IdentifyImages\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\programming\Projects\IdentifyImages\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\programming\Projects\IdentifyImages\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\programming\Projects\IdentifyImages\BlazorClient\BlazorClient\_Imports.razor"
using BlazorClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\programming\Projects\IdentifyImages\BlazorClient\BlazorClient\_Imports.razor"
using BlazorClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\programming\Projects\IdentifyImages\BlazorClient\BlazorClient\Pages\FetchData.razor"
using BlazorClient.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 39 "E:\programming\Projects\IdentifyImages\BlazorClient\BlazorClient\Pages\FetchData.razor"
       
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private WeatherForecastService ForecastService { get; set; }
    }
}
#pragma warning restore 1591
