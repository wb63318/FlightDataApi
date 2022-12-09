
using FlightDataApi.Models;

namespace FlightDataApi.Repos
{
    public class StaticUserRepository : IUserRepository
    {
       /* private readonly FlightDataDbContext flightData;

       *//* public StaticUserRepository(FlightDataDbContext flightData)
        {
            this.flightData = flightData;
        }*/

        private List<User> Users = new List<User>() 
        {
            new User()
            {
                Name= "Test",EmailAddress="testuser1@flight.com",UserName="TestUser",Id = Guid.NewGuid(),Password="TestpassWord"
            },
            new User()
            {
                Name = "Admin",EmailAddress="admin@flight.com",UserName="TestAdmin",Id=Guid.NewGuid(),Password="TestAdminpaSS"
            }
        };
        public async Task<User> AuthenticateAsync(string username, string password)
        {
           var user = Users.Find(x => x.UserName.Equals(username,StringComparison.InvariantCultureIgnoreCase)&& 
               x.Password == password);
            return user;
        }
    }
}
