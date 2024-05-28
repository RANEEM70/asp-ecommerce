using System.Security.Claims;
using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeCrafters_backend_teamwork.src.Controllers;


public class UserController : CustomizedController
{
   private IUserService _userService;

   public UserController(IUserService userService)
   {
      _userService = userService;
   }

   [HttpPatch("{email}")]
   public User? UpdateOne(string email, [FromBody] User user)
   {
      return _userService.UpdateOne(email, user);
   }

   [HttpGet]
   [Authorize(Roles = "Admin")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   public ActionResult<IEnumerable<UserReadDto>> FindMany()
   {
      var authenticatedClaims = HttpContext.User;
             var userId = authenticatedClaims.FindFirst(c=> c.Type == ClaimTypes.NameIdentifier)!.Value;
            var userEmail = ClaimTypes.Email;

            Console.WriteLine($"user Id {userId}");
            Console.WriteLine($"user email {userEmail}");
      return Ok(_userService.FindMany());
   }

   [HttpGet("{email}")]
   public ActionResult<UserReadDto?> FindOne(string email)
   {
      return Ok(_userService.FindOneByEmail(email));
   }

   [HttpPost("signup")]
   [ProducesResponseType(StatusCodes.Status201Created)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public ActionResult<UserReadDto> SignUp([FromBody] UserCreateDto user)
   {
      // Console.WriteLine($"{user.Email}");

      if (user is not null)
      {

         Console.WriteLine($"Receive user data");
         var createdUser = _userService.SignUp(user);
         return CreatedAtAction(nameof(SignUp), createdUser);
      }
      return BadRequest();

   }

   [HttpPost("login")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public ActionResult<string> SignIn([FromBody] UserSignIn user)
   {

      if (user is not null)
      {
         string token = _userService.SignIn(user);
         if (token is null)
         {
            return BadRequest();
         }
         return Ok(token);
      }
      return BadRequest();

   }


   [HttpDelete("{userId}")]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   [ProducesResponseType(StatusCodes.Status404NotFound)]
   public ActionResult<UserReadDto> DeleteOneById(Guid userId)
   {
      var deletedUser = _userService.FindOneById(userId);
      if (deletedUser != null)
      {
         return NoContent();
      }
      return NotFound();

   }

}
