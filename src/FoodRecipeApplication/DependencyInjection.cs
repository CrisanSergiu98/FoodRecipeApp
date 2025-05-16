using FoodRecipeApplication.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace FoodRecipeApplication;

public static class DependencyInjecton
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<RecipeRepository>();
        services.AddSingleton<IngredientRepository>();
        return services;
    }
}