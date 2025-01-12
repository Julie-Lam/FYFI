using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using static Microsoft.AspNetCore.Components.Web.RenderMode;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using FyFi.CustomerInterface;
using FyFi.CustomerInterface.Components;

namespace FyFi.CustomerInterface.Components.Pages
{
    public partial class Expense
    {
        public List<CustomerInterface.Expense> Expenses { get; set; } = new();
    }
}