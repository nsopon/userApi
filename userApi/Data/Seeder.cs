using AutoFixture;
using userApi.Model;

namespace userApi.Data
{
    public static class Seeder
    {
        // This is purely for a demo, don't anything like this in a real application!
        public static void Seed(this UserApiDbContext userApiDbContext)
        {
            if (!userApiDbContext.Users.Any())
            {
                Fixture fixture = new Fixture();
                fixture.Customize<User>(user => user.Without(p => p.Id));
                //--- The next two lines add 100 rows to your database
                List<User> users = fixture.CreateMany<User>(100).ToList();
                userApiDbContext.AddRange(users);
                userApiDbContext.SaveChanges();
            }
        }
    }
}
