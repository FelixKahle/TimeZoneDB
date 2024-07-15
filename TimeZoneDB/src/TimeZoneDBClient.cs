// Copyright 2024 Felix Kahle. All rights reserved.

using System.Globalization;
using System.Text.Json;
using TimeZoneDB.DataTransferObjects;
using TimeZoneDB.Extensions;
using TimeZoneDB.Models;

namespace TimeZoneDB;

/// <summary>
/// The client for the TimeZoneDB API.
/// </summary>
public class TimeZoneDBClient
{
    /// <summary>
    /// The base URL of the TimeZoneDB API.
    /// </summary>
    private const string BaseUrl = "http://api.timezonedb.com";
    
    /// <summary>
    /// We use JSON as the format for the API.
    /// </summary>
    private const string Format = "json";
    
    /// <summary>
    /// The version of the TimeZoneDB API.
    /// </summary>
    private const string Version = "v2.1";
    
    /// <summary>
    /// The JSON serializer options to use for the client.
    /// </summary>
    private readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    /// <summary>
    /// The API key to use for the client.
    /// </summary>
    private readonly string _apiKey;
    
    /// <summary>
    /// The HTTP client to use for the client.
    /// </summary>
    private readonly HttpClient _httpClient;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="TimeZoneDBClient"/> class.
    /// </summary>
    /// <param name="apiKey">The API key to use for the client.</param>
    /// <exception cref="ArgumentException">Thrown when the API key is null or whitespace.</exception>
    public TimeZoneDBClient(string apiKey)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(apiKey);
        
        _apiKey = apiKey;
        _httpClient = new HttpClient();
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="TimeZoneDBClient"/> class.
    /// </summary>
    /// <param name="apiKey">The API key to use for the client.</param>
    /// <param name="httpClient">The HTTP client to use for the client.</param>
    /// <exception cref="ArgumentException">Thrown when the API key is null or whitespace.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the HTTP client is null.</exception>
    public TimeZoneDBClient(string apiKey, HttpClient httpClient)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(apiKey);
        ArgumentNullException.ThrowIfNull(httpClient);
        
        _apiKey = apiKey;
        _httpClient = httpClient;
    }
    
    /// <summary>
    /// Gets the time zone for a given coordinate.
    /// </summary>
    /// <param name="request">The request to get the time zone for a given coordinate.</param>
    /// <param name="cancellationToken">The cancellation token to use for the request.</param>
    /// <returns>The time zone for the given coordinate.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the response is null.</exception>
    public async Task<GetTimeZoneResponse> GetTimeZone(GetTimeZoneByCoordinateRequest request, CancellationToken cancellationToken = default)
    {
        var builder = new UriBuilder(BaseUrl)
        {
            Path = $"/{Version}/get-time-zone",
            Query = $"key={_apiKey}&format={Format}&by=position&lat={request.Latitude}&lng={request.Longitude}"
        };
        var url = builder.ToString();
        var response = await _httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var timeZoneResponseDto = JsonSerializer.Deserialize<GetTimeZoneResponseDto>(content, _jsonSerializerOptions);
        var model = timeZoneResponseDto?.ToModel() ?? throw new InvalidOperationException("Failed to deserialize the time zone response.");

        return model;
    }

    /// <summary>
    /// Gets the time zone for a given city.
    /// </summary>
    /// <param name="request">The request to get the time zone for a given city.</param>
    /// <param name="cancellationToken">The cancellation token to use for the request.</param>
    /// <returns>The time zone for the given city.</returns>
    public async Task<GetTimeZoneResponse> GetTimeZone(GetTimeZoneByCityRequest request, CancellationToken cancellationToken = default)
    {
        var builder = new UriBuilder(BaseUrl)
        {
            Path = $"/{Version}/get-time-zone",
            Query = $"key={_apiKey}&format={Format}&by=city&city={Uri.EscapeDataString(request.City)}&country={Uri.EscapeDataString(request.Country)}" +
                    (!string.IsNullOrWhiteSpace(request.Region) ? $"&region={Uri.EscapeDataString(request.Region)}" : string.Empty)
        };
        var url = builder.ToString();
        var response = await _httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var timeZoneResponseDto = JsonSerializer.Deserialize<GetTimeZoneResponseDto>(content, _jsonSerializerOptions);
        var model = timeZoneResponseDto?.ToModel() ?? throw new InvalidOperationException("Failed to deserialize the time zone response.");
    
        return model;
    }
}