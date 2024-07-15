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
    /// The next time zone abbreviation.
    /// </summary>
    public string? NextAbbreviation { get; init; }
    
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
    public DateTime? ZoneStart { get; init; }
    
    /// <summary>
    /// The Unix time in UTC when current time zone end.
    /// </summary>
    public DateTime? ZoneEnd { get; init; }
    
    /// <summary>
    /// Current time in the time zone.
    /// </summary>
    public DateTime? Timestamp { get; init; }
    
    /// <summary>
    /// The total page of result when exceed 25 records.
    /// </summary>
    public int? TotalPage { get; init; }
    
    /// <summary>
    /// Current page when navigating.
    /// </summary>
    public int? CurrentPage { get; init; }
}