using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;
using TutorProject.Account.Front.Models;

namespace TutorProject.Account.Front;

public class HttpService
{
    private readonly HttpClient _http;

    public HttpService(HttpClient http)
    {
        _http = http;
    }

    public async Task<RequestResult<TResponseDto?>> PatchWithBody<TResponseDto>(string uri, object requestDto)
    {
        var serializedRequest = JsonConvert.SerializeObject(requestDto);
        var requestData = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
        var response = await _http.PatchAsync(uri, requestData);
        
        if (!response.IsSuccessStatusCode)
            return new RequestResult<TResponseDto?> { IsSuccessful = false };

        return new RequestResult<TResponseDto?>
        {
            IsSuccessful = true,
            Result = await response.Content.ReadFromJsonAsync<TResponseDto>()
        };
    }
    
    public async Task<RequestResult<TResponseDto?>> PostWithBody<TResponseDto>(string uri, object requestDto)
    {
        var serializedRequest = JsonConvert.SerializeObject(requestDto);
        var requestData = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
        var response = await _http.PostAsync(uri, requestData);
        
        if (!response.IsSuccessStatusCode)
            return new RequestResult<TResponseDto?> { IsSuccessful = false };

        return new RequestResult<TResponseDto?>
        {
            IsSuccessful = true,
            Result = await response.Content.ReadFromJsonAsync<TResponseDto>()
        };
    }
}