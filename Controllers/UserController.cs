using ASPNET_WebAPI.DTOs;
using ASPNET_WebAPI.Models;
using ASPNET_WebAPI.Services.UserService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_WebAPI.Controllers
{
    // 10 - Create a controller => root / Controllers / UserController.cs

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // 10.1 - Create private readonly fields for the services to be injected
        private readonly IUserService _userService;

        // 10.2 - Inject the services via the constructor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // TODO: UPDATE THIS AND THE NUMERIC ORDER OF STEPS
        // 10.3 - Create the endpoints 
        // BEST PRACTICES:
        //      - Use the async/await pattern to avoid blocking the thread
        //      - Use the IActionResult interface or ActionResult<T> implementation, when multiple return types are possible
        //      and to return the correct status code and metadata, such as:
        //      Ok() 200  | CreatedAtAction() 201 | NoContent() 204 | BadRequest() 400 | NotFound() 404
        //      - GET methods should be typed with ActionResult<T> to enforce the return of specific type of data
        //      ( it is not necessary to wrap the response in Ok(), it is implicit in the success case) or return NotFound()
        //      - POST methods should return CreatedAtAction() with the created object or BadRequest()
        //      - PUT methods should return NoContent() or NotFound()
        //      - DELETE methods should return NoContent() or NotFound()

        [HttpGet]
        public async void GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            throw new NotImplementedException();

            var user = await _userService.GetByIdAsync(id);

            if (user is null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO user)
        {
            // implicitly returns BadRequest() if the Body of the request is not valid

            throw new NotImplementedException();

            var createdUser = await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserDTO user)
        {
            // implicitly returns BadRequest() if the Body of the request is not valid

            throw new NotImplementedException();

            if (id != user.Id)
                return BadRequest();

            // Not sure if this check should be here, or in the service
            var existingUser = await _userService.GetByIdAsync(id);
            
            if (existingUser is null)
                return NotFound();

            await _userService.UpdateAsync(id, user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();

            // Not sure if this check should be here, or in the service
            var existingUser = await _userService.GetByIdAsync(id);

            if (existingUser is null)
                return NotFound();

            await _userService.DeleteAsync(id);

            return NoContent();
        }
    }
}
