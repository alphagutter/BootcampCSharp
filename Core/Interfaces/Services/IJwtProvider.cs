namespace Core.Interfaces.Services;


//interface to create the jwt provider
public interface IJwtProvider
{
    string GenerateAllRoles(IEnumerable<string> roles);
}