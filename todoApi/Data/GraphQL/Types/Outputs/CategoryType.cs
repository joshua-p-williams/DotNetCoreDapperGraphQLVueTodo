using GraphQL.Types;
using todoApi.Data.Models;
using todoApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.Data.GraphQL.Types
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(TodoRepository todoRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the category object.");
            Field(x => x.CategoryName).Description("The Name property from the category object.");
			Field<ListGraphType<TodoType>, IEnumerable<Todo>>()
                .Name("Todos")
                .Resolve(context => {
                    return todoRepository.GetList(new { CategoryId = context.Source.Id });
			    });

        }
    }
}
