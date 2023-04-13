using System;
using System.Collections.Generic;

namespace intex_2023_api.Models
{
    public partial class User
    {
        public string Email { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Hash { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
