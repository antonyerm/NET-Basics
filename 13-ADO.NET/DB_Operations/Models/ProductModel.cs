using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Operations.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
    }
}
