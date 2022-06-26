using System.Security.Authentication;
using TutorProject.Account.Front.Dtos.Token;

namespace TutorProject.Account.Front;

public static class MainController
{
    private static string _userType;

    public static string UserType
    {
        get => _userType ?? throw new AuthenticationException("Пользователь не авторизован");

        private set => _userType = value;
    }

    public static bool IsAuthorized { get; set; }

    public static string Token { get; private set; }

    public static async Task Authorize(HttpService httpService, string token)
    {
        var result = await httpService.GetAsync<TokenResponseDto>($"/api/authorization?token={token}");
        
        if (!result.IsSuccessful)
            throw new InvalidOperationException("Некорректный токен");
        
        UserType = result.ResponseDto.UserType;
        Token = token;
        IsAuthorized = true;
    }
}