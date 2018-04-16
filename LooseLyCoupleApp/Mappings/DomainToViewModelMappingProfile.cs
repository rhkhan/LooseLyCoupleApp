using AutoMapper;
using LooselyCouple.Model.Models;
using LooseLyCoupleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LooseLyCoupleApp.Mappings
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public override string ProfileName
        {
            get
            {
                 return "DomainToViewModelMappings"; 
            }
        }

        protected override void Configure()
        {
            //throw new NotImplementedException();
            Mapper.CreateMap<AspRoles, AspRolesViewModel>();
        }
    }
}
