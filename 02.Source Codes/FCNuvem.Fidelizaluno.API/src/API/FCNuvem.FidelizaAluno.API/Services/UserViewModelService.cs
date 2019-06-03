using FCNuvem.FidelizaAluno.API.ViewModels.User;
using FCNuvem.FidelizaAluno.Core.Repository.ReadOnly;
using FCNuvem.FidelizaAluno.Framework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCNuvem.FidelizaAluno.API.Services
{
    public class UserViewModelService : BaseViewModelService
    {
        public UserViewModelService(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private IUserReadOnlyRepository UserReadOnlyRepository => GetService<IUserReadOnlyRepository>();

        public UserViewModel ValidateLogin(string email)
        {
            var entity = UserReadOnlyRepository.Get(email);

            if (entity == null)
                throw new NotFoundException();

            var model = new UserViewModel();

            model.Fill(entity);
            return model;
        }
    }
}
