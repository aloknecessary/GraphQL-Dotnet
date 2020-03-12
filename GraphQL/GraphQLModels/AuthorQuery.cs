using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using MyGraphQL.DBModels;

namespace MyGraphQL.GraphQL
{
    public class AuthorQuery : ObjectGraphType
    {
        public AuthorQuery(graphQLContext db)
        {
            var id = 0;
            Field<AuthorType>(
              "Author",
              arguments: new QueryArguments(
                new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the Author." }),
              resolve: context =>
              {
                  id = context.GetArgument<int>("id");
                  var author = db
              .Author
              .Include(a => a.Book)
              .FirstOrDefault(i => i.Id == id);
                  return author;
              });

            Field<ListGraphType<AuthorType>>(
              "Authors",
              resolve: context =>
              {
                  var authors = db.Author.Include(a => a.Book);
                  return authors;
              });
        }
    }
}
