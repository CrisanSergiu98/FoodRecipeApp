using FoodRecipeDataManager.Data;
using FoodRecipeDataManager.Endpoints;
using FoodRecipeDataManagerLibrary.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MinimalAPIDataAccessLibrary.DBAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IIngredientCategoryData, IngredientCategoryData>();
builder.Services.AddSingleton<IIngredientData, IngredientData>();
builder.Services.AddSingleton<IUnitData, UnitData>();
builder.Services.AddSingleton<IRecipeData, RecipeData>();
builder.Services.AddSingleton<IRecipeCategoryData, RecipeCategoryData>();
builder.Services.AddSingleton<IRecipeIngredientData, RecipeIngredientData>();
builder.Services.AddSingleton<IRecipeStepData, RecipeStepData>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();    
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.UseSwagger();
app.UseSwaggerUI();

app.ConfigureIngredientCategoryEndpoints();
app.ConfigureRecipeCategoryEndpoints();
app.ConfigureIngredientEndpoints();
app.ConfigureUnitEndpoints();
app.ConfigureRecipeEndpoints();
app.ConfigureRecipeIngredientEndpoints();
app.ConfigureSteptEndpoints();

app.Run();
