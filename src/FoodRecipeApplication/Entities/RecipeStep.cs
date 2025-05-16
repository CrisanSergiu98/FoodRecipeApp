namespace FoodRecipeApplication.Entities;

public class RecipeStep
{
    public Guid RecipeId { get; set; }
    public int StepNumber { get; set; }
    public string StepDescription { get; set; }
    public string StepPicture { get; set; }
}