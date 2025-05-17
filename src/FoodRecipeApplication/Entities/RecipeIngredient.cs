namespace FoodRecipeApplication.Entities;

public class RecipeIngredient
{
    public Guid RecipeId { get; set; }
    public Guid IngredientId { get; set; }
    public float Quantity { get; set; }
    public Unit unit{ get; set; }
} 