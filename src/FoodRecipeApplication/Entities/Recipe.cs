namespace FoodRecipeApplication.Entities;

public class Recipe
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Picture { get; set; }
    public IEnumerable<RecipeIngredient> Ingredients { get; set; }
    public IEnumerable<RecipeStep> Steps { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public bool IsPublished { get; set; }
}