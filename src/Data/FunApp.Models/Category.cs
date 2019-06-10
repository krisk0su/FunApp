using System;
using System.Collections.Generic;
using System.Text;
using FunApp.Data.Common;

namespace FunApp.Models
{
    public class Category:BaseModel<int>
    {
        public string Name { get; set; }
    }
}
