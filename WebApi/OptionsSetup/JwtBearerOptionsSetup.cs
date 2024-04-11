using Core.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApi.OptionsSetup;

/// <summary>
/// We setup the token validation parameters here
/// </summary>
public class JwtBearerOptionsSetup : IConfigureOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions;

    public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    /// <summary>
    /// sets the validation according to the JwtOptions we injected in JwtBearerOptions
    /// </summary>
    public void Configure(JwtBearerOptions options)
    {
        //we encrypt it with SymmetricSecurityKey and save it as a key
        var issuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));

        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtOptions.Issuer, //CltApi
            ValidAudience = _jwtOptions.Audience, //BankRelatedPeople
            IssuerSigningKey = issuerSigningKey
        };
    }
}