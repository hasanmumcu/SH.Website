using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Data.SqlClient;
using SH.Website.Models;
using System.Collections;

namespace SH.Website.Authentication
{
    public class TokenProvider
    {

        private readonly List<User> UserList;

        public TokenProvider()
        {

            this.UserList = new List<User>();
   
        }
        private static int id = 1;
        static int generateId()
        {
            return id++;
        }
        public List<User> HasRows()
        {
            using (var connection = new SqlConnection( "Server=DESKTOP-7KC40QR\\SQLEXPRESS;Database=SH.WebApp;Integrated Security=True;MultipleActiveResultSets=true"))
            {
                SqlCommand command = new SqlCommand(
                  "SELECT * FROM dbo.Registers;",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        if (reader.GetString(5) == null && reader.GetString(6) == null)
                        {
                            User user = new User

                            {

                                UserId = reader.GetGuid(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                Password = reader.GetString(3),
                                ConfirmPassword = reader.GetString(4),
                                Active = reader.GetBoolean(7),
                                TimeStamp = reader.GetDateTime(8),
                                ACCESS_LEVEL = Roles.USER.ToString(),
                                WRITE_ACCESS = "WRITE_ACCESS"
                            };
                            UserList.Add(user);
                        }
                        else if (reader.GetString(5) != null && reader.GetString(6) != null)
                        {
                            User user = new User

                            {

                                UserId = reader.GetGuid(0),
                                Name = reader.GetString(1),
                                Email = reader.GetString(2),
                                Password = reader.GetString(3),
                                ConfirmPassword = reader.GetString(4),
                                Active = reader.GetBoolean(7),
                                TimeStamp = reader.GetDateTime(8),
                                ACCESS_LEVEL = reader.GetString(5),
                                WRITE_ACCESS = reader.GetString(6)
                            };
                            UserList.Add(user);
                        }
                    }
                }              
                else
                {
                    //
                }
                reader.Close();
            }
            return UserList;

        }
        private IEnumerable GetUserClaims(User user)
        {
            IEnumerable claims = new Claim[]
            {
                 new Claim(ClaimTypes.Name, user.Name),
                 new Claim("USERID", user.UserId.ToString()),
                 new Claim("EMAILID", user.Email),
                 new Claim("PASSWORD", user.Password),
                 new Claim("ACCESS_LEVEL", user.ACCESS_LEVEL.ToUpper()),
                 new Claim("WRITE_ACCESS", user.WRITE_ACCESS.ToUpper())
            };
            return claims;
        }


        public string LoginUser(string Email, string Password)
        {
            //Get user details for the user who is trying to login
            HasRows();
            var user = UserList.SingleOrDefault(x => x.Email == Email);

            //Authenticate User, Check if it’s a registered user in Database
            if (user == null)
                return null;

            //If it's registered user, check user password stored in Database 
            //For demo, password is not hashed. Simple string comparison 
            //In real, password would be hashed and stored in DB. Before comparing, hash the password
            if (Password == user.Password)
            {
                //Authentication successful, Issue Token with user credentials
                //Provide the security key which was given in the JWToken configuration in Startup.cs
                var key = Encoding.ASCII.GetBytes
                          ("YourKey-2374-OFFKDI940NG7:56753253-tyuw-5769-0921-kfirox29zoxv");
                //Generate Token for user 
                var JWToken = new JwtSecurityToken(
                    issuer: "http://localhost:45092/",
                    audience: "http://localhost:45092/",
                    claims: (IEnumerable<Claim>)GetUserClaims(user),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                    //Using HS256 Algorithm to encrypt Token
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                                        SecurityAlgorithms.HmacSha256Signature)
                );
                var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
                return token;
            }
            else
            {
                return null;
            }
        }
    }
}
