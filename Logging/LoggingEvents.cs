﻿// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Logging
{
    public static class LoggingEvents
    {
        public static readonly EventId InitDatabase = new EventId(101, "Error whilst creating and seeding database");
        public static readonly EventId SendEmail = new EventId(201, "Error whilst sending email");
    }

}
