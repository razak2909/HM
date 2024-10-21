using System;

namespace WebApplication1.Models
{
    public class ResultModel
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public String ErrorMessage { get; set; }
        public String TechDetails { get; set; }
    }
}