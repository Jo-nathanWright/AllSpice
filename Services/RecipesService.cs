using System;
using System.Collections.Generic;
using AllSpice.Models;
using AllSpice.Repositories;

namespace AllSpice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _repo;

    public RecipesService(RecipesRepository repo)
    {
      _repo = repo;
    }

    internal List<Recipe> Get()
    {
      return _repo.Get();
    }

    internal Recipe Get(int id)
    {
      Recipe recipe = _repo.Get(id);
      if (recipe == null){
        throw new Exception("Invalid Id");
      }
      return recipe;
    }

    internal Recipe Create(Recipe newRecipe)
    {
      return _repo.Create(newRecipe);
    }

    internal void Delete(int recipeId, string userId)
    {
      Recipe recipeToDelete = Get(recipeId);
      if (recipeToDelete.CreatorId != userId)
      {
        throw new Exception("You do NOT have permission to delete this event");
      }
      _repo.Delete(recipeId);
    }
  }
}