// Copyright 2024 Felix Kahle. All rights reserved.

namespace TimeZoneDB.Models;

/// <summary>
/// The request to get the time zone by city.
/// </summary>
public class GetTimeZoneByCityRequest
{
    /// <summary>
    /// The city to get the time zone for.
    /// </summary>
    public required string City { get; set; }
    
    /// <summary>
    /// The country to get the time zone for.
    /// </summary>
    public required string Country { get; set; }
    
    /// <summary>
    /// The region to get the time zone for.
    /// </summary>
    public string Region { get; set; } = string.Empty;

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"{City}, {Region}, {Country}";
    }
}