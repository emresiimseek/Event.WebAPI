using Event.Business.Abstract;
using Event.Data;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Event.Business.Concete
{
    public class UserService : IUserService
    {

        public static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        private readonly AppSettings _appSettings;
        public IUserDal _userDal { get; set; }

        public UserService(IUserDal userDal, IOptions<AppSettings> appSettings)
        {
            this._userDal = userDal;
            this._appSettings = appSettings.Value;
        }

        public async Task<User> AddAsync(User Entity)
        {
            Entity.Password = Encrypt(Entity.Password);
            return await _userDal.AddSync(Entity) as User;
        }

        public async Task<User> Authenticate(string username, string password)
        {
            var result = await _userDal.GetAsync(p => p.UserName == username && p.Password == Encrypt(password));
            if (result == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim("id", result.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            result.Token = tokenHandler.WriteToken(token);
            result.Password = null;
            return result;
        }

        public void Delete(User Entity)
        {
            _userDal.Delete(Entity);
        }

        public void DeleteById(object EntityId)
        {
            _userDal.DeleteById(EntityId);
        }

        public IEnumerable<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public Task<User> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id)
        {
            return _userDal.GetByIdAsync(id);
        }

        public void Update(User Entity)
        {
            _userDal.Update(Entity);
        }

        public string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        public string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
    }
}
