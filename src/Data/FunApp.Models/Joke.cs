using System;
using System.ComponentModel.DataAnnotations;
using FunApp.Data.Common;

namespace FunApp.Models
{
    public class Joke:BaseModel<int>
    {
        
        public string Content { get; set; }

        
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        
    }
}
