// Copyright 2024 Felix Kahle. All rights reserved.

namespace TimeZoneDB.Models;

/// <summary>
/// Request model for the GetTimeZoneByCoordinate API-Endpoint.
/// </summary>
public class GetTimeZoneByCoordinateRequest
{
    /// <summary>
    /// The latitude of the coordinate.
    /// </summary>
    public required double Latitude { get; set; }
    
    /// <summary>
    /// The longitude of the coordinate.
    /// </summary>
    public required double Longitude { get; set; }
    
    /// <inheritdoc/>
    public override string ToString()
    {
        return $"Latitude: {Latitude}, Longitude: {Longitude}";
    }
}