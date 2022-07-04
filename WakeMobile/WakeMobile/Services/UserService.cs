using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WakeMobile.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Linq;

namespace WakeMobile.Services
{
    public class UserService : IUserService
    {
        HttpClient _httpClient = new HttpClient() { BaseAddress = new Uri("https://localhost:7099/api/") };
        private readonly IHttpContextAccessor _context;

        public UserService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "Users/Register", content).Result;

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return user;
        }

        public bool DeleteUser(int id)
        {
            HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + "Users/" + id).Result;

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }

        public User EditUser(int id, User user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "Users/" + id, content).Result;

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            return user;
        }

        public User GetUserById(int id)
        {
            if (id == 0)
            {
                return null;
            }

            User user = new User();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Users/" + id).Result;

            if(response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(data);
            }

            if(user == null)
            {
                return null;
            }

            return user;
        }

        public bool LoginUser(UserLogin userLogin)
        {
            string data = JsonConvert.SerializeObject(userLogin);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "Users/LoginUser", content).Result;

            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                userLogin = JsonConvert.DeserializeObject<UserLogin>(data);

                List<Claim> accessDirect = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, userLogin.Id.ToString()),
                    new Claim(ClaimTypes.Name, userLogin.UserName)
                };

                var identity = new ClaimsIdentity(accessDirect, CookieAuthenticationDefaults.AuthenticationScheme);
                var userMain = new ClaimsPrincipal(identity);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddHours(8),
                    IssuedUtc = DateTime.Now
                };

                var userSession = _context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userMain, authProperties);

                return true;
            }

            return false;
        }

        public int GetUserId()
        {
            var user = _context.HttpContext.User.Claims.Where(u => u.Type == ClaimTypes.NameIdentifier).Select(x => x.Value);
            int idUser;

            try
            {
                if (user == null)
                {
                    idUser = 0;
                }
                else
                {
                    idUser = int.Parse(user.Last());
                }
            }
            catch (Exception ex)
            {
                idUser = 0;
            }

            return idUser;
        }

        public string GetUserName()
        {
            var user = _context.HttpContext.User.Claims.Where(u => u.Type == ClaimTypes.Name).Select(x => x.Value);
            string userName = "";
            try
            {
                userName = user.Last();

                return userName;
            }
            catch (Exception ex)
            {
                userName = "";
            }

            return userName;
        }

    }
}
