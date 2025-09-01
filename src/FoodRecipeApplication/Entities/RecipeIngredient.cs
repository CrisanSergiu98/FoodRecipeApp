namespace FoodRecipeApplication.Entities;

public class RecipeIngredient
{
    public Guid RecipeId { get; set; }
    public Guid IngredientId { get; set; }
    public float Quantity { get; set; }
    public Unit unit { get; set; }

    // Nav Properties
    public Recipe Recipe { get; set; }
    public Ingredient Ingredient { get; set; }
} 