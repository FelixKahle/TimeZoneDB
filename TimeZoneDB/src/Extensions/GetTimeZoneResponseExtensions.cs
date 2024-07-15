// Copyright 2024 Felix Kahle. All rights reserved.

using System.Globalization;
using TimeZoneDB.DataTransferObjects;
using TimeZoneDB.Models;

namespace TimeZoneDB.Extensions;

public static class GetTimeZoneResponseExtensions
{
    /// <summary>
    /// Converts a <see cref="GetTimeZoneResponseDto"/> to a <see cref="GetTimeZoneResponse"/>.
    /// </summary>
    /// <param name="dto">The data transfer object to convert.</param>
    /// <returns>The converted model.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the status is null or invalid.</exception>
    /// <exception cref="TimeZoneNotFoundException">Thrown when the time zone is not found.</exception>
    /// <exception cref="FormatException">Thrown when the time offset is not a valid time span.</exception>
    public static GetTimeZoneResponse ToModel(this GetTimeZoneResponseDto dto)
    {
        // First we need to check if the status is null. If it is, we throw an exception,
        // as we expect the status to be either "OK" or "FAILED".
        var status = dto.Status ?? throw new InvalidOperationException("Status must not be null.");
        
        // We then convert the status to an enum value,
        // before that we apply some transformations to the string,
        // to make sure that the comparison is case-insensitive and that there are no leading or trailing whitespaces.
        var responseStatus = status.ToUpper().Trim() switch
        {
            "OK" => GetTimeZoneResponseStatus.Ok,
            "FAILED" => GetTimeZoneResponseStatus.Failed,
            _ => throw new InvalidOperationException("Invalid status.")
        };

        // We then create a result object based on the response status.
        // If we have a successful response, we create a new GetTimeZoneResult object,
        // if the response is failed, we set the result to null.
        // Note that TimeZoneInfo.FindSystemTimeZoneById will throw an exception if the time zone is not found
        // and that TimeSpan.Parse will throw an exception if the string is not a valid time span.
        var result = responseStatus switch
        {
            GetTimeZoneResponseStatus.Ok => new GetTimeZoneResult
            {
                CountryCode = dto.CountryCode,
                CountryName = dto.CountryName,
                RegionName = dto.RegionName,
                CityName = dto.CityName,
                TimeZone = TimeZoneInfo.FindSystemTimeZoneById(dto.ZoneName ?? string.Empty),
                Abbreviation = dto.Abbreviation ?? string.Empty,
                GmtOffset = TimeSpan.Parse(dto.GmtOffset ?? string.Empty, CultureInfo.InvariantCulture),
                Dst = dto.Dst == "1"
            },
            _ => null
        };

        // Finally, we create a new GetTimeZoneResponse object and return it.
        return new GetTimeZoneResponse
        {
            Status = responseStatus,
            ErrorMessage = dto.ErrorMessage,
            Result = result
        };
    }

    /// <summary>
    /// Converts a <see cref="GetTimeZoneResponse"/> to a <see cref="GetTimeZoneResponseDto"/>.
    /// </summary>
    /// <param name="model">The model to convert.</param>
    /// <returns>The converted data transfer object.</returns>
    public static GetTimeZoneResponseDto ToDto(this GetTimeZoneResponse model)
    {
        return new GetTimeZoneResponseDto
        {
            Status = model.Status.ToString().ToUpper(),
            ErrorMessage = model.ErrorMessage,
            CountryCode = model.Result?.CountryCode,
            CountryName = model.Result?.CountryName,
            RegionName = model.Result?.RegionName,
            CityName = model.Result?.CityName,
            ZoneName = model.Result?.TimeZone?.Id,
            Abbreviation = model.Result?.Abbreviation,
            GmtOffset = model.Result?.GmtOffset.ToString(),
            Dst = model.Result?.Dst == true ? "1" : "0"
        };
    }
}