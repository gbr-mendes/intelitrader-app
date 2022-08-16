using UserRegistration.Models;
using UserRegistration.Data;
using Microsoft.EntityFrameworkCore;
using UserRegistration.Dtos.User;
using AutoMapper;

namespace UserRegistration.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetUserDto>> GetUsers()
        {
            List<User> users = await _context.Users.ToListAsync();
            return users.Select(user => _mapper.Map<GetUserDto>(user)).ToList();
        }
        public async Task<GetUserDto> GetSingleUser(string id)
        {
            User user = await _context.Users.FindAsync(id);
            return _mapper.Map<GetUserDto>(user);
        }
        public async Task<bool> AddUser(AddUserDto user)
        {
            _context.Users.Add(_mapper.Map<User>(user));
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