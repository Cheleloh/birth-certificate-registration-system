using BirthCertificateRegistrationSystem.Data;
using BirthCertificateRegistrationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BirthCertificateRegistrationSystem.Models;

public class UserService(
    BirthCertificateDbContext birthCertificateDbContext
    )
{
    public async Task<User> createUser(UserRequest request)
    {
        var checkUser = await birthCertificateDbContext.Users
            .FirstOrDefaultAsync(x => x.Email == request.Email);
        
        // if(checkUser is null) throw new BadRequestException("User with this email already exists");
        
        var newUser = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.Address,
            PhoneNumber = request.PhoneNumber,
            Username = request.Username,
            PasswordHash = request.PasswordHash,
            Role = request.Role ?? "User",
            Email = request.Email,
            CreatedAt = DateTime.UtcNow
        };
        birthCertificateDbContext.Users.Add(newUser);
        await birthCertificateDbContext.SaveChangesAsync();
        return newUser;
        
        
        
    }
}