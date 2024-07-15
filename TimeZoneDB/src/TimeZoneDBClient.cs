// Copyright 2024 Felix Kahle. All rights reserved.

namespace TimeZoneDB;

/// <summary>
/// The client for the TimeZoneDB API.
/// </summary>
public class TimeZoneDBClient
{
    /// <summary>
    /// The base URL of the TimeZoneDB API.
    /// </summary>
    private const string BaseUrl = "http://api.timezonedb.com/v2.1";

    private readonly string _apiKey;
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
}