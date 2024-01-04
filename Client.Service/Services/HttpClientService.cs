using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Service.Services;

public class HttpClientService
{
    private readonly HttpClient _httpClient;

    public HttpClientService()
    {
        _httpClient = new HttpClient();
    }

    // 无参数的POST方法
    public async Task<T> PostAsync<T>(string url)
    {
        _httpClient.Timeout = TimeSpan.FromSeconds(10);
        var response = await _httpClient.PostAsync(url, null);

        // 检查响应是否成功
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content); // 反序列化响应内容
    }

    // 有参数的POST方法，参数以JSON格式传递
    public async Task<T> PostJsonAsync<T>(string url, object postData)
    {
        var json = JsonConvert.SerializeObject(postData);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);

        // 检查响应是否成功
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent); // 反序列化响应内容
    }

    // 有参数的POST方法，参数以表单格式传递
    public async Task<T> PostFormAsync<T>(string url, Dictionary<string, string> formData)
    {
        var content = new FormUrlEncodedContent(formData);

        var response = await _httpClient.PostAsync(url, content);

        // 检查响应是否成功
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent); // 反序列化响应内容
    }
}