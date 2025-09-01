using CodeFirstRelation.Models;
using Microsoft.EntityFrameworkCore;
using PatikaCodeFirstRelation.Data;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new PatikaSecondDbContext())
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var user1 = new User { Username = "eren", Email = "eren@gmail.com" };
                var user2 = new User { Username = "patikaUser", Email = "patikaUser@gmail.com" };

                // Post ekleme
                user1.Posts.Add(new Post { Title = "Eren'in İlk Postu", Content = "erenContent1" });
                user1.Posts.Add(new Post { Title = "Eren'in İkinci Postu", Content = "erenContent2" });
                user2.Posts.Add(new Post { Title = "patikaUser'ın İlk Postu", Content = "patikaUserContent1" });

                context.Users.AddRange(user1, user2);
                context.SaveChanges();
            }

            // Console'a yazdırma
            Console.WriteLine("----- Users ve Postları -----");
            foreach (var user in context.Users.Include(u => u.Posts).ToList())
            {
                Console.WriteLine($"User: {user.Username} ({user.Email})");
                foreach (var post in user.Posts)
                {
                    Console.WriteLine($"   Post: {post.Title} - {post.Content}");
                }
            }
        }
    }
}
