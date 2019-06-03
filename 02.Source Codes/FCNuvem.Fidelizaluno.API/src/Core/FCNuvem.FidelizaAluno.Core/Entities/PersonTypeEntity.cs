using FCNuvem.FidelizaAluno.Core.Enums;
using FCNuvem.FidelizaAluno.Framework.Extenders;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FCNuvem.FidelizaAluno.Core.Entities
{
    public class PersonTypeEntity : EntityBase
    {

        public string Description { get; private set; }

        public PersonTypeEntity(int id) : base(id)
        {
            Description = ((EPersonType)id).GetDescription();
        }

    }
}