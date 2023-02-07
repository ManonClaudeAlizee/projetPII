using projetPII.Data;

namespace projetPII.Models;

public class SeedData
{
    public static void Init()
    {
        using (var context = new projetPIIContext())
        {
            // Look for existing content
            if (context.Users.Any())
            {
                return;   // DB already filled
            }

            User user1 = new User
            {
                Name = "Manon",
                FirstName = "Claude",
                Phone = "0631000000",
                Mail = "blabla@gmail.com",
                Password = "mdp",
                IsAdmin = true,
            };

            context.Users.AddRange(user1);

            // Commit changes into DB
            context.SaveChanges();
        }
    }
}