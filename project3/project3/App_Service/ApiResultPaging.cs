using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project3.App_Service
{
    public class ApiResultPaging
    {
        public int? total { get; set; }
        public int? perPage { get; set; }
        public int? currentPage { get; set; }
        public int? lastPage { get; set; }
        public int? apiResult { get; set; }
    }
}