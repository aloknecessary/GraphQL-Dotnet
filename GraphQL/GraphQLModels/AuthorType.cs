using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using MyGraphQL.DBModels;

namespace MyGraphQL.GraphQL
{
    public class AuthorType : ObjectGraphType<Author>
    {
        public AuthorType()
        {
            Name = "Author";

            Field(x => x.Id, type: typeof(IdGraphType)).Description("Author's ID.");
            Field(x => x.Name).Description("The name of the Author");
            Field(x => x.Book, type: typeof(ListGraphType<BookType>)).Description("Author's books");
        }
    }
}
