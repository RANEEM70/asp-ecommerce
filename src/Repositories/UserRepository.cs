
using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.Databases;
using CodeCrafters_backend_teamwork.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeCrafters_backend_teamwork.src.Repositories;

public class UserRepository : IUserRepository
{
     private DbSet<User> _users;
     private DatabaseContext _databaseContext;
     public UserRepository(DatabaseContext databaseContext)
     {
          _databaseContext = databaseContext;

          _users = databaseContext.Users;
     }

     public IEnumerable<User> FindMany()
     {
          _databaseContext.SaveChanges();
          return _users;
     }
     public User CreateOne(User user)
     {
          _users.Add(user);
          _databaseContext.SaveChanges();
          return user;
     }

     public User? FindOneByEmail(string email)
     {
          _databaseContext.SaveChanges();
          User? user = _users.FirstOrDefault(user => user.Email == email);
          return user;
     }

     public User UpdateOne(User updatedUser)
     {
          _users.Update(updatedUser);
          _databaseContext.SaveChanges();
          return updatedUser;
     }


     public IEnumerable<User>? DeleteOne(Guid userId)
     {
          User? deleteUser = FindOneById(userId);
          if (deleteUser != null)
          {
               _users.Remove(deleteUser);
               _databaseContext.SaveChanges();
          }

          return _users;
     }

     public User? FindOneById(Guid userId)
     {
          User? user = _users.FirstOrDefault(user => user.Id == userId);
          return user;
     }
}

