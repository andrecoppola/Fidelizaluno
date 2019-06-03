using FCNuvem.FidelizaAluno.API.Models.Interfaces;
using FCNuvem.FidelizaAluno.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.ViewModels.User
{
    public class UserViewModel : IViewModelAdapter<UserEntity>
    {

        public string DisplayName { get; set; }
        public string Login { get; set; }


        public void Bind(UserEntity model)
        {
            throw new NotImplementedException();
        }

        public void Fill(UserEntity model)
        {

            if (model == null)
                return;

            Login = model.Login;
            DisplayName = model.DisplayName;
        }
    }
}
