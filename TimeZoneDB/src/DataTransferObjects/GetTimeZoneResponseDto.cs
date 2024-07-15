// Copyright 2024 Felix Kahle. All rights reserved.

namespace TimeZoneDB.DataTransferObjects;

/// <summary>
/// Response data transfer object for the GetTimeZone API-Endpoint.
/// </summary>
public record GetTimeZoneResponseDto
{
    /// <summary>
    /// Status of the API query. Either OK or FAILED.
    /// </summary>
    public string? Status { get; init; }
    
    /// <summary>
    /// Error message. Empty if no error.
    /// </summary>
    public string? ErrorMessage { get; init; }
    
    /// <summary>
    /// Country code of the time zone.
    /// </summary>
    public string? CountryCode { get; init; }
    
    /// <summary>
    /// Country name of the time zone.
    /// </summary>
    public string? CountryName { get; init; }
    
    /// <summary>
    /// Region / State name of the time zone.
    /// </summary>
    public string? RegionName { get; init; }
    
    /// <summary>
    /// City / Place name of the time zone.
    /// </summary>
    public string? CityName { get; init; }
    
    /// <summary>
    /// The time zone name.
    /// </summary>
    public string? ZoneName { get; init; }
    
    /// <summary>
    /// Abbreviation of the time zone.
    /// </summary>
    public string? Abbreviation { get; init; }
    
    /// <summary>
    /// The time offset in seconds based on UTC time.
    /// </summary>
    public string? GmtOffset { get; init; }
    
    /// <summary>
    /// Whether Daylight Saving Time (DST) is used. Either 0 (No) or 1 (Yes).
    /// </summary>
    public string? Dst { get; init; }
    
    /// <summary>
    /// The Unix time in UTC when current time zone start.
    /// </summary>
    public string? ZoneStart { get; init; }
    
    /// <summary>
    /// The Unix time in UTC when current time zone end.
    /// </summary>
    public string? ZoneEnd { get; init; }
    
    /// <summary>
    /// Current local time in Unix time. Minus the value with gmtOffset to get UTC time.
    /// </summary>
    public string? Timestamp { get; init; }
    
    /// <summary>
    /// Formatted timestamp in Y-m-d h:i:s format. E.g.: 2024-07-15 10:16:18
    /// </summary>
    public string? Formatted { get; init; }
    
    /// <summary>
    /// The total page of result when exceed 25 records.
    /// </summary>
    public string? TotalPage { get; init; }
    
    /// <summary>
    /// Current page when navigating.
    /// </summary>
    public string? CurrentPage { get; init; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"""
                Status: {Status}, 
                ErrorMessage: {ErrorMessage}, 
                CountryCode: {CountryCode}, 
                CountryName: {CountryName}, 
                RegionName: {RegionName}, 
                CityName: {CityName}, 
                ZoneName: {ZoneName}, 
                Abbreviation: {Abbreviation}, 
                GmtOffset: {GmtOffset}, 
                Dst: {Dst}, 
                ZoneStart: {ZoneStart}, 
                ZoneEnd: {ZoneEnd}, 
                Timestamp: {Timestamp}, 
                Formatted: {Formatted}, 
                TotalPage: {TotalPage}, 
                CurrentPage: {CurrentPage}
                """;
    }
}