using UserRegistration.Models;
using UserRegistration.Data;
using Microsoft.EntityFrameworkCore;

namespace UserRegistration.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly DataContext _context;
        public UserServices(DataContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<User?> GetSingleUser(string id)
        {
            User? user = await _context.Users.FindAsync(id);
            return user;
        }
        public async Task<bool> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateUser(string id, User request)
        {
            User? user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.Name = request.Name;
                user.SurName = request.SurName;
                user.Age = request.Age;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteUser(string id)
        {
            User? user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}