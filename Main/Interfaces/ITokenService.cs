using Main.Models.Identity;

namespace Main.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}