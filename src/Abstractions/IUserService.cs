
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;

namespace CodeCrafters_backend_teamwork.src.Abstractions
{
    public interface IUserService
    {
        public IEnumerable<UserReadDto> FindMany();
        public UserReadDto SignUp(UserCreateDto user);
        public string SignIn(UserSignIn user);
        public UserReadDto? FindOneByEmail(string email);
        public User UpdateOne(string email, User newValue);
        public UserReadDto FindOneById(Guid id);
        public IEnumerable<User> DeleteOne(Guid userId);
    }
}
