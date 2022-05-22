using APICrudWithRepository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrudWithRepository.Models.Repository.Interface
{
    public interface IUser
    {
        Users SignIn(SignInModel model);
        Users SignUp(SignUpModel model);
    }
}
