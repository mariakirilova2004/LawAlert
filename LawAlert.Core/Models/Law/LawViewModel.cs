﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAlert.Core.Models.Law
{
    public class LawViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public string DetailsCard()
        {
            var str = this.Details.Substring(0, 200);
            return str;
        }
    }
}
