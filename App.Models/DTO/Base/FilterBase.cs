﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.DTO.Base
{
   public class FilterBase
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedOnFrom { get; set; }
        public DateTime? CreatedOnTo { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public string SortOrder { get; set; }
        public int TotalRecordCount { get; set; }
        public int FilteredRecordCount { get; set; }
    }
}
