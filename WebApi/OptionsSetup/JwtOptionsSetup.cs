using Core.Options;
using Microsoft.Extensions.Options;

namespace WebApi.OptionsSetup;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private readonly IConfiguration _configuration;

    //it injects the configurations from IConfiguration in JwtOptions format,
    //and it is going to use it on JwtBearerOptionsSetup.cs
    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection("Jwt").Bind(options);
    }
}