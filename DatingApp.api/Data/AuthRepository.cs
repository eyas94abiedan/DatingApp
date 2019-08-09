using System;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.api.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.api.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
           var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
            if(user==null)
            return null;
            
            if(VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
            return user;
            else 
            return null;
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using( var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)){
                var passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < passwordhash.Length; i++)
                {
                    if (passwordHash[i] != passwordhash[i] )
                    return false;
                }
                return true;
            }
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordhash , passwordsalt;
            HashPassword(password,out passwordhash, out passwordsalt);
            user.PasswordHash=passwordhash;
            user.PasswordSalt=passwordsalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;   
        }

        private void HashPassword(string password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
               passwordsalt= hmac.Key;
               passwordhash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == username);
            if(user == null)
                return false;
            return true;

        }
    }
}