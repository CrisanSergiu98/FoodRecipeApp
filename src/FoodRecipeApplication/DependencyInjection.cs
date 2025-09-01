using FoodRecipeApplication.Persistence;
using FoodRecipeApplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FoodRecipeApplication;

public static class DependencyInjecton
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<RecipeRepository>();
        services.AddScoped<IngredientRepository>();
        services.AddScoped<RecipeService>();
        return services;
    }
}