using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DapperDbContext _dbContext;

    public UserRepository(DapperDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();
        // insert into postgres db using sql
        string query = "INSERT INTO public.\"Users\"(\"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\") VALUES(@UserID, @Email, @PersonName, @Gender, @Password)";
        
       int rowsAffectedCount = await _dbContext.DbConnection.ExecuteAsync(query, user);
       
       if (rowsAffectedCount > 0)
       {
           return user;
       }
       else
       {
           return null;
       }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string email, string password)
    {
        // this is for learning. Use other identity framework for this
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";
       // string query = "SELECT \"UserID\", \"Email\", \"PersonName\", \"Gender\", \"Password\"  FROM public.\"Users\" WHERE \"Email\" = @Email AND \"Password\" = @Password";

       var parameters = new { Email = email, Password = password };
       var user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
       
       return user;
    }
}