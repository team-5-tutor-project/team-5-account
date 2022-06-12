using System.Security.Authentication;
using TutorProject.Account.Front.Models;

namespace TutorProject.Account.Front;

public static class CurrentUser
{
    private static User _user;

    private static bool _isAuthtorized;

    public static User User => _user ?? throw new AuthenticationException("Пользователь не авторизован");

    public static void Login(User user)
    {
        _user = user;
        _isAuthtorized = true;
    }

    public static void Logout()
    {
        _user = null;
        _isAuthtorized = true;
    }

    public static bool IsAuthorized
    {
        get => _isAuthtorized;
    }
}