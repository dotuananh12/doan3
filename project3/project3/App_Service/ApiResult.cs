﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project3.App_Service
{
    public class ApiResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public string action { get; set; }

    }
}