#!/bin/bash

NAME=Campus
PROJETO=${PWD##*/}


touch src/core/${PROJETO}.Core/Repository/I${NAME}Repository.cs
touch src/core/${PROJETO}.Core/Entities/${NAME}Entity.cs
touch src/core/${PROJETO}.Core/Repository/ReadOnly/I${NAME}ReadOnlyRepository.cs
touch src/core/${PROJETO}.Core/Services/${NAME}Service.cs
touch src/core/${PROJETO}.Infraestructure/Repositories/${NAME}Repository.cs
# touch src/core/${PROJETO}.Infraestructure/Repositories/Mappings/${NAME}EntityMap.cs
touch src/ui/${PROJETO}.API/Services/${NAME}ViewModelService.cs
touch src/ui/${PROJETO}.API/Controllers/${NAME}Controller.cs

echo "using ${PROJETO}.Core.Entities;
using ${PROJETO}.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace ${PROJETO}.Core.Repository
{
    public interface I${NAME}Repository : IRepository<${NAME}Entity>, I${NAME}ReadOnlyRepository
    {
    }
}" > src/core/${PROJETO}.Core/Repository/I${NAME}Repository.cs

echo "using ${PROJETO}.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ${PROJETO}.Core.Repository.ReadOnly
{
    public interface I${NAME}ReadOnlyRepository : IReadOnlyRepository<${NAME}Entity>
    {
    }
}" > src/core/${PROJETO}.Core/Repository/ReadOnly/I${NAME}ReadOnlyRepository.cs


echo "

namespace ${PROJETO}.Core.Entities
{

    public class ${NAME}Entity : EntityBase
    {
        public ${NAME}Entity(int id) 
            : base(id)
        {}

    }
}
" > src/core/${PROJETO}.Core/Entities/${NAME}Entity.cs

echo "using ${PROJETO}.Core.Entities;
using ${PROJETO}.Core.Repository;
using ${PROJETO}.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace ${PROJETO}.Infrastructure.Repositories
{
    internal class ${NAME}Repository : RepositoryBase<${NAME}Entity>, I${NAME}Repository
    {
        public ${NAME}Repository(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}
    }
}" > src/core/${PROJETO}.Infraestructure/Repositories/${NAME}Repository.cs


echo "using ${PROJETO}.Core.Entities;
using ${PROJETO}.Core.Repository;
using ${PROJETO}.Core.Repository.ReadOnly;
using System;
using System.Collections.Generic;
using System.Text;

namespace ${PROJETO}.Core.Services
{
    public class ${NAME}Service : ServiceBase
    {
        public ${NAME}Service(IServiceProvider serviceProvider) 
            : base(serviceProvider)
        {}

        private I${NAME}Repository ${NAME}Repository => GetService<I${NAME}Repository>();
        private I${NAME}ReadOnlyRepository ${NAME}ReadOnlyRepository => GetService<I${NAME}ReadOnlyRepository>();


        public void Save(${NAME}Entity alunoEntity)
        {
            ${NAME}Repository.Save(alunoEntity);
        }
    }
}" > src/core/${PROJETO}.Core/Services/${NAME}Service.cs


# echo "
# using ${PROJETO}.Core.Entities;
# using ${PROJETO}.Infrastructure.Repositories.Mappings;
# using System;
# using System.Collections.Generic;
# using System.Text;

# namespace ${PROJETO}.Infraestructure.Repositories.Mappings
# {
#     internal class ${NAME}EntityMap : EntityMapConfiguration<${NAME}Entity>
#     {
#         protected override void OnMapping()
#         {
           
#         }
#     }
# }
# " > src/core/${PROJETO}.Infraestructure/Repositories/Mappings/${NAME}EntityMap.cs

echo "using ${PROJETO}.API.ViewModels.${NAME};
using ${PROJETO}.Core.Entities;
using ${PROJETO}.Core.Entities.OwnedTypes;
using ${PROJETO}.Core.Repository;
using ${PROJETO}.Core.Repository.ReadOnly;
using ${PROJETO}.Core.Services;
using System;


namespace ${PROJETO}.API.Services
{
    public class ${NAME}ViewModelService : BaseViewModelService
    {
        public ${NAME}ViewModelService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        private ${NAME}Service ${NAME}Service => GetService<${NAME}Service>();
        private I${NAME}ReadOnlyRepository ${NAME}ReadOnlyRepository => GetService<I${NAME}ReadOnlyRepository>();

        public void Save(${NAME}ViewModel vm)
        {
            var entity = new ${NAME}Entity(0);
            vm.Bind(entity);
            ${NAME}Service.Save(entity);
        }
    }
}" > src/ui/${PROJETO}.API/Services/${NAME}ViewModelService.cs

echo "using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ${PROJETO}.API.Services;
using ${PROJETO}.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ${PROJETO}.API.Controllers
{
    [Route(\"api/[controller]\")]
    [ApiController]
    public class ${NAME}Controller : APIBaseController
    {
        ${NAME}ViewModelService ViewModelService => GetService<${NAME}ViewModelService>();

    }
}" > src/ui/${PROJETO}.API/Controllers/${NAME}Controller.cs