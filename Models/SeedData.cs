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

            User user2 = new User
            {
                Name = "Marie",
                FirstName = "Pierre",
                Phone = "0631000018",
                Mail = "blibli@gmail.com",
                Password = "mdp",
                IsAdmin = false,
            };

            context.Users.AddRange(user1, user2);

            Event eventTest = new Event
            {
                Title = "soirée SBK",
                Date = new DateTime(2023, 12, 1),
                DescriptionCourte = "Super soirée danses latines sur Bordeaux",
                DescriptionLongue = "Super soirée danses latines sur Bordeaux",
                Lieu = "L'atelier - Merignac",
            };

            Event eventTest2 = new Event
            {
                Title = "soirée SBK bis",
                Date = new DateTime(2023, 12, 8),
                DescriptionCourte = "Super soirée danses latines sur Bordeaux",
                DescriptionLongue = "Super soirée danses latines sur Bordeaux",
                Lieu = "L'atelier - Merignac",
            };
            context.Events.AddRange(eventTest, eventTest2);

            // Commit changes into DB
            context.SaveChanges();
        }
    }
}