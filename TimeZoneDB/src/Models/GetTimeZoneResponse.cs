// Copyright 2024 Felix Kahle. All rights reserved.

namespace TimeZoneDB.Models;

/// <summary>
/// The status of the API query.
/// </summary>
public enum GetTimeZoneResponseStatus
{
    Ok,
    Failed
}

/// <summary>
/// Response from the GetTimeZone API-Endpoint.
/// </summary>
public class GetTimeZoneResponse
{
    /// <summary>
    /// Status of the API query. Either OK or FAILED.
    /// </summary>
    public GetTimeZoneResponseStatus Status { get; init; }
    
    /// <summary>
    /// Error message. Empty if no error.
    /// </summary>
    public string? ErrorMessage { get; init; }
    
    /// <summary>
    /// The result of the API query.
    /// </summary>
    public GetTimeZoneResult? Result { get; init; }
    
    /// <summary>
    /// Whether the API query was successful.
    /// </summary>
    public bool IsSuccessful => Status == GetTimeZoneResponseStatus.Ok;
}