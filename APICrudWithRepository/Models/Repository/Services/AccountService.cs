using APICrudWithRepository.Contracts;
using APICrudWithRepository.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrudWithRepository.Models.Repository.Services
{
    public class AccountService : IUser
    {
        private readonly ApplicationDbContext dbContext;
        public AccountService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Users SignIn(SignInModel model)
        {
            var user = dbContext.Users.SingleOrDefault(e => e.Email == model.Email && e.Password == model.Password);
            if(user!=null)
            {
                return user;
            }
            else
            {
                return null;
            }
            

        }

        public Users SignUp(SignUpModel model)
        {
            var user = new Users()
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                Gender = model.Gender
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }
    }
}
