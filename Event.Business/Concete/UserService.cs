using Event.Business.Abstract;
using Event.Data;
using Event.DataAccsess.Abstract;
using Event.Entities.Concrete;
using Event.Entities.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Event.Entities;
using System.Linq.Expressions;

namespace Event.Business.Concete
{
    public class UserService : IUserService
    {

        private static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        private readonly AppSettings _appSettings;
        private IUserDal _userDal { get; set; }

        public UserService(IUserDal userDal, IOptions<AppSettings> appSettings)
        {
            this._userDal = userDal;
            this._appSettings = appSettings.Value;
        }

        public async Task<User> AddAsync(User Entity)
        {
            return await _userDal.AddSync(Entity);

        }
        public async Task<ServiceResponseModel<User>> AddAsyncWithMessages(User Entity)
        {
            ServiceResponseModel<User> response = new ServiceResponseModel<User>();

            var user = await _userDal.GetAsync(u => u.UserName == Entity.UserName || u.Email == Entity.Email);

            if (user != null)
            {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Errors.Add("hata güzelim");
                errorDto.StatusCode = 400;
                response.Errors.Add(errorDto);
                return response;

            }

            Entity.Password = Encrypt(Entity.Password);
            var result = await _userDal.AddSync(Entity) as User;

            response.Model.Add(result);

            return response;

        }

        public async Task<ServiceResponseModel<User>> Authenticate(string username, string password)
        {

            ServiceResponseModel<User> response = new ServiceResponseModel<User>();

            var result = await _userDal.GetAsync(p => p.UserName == username);

            if (result == null)
            {
                response.Errors.Add(new ErrorDto { StatusCode = 100, Errors = new List<string> { "Kullanıcı bulunamadı." } });
                return response;
            }

            result = await _userDal.GetAsync(p => p.UserName == username && p.Password == Encrypt(password));

            if (result == null)
            {
                response.Errors.Add(new ErrorDto { StatusCode = 100, Errors = new List<string> { "Kullanıcı adı veya Şifre uyuşmamaktadır." } });
                return response;
            }

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

            response.Model.Add(result);

            return response;
        }

        public void Delete(User Entity)
        {
            _userDal.Delete(Entity);
        }

        public void DeleteById(object EntityId)
        {
            _userDal.DeleteById(EntityId);
        }



        public async Task<User> GetAsync(Expression<Func<User, bool>> filter = null)
        {

            return await _userDal.GetAsync(filter);
        }



        public async Task<User> GetByIdAsync(int id)
        {

            return await _userDal.GetByIdAsync(id);
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

        public async Task<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {

            return _userDal.GetAll(filter).ToList();

        }

        public Task<List<Activity>> GetUserWithActivities(int UserId)
        {
            return _userDal.GetUserWithActivities(UserId);
        }
    }
}
