using System.Security.Authentication;

namespace TutorProject.Account.Front;

public static class MainController
{
    private static string _userType;

    private static bool _isAuthtorized;

    private static string _token;

    public static string User
    {
        get => _userType ?? throw new AuthenticationException("Пользователь не авторизован");

        set => _userType = value;
    }

    public static bool IsAuthorized
    {
        get => _isAuthtorized;
        set => _isAuthtorized = value;
    }

    public static string Token
    {
        get => _token;
        set => _token = value;
    }
}