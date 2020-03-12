using System;
using System.Collections.Generic;

namespace MyGraphQL.DBModels
{
    public partial class Emp
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Dept { get; set; }
    }
}
