using System;
using System.Collections.Generic;

namespace MyGraphQL.DBModels
{
    public partial class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Published { get; set; }
        public long AuthorId { get; set; }
        public string Genre { get; set; }

        public virtual Author Author { get; set; }
    }
}
