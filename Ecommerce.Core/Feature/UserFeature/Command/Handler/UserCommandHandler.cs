﻿namespace Ecommerce.Core.Feature.UserFeature.Command.Handler;

public class UserCommandHandler : ResponseHandler,
    IRequestHandler<UserLoginModel, Response<AuthenticationModel>>,
    IRequestHandler<UserRegisterModel, Response<string>>,
    IRequestHandler<UserSendCodeModel, Response<string>>,
    IRequestHandler<UserForgetPasswordModel, Response<string>>,
    IRequestHandler<UserResetPasswordModel, Response<string>>
{
    private readonly IAuthenticationServices _authenticationService;
    public UserCommandHandler(IAuthenticationServices authenticationService)
    {
        _authenticationService = authenticationService;
    }
    public async Task<Response<AuthenticationModel>> Handle(UserLoginModel request, CancellationToken cancellationToken)
    {
        AuthenticationModel result = await _authenticationService.Login(request.Email, request.Password);
        if (result.IsAuthenticated)
            return Success(result);

        return Unauthorized<AuthenticationModel>();
    }

    public async Task<Response<string>> Handle(UserRegisterModel request, CancellationToken cancellationToken)
    {
        string result = await _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        if (result == "Success")
            return Success(result);
        return BadRequest<string>(result);
    }

    public async Task<Response<string>> Handle(UserSendCodeModel request, CancellationToken cancellationToken)
    {
        string result = await _authenticationService.SendCodeToChangePassword(request.Email);
        if (result == "Success")
            return Success(result);
        return BadRequest<string>(result);
    }

    public async Task<Response<string>> Handle(UserForgetPasswordModel request, CancellationToken cancellationToken)
    {
        string result = await _authenticationService.ForgetPassword(request.Email, request.Password, request.Code);
        if (result == "Success")
            return Success(result);
        return BadRequest<string>(result);
    }

    public async Task<Response<string>> Handle(UserResetPasswordModel request, CancellationToken cancellationToken)
    {
        string result = await _authenticationService.ResetPassword(request.Email, request.OldPassword, request.NewPassword);
        if (result == "Success")
            return Success(result);
        return BadRequest<string>(result);
    }
}
