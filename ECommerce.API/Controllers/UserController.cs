namespace ECommerce.API.Controllers;

[ApiController]
[AllowAnonymous]
public class UserController : BaseController
{
    [HttpPost(Routes.User.Login)]
    public async Task<IActionResult> Login([FromBody] UserLoginModel model)
    {
        var result = await _mediator.Send(model);
        return BaseResult(result);
    }
    [HttpPost(Routes.User.Register)]
    public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
    {
        var result = await _mediator.Send(model);
        return BaseResult(result);
    }

}
