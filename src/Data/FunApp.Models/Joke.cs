using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using FunApp.Data.Common;

namespace FunApp.Models
{
    public class Joke:BaseModel<int>
    {
        public string Content { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        
    }
}
