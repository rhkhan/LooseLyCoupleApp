using AutoMapper;
using LooselyCouple.Model.Models;
using LooseLyCoupleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LooseLyCoupleApp.Mappings
{
   public class ViewModelToDomainProfile:Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
           Mapper.CreateMap<AspRolesFormViewModel, AspRoles>()
                 .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name));
         
        }
    }
}
