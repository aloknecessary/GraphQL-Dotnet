using System;
using System.Collections.Generic;

namespace MyGraphQL.DBModels
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
