using System.Threading.Tasks;
using FoodRecipeApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodRecipeAppMvc.Controllers;

public class RecipeController : Controller
{
    private readonly RecipeService _recipeService;

    public RecipeController(RecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    [HttpGet("Recipes/{id}")]  // Route definition
    public async Task<IActionResult> Details(Guid id)
    {
        var result = await _recipeService.GetRecipeAsync(id);
        var recipe = result.Value;

        if (recipe == null)
            return NotFound("Recipe not found.");

        return View(recipe);
    }
}
