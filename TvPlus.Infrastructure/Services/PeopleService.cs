using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;
using TvPlus.Infrastructure.ViewModels;
using TvPlus.Services.Membership;

namespace TvPlus.Infrastructure.Services
{
    public interface IPeopleService : IPeopleRepository
    {
        People Save(EditPeopleViewModel model);
        EditPeopleViewModel GetPeopleForEdit(int id);
        People FindByFirstAndLastName(string search);
    }
    public class PeopleService : PeopleRepository, IPeopleService
    {
        //private readonly IMembershipManagementBaseService _membershipManagementService;
        private readonly IImageService _imageService;
        public PeopleService(MyDbContext context, IImageService imageService) : base(context)
        {
            _imageService = imageService;
            //_membershipManagementService = membershipManagementService;
        }


        public People Save(EditPeopleViewModel model)
        {
            var people = new People
            {
                Id = model.Id,
                Firstname = model.FirstName,
                Lastname = model.LastName,
                Description = model.Description
            };
            var savedPeople = base.AddOrUpdate(people);
            return savedPeople;
        }

        public EditPeopleViewModel GetPeopleForEdit(int id)
        {
            var people = base.GetById(id);
            var image = _imageService.GetByCenterId(id);
            var vm = new EditPeopleViewModel
            {
                FirstName = people.Firstname,
                LastName = people.Lastname,
                Description = people.Description,
                ImageName = image.ImageName
            };
            return vm;
        }

        public People FindByFirstAndLastName(string search)
        {
            return base.GetDefaultQuery().FirstOrDefault(p =>
                p.Firstname != null && p.Lastname != null &&
                $"{p.Firstname} {p.Lastname}".Trim().ToLower().Equals(search.Trim().ToLower()));
        }
    }
}
