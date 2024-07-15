// Copyright 2024 Felix Kahle. All rights reserved.

namespace TimeZoneDB.Models;

/// <summary>
/// Result of the GetTimeZone API-Endpoint.
/// </summary>
public class GetTimeZoneResult
{
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
    /// The time zone.
    /// </summary>
    public TimeZoneInfo? TimeZone { get; init; }
    
    /// <summary>
    /// Abbreviation of the time zone.
    /// </summary>
    public string? Abbreviation { get; init; }
    
    /// <summary>
    /// The time offset based on UTC time.
    /// </summary>
    public TimeSpan? GmtOffset { get; init; }
    
    /// <summary>
    /// Whether Daylight Saving Time (DST) is used.
    /// </summary>
    public bool? Dst { get; init; }
    
    /// <summary>
    /// The Unix time in UTC when current time zone start.
    /// </summary>
    public DateTimeOffset? ZoneStart { get; init; }
    
    /// <summary>
    /// The Unix time in UTC when current time zone end.
    /// </summary>
    public DateTimeOffset? ZoneEnd { get; init; }
    
    /// <summary>
    /// Current local time in Unix time. Minus the value with gmtOffset to get UTC time.
    /// </summary>
    public DateTime? Timestamp { get; init; }
    
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
}