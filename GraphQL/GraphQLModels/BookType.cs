using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using MyGraphQL.DBModels;

namespace MyGraphQL.GraphQL
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType()
        {
            Name = "Book";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the Book.");
            Field(x => x.Name).Description("The name of the Book");
            Field(x => x.Genre).Description("Book genre");
            Field(x => x.Published).Description("If the book is published or not");
        }
    }
}
