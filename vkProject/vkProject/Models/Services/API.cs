using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace vkProj.Models;

public class Api
{
    private static HttpClient _httpClient = new();

    public Api()
    {
        var httpClient = _httpClient;
    }

    public virtual async Task<string> GetSingleFile(string url)
    {
        string full_url = "http://localhost:5159/items" + url; 
         var file_response = await _httpClient.GetStringAsync(full_url);
         return file_response;
    }
    
    public virtual async Task<VkFile> GetUserFiles()
    {
        var options = new JsonSerializerOptions();
        options.IncludeFields = true;
        using var response = await _httpClient.GetAsync("http://localhost:5159/docs");
         var result = await response.Content.ReadFromJsonAsync<VkFile>(options: options);
         return result;
    }
    
    public virtual async Task<UserData> GetAccessToken(string clientId)
    {
        Dictionary<string, string> data = new()
        {
            ["client_id"] = clientId,
            ["redirectUri"] = "https://oauth.vk.com/blank.html",
            ["display"] = "popup",
            ["responseType"] = "token",
            ["scope"] = "docs",
            ["revoke"] = "1"
        };

        HttpContent contentForm = new FormUrlEncodedContent(data);


        using var response = await _httpClient.PostAsync("https://oauth.vk.com/authorize", contentForm);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine(response.Content.ReadAsStringAsync());
            return UserData.getInstance("0", "0", "0");
        }
        else
        {
            var responseText = await response.Content.ReadAsStringAsync();
            return UserData.readDataFromUrlEncoded(responseText);
        }
    }
}