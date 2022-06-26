using Blazored.LocalStorage;
using TutorProject.Account.Front.Dtos.Token;

namespace TutorProject.Account.Front.Services;

public class AuthorizationService
{
    private const string AuthCookie = "AuthData";

    private readonly ILocalStorageService _localStorage;
    private readonly HttpService _httpService;

    public delegate Task AuthorizationHandler();
    public static event AuthorizationHandler? UserAuthorized;
    
    public AuthorizationService(ILocalStorageService localStorage, HttpService httpService)
    {
        _localStorage = localStorage;
        _httpService = httpService;
    }

    public async ValueTask<bool> IsAuthorizedAsync()
    {
        return await GetAuthData() is not null;
    }

    public async Task<AuthorizationData?> GetAuthData()
    {
        if (!await _localStorage.ContainKeyAsync(AuthCookie))
            return null;
        
        var authData = await _localStorage.GetItemAsync<AuthorizationData>(AuthCookie);
        if (await IsTokenActual(authData.Token))
            return authData;

        await CancelAuthorization();
        return null;
    }

    public async Task CancelAuthorization()
    {
        await _localStorage.RemoveItemAsync(AuthCookie);
    }

    private async Task<bool> IsTokenActual(string token)
    {
        var result = await _httpService.GetAsync<TokenResponseDto>($"/api/authorization?token={token}");
        return result.IsSuccessful;
    }
    

    public async Task AuthorizeAsync(string token)
    {
        var result = await _httpService.GetAsync<TokenResponseDto>($"/api/authorization?token={token}");
        
        if (!result.IsSuccessful)
            throw new InvalidOperationException("Не найден пользователь по данному токену");

        var authorizationData = new AuthorizationData
        {
            Token = token,
            UserType = result.ResponseDto!.UserType
        };
        
        await _localStorage.SetItemAsync(AuthCookie, authorizationData);
        UserAuthorized?.Invoke();
    }
}