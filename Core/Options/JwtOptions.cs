namespace Core.Options;


/// <summary>
/// this is the data that we made the template in the development json
/// </summary>
public class JwtOptions
{
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Secret { get; set; } = string.Empty;
    public int ExpirationInMinutes { get; set; }
}