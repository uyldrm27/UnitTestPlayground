using Infrastructure;
using Infrastructure.Models;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace UnitTests
{
    public class UserRepositoryTests
    {
        private readonly IUserRepository _userRepository;
        public UserRepositoryTests()
        {
            DbContextOptions<Context> options;
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseInMemoryDatabase("UnitTestDb");
            options = builder.Options;
            Context context = new Context(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            _userRepository = new UserRepository(context);
        }
        [Fact]
        public void TestAddUser()
        {
            var user = GetUserObj();
            Assert.Empty(_userRepository.GetAll());
            _userRepository.Create(user);
            Assert.Single(_userRepository.GetAll());
        }
        [Fact]
        public void TestDeleteUser()
        {
            var user = GetUserObj();
            _userRepository.Create(user);
            Assert.Single(_userRepository.GetAll());
            _userRepository.Delete(user);
            Assert.Empty(_userRepository.GetAll());
        }
        [Fact]
        public void TestUpdateUser() 
        {
            var user = GetUserObj();
            _userRepository.Create(user);
            user.Name= "Uğur Can";
            _userRepository.Update(user);
            Assert.Equal("Uğur Can", _userRepository.Get(1).Name);
        }
        [Fact]
        public void TestGetAll()
        {
            var user = GetUserObj();    
            _userRepository.Create(user);
            Assert.Single(_userRepository.GetAll());
        }
        [Fact]
        public void TestGet()
        {
            var user = GetUserObj();
            _userRepository.Create(user);
            var userFromDb = _userRepository.Get(1);
            Assert.Equivalent(user, userFromDb);
        }
        private User GetUserObj()
        {
            return new User()
            {
                Age = 28,
                Email = "ugur.yildirim@avl.com",
                Id = 1,
                Name = "Uğur",
                Surname = "Yıldırım"
            };
        }
    }
}
