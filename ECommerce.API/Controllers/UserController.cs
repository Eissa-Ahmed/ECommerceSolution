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
    [HttpPost(Routes.User.SendCode)]
    public async Task<IActionResult> SendCode(string Email)
    {
        var result = await _mediator.Send(new UserSendCodeModel(Email));
        return BaseResult(result);
    }
    [HttpPost(Routes.User.ForgetPasswoed)]
    public async Task<IActionResult> ForgetPasswoed([FromBody] UserForgetPasswordModel model)
    {
        var result = await _mediator.Send(model);
        return BaseResult(result);
    }
    [HttpPut(Routes.User.ResetPassword)]
    public async Task<IActionResult> ResetPassword([FromBody] UserResetPasswordModel model)
    {
        var result = await _mediator.Send(model);
        return BaseResult(result);
    }

}
