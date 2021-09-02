using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllSpice.Models;
using AllSpice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllSpice.Controllers
{

  [ApiController]
  [Route("/api/[controller]")]
  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _recipesService;

    public RecipesController(RecipesService recipesService)
    {
      _recipesService = recipesService;
    }

    [HttpGet]
    public ActionResult<List<Recipe>> Get()
    {
      try
      {
        List<Recipe> recipes = _recipesService.Get();
        return Ok(recipes);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Recipe> Get(int id)
    {
      try
      {
        Recipe recipe = _recipesService.Get(id);
        return Ok(recipe);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe newRecipe)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        newRecipe.CreatorId = userInfo.Id;
        Recipe recipe = _recipesService.Create(newRecipe);
        return Ok(recipe);
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }
}
}