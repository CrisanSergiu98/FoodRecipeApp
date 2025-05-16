namespace FoodRecipeApplication.Shared;

// Custom implementation of the Result pattern
public class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public string? Error { get; }
    // Success constructor.
    private Result(T value) { IsSuccess = true; Value = value; }
    // Failure constructor.
    private Result(string error) { IsSuccess = false; Error = error; }
    // Factory method for returning a value.
    public static Result<T> Success(T value) => new(value);
    // Factory method for returning a faiure.
    public static Result<T> Failure(string error) => new(error);
}