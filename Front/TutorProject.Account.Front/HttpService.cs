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

    public async Task<RequestResult<TResponseDto?>> PatchWithBodyAsync<TResponseDto>(string uri, object requestDto)
    {
        var serializedRequest = JsonConvert.SerializeObject(requestDto);
        var requestData = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
        var response = await _http.PatchAsync(uri, requestData);
        
        return await BuildResult<TResponseDto>(response);
    }
    
    public async Task<RequestResult<TResponseDto?>> PostWithBodyAsync<TResponseDto>(string uri, object requestDto)
    {
        var serializedRequest = JsonConvert.SerializeObject(requestDto);
        var requestData = new StringContent(serializedRequest, Encoding.UTF8, "application/json");
        var response = await _http.PostAsync(uri, requestData);
        
        return await BuildResult<TResponseDto>(response);
    }

    public async Task<RequestResult<TResponseDto?>> GetAsync<TResponseDto>(string uri)
    {
        var response = await _http.GetAsync(uri);

        return await BuildResult<TResponseDto>(response);
    }

    private async Task<RequestResult<TResponseDto?>> BuildResult<TResponseDto>(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
            return new RequestResult<TResponseDto?> { IsSuccessful = false };
        
        return new RequestResult<TResponseDto?>
        {
            IsSuccessful = true,
            ResponseDto = await response.Content.ReadFromJsonAsync<TResponseDto>()
        };
    }
}