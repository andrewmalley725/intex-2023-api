using System;
using System.Collections.Generic;

namespace intex_2023_api.Models
{
    public partial class Essential
    {
        public long? Id { get; set; }
        public string? Burialnumber { get; set; }
        public string? Area { get; set; }
        public string? Eastwest { get; set; }
        public string? Squareeastwest { get; set; }
        public string? Northsouth { get; set; }
        public string? Squarenorthsouth { get; set; }
        public string? Ageatdeath { get; set; }
        public string? Sex { get; set; }
        public string? Depth { get; set; }
        public string? Length { get; set; }
        public string? Haircolor { get; set; }
        public string? Headdirection { get; set; }
        public string? Wrapping { get; set; }
    }
}
