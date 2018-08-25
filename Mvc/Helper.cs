using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Basics.Mvc
{
    public static class Helper
    {
        public static HttpContext Context => HttpContext.Current;
    }
}
