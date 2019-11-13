using GraphQL.Types;
using todoApi.Data.Models;
using todoApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApi.Data.GraphQL.Types
{
    public class TodoType : ObjectGraphType<Todo>
    {
        public TodoType(CategoryRepository categoryRepository)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the todo object.");
            Field(x => x.Details).Description("Description property from the todo object.");
            Field(x => x.CategoryId, type: typeof(IntGraphType)).Description("Category Id property from the todo object.");
            Field(x => x.Completed, type: typeof(BooleanGraphType)).Description("Completed property from the todo object.");
			Field<CategoryType, Category>()
				.Name("Category")
				.Resolve(context =>
				{
                    return categoryRepository.Get(context.Source.CategoryId);
				});

        }
    }
}
