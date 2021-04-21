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
using TvPlus.Utility.Enums;

namespace TvPlus.Infrastructure.Services
{
    public interface IPeopleService : IPeopleRepository
    {
        People Save(EditPeopleViewModel model);
        EditPeopleViewModel GetPeopleForEdit(int id);
        People FindByFirstAndLastName(string search);
        List<PeopleDetailViewModel> GetPostPeople(int postId);
    }
    public class PeopleService : PeopleRepository, IPeopleService
    {
        private readonly IMembershipManagementBaseService _membershipManagementService;
        private readonly IImageService _imageService;
        private readonly MyDbContext _context;
        public PeopleService(MyDbContext context, IImageService imageService, IMembershipManagementBaseService membershipManagementService) : base(context)
        {
            _imageService = imageService;
            _context = context;
            _membershipManagementService = membershipManagementService;
        }


        public People Save(EditPeopleViewModel model)
        {
            var people = new People
            {
                Id = model.Id,
                Firstname = model.FirstName,
                Lastname = model.LastName,
                Description = model.Description,
                CenterTypeId = (int)CenterTypes.People,
                UniqueId = new Guid()
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

        public List<PeopleDetailViewModel> GetPostPeople(int postId)
        {
            var model = new List<PeopleDetailViewModel>();
            var peopleIds = _membershipManagementService.GetMemberships(postId, RelationTypes.PostPeople, false, false)
                .Select(s => s.CenterId).ToList();

            var people = _context.People.Where(w => peopleIds.Contains(w.Id)).ToList();
            foreach (var item in people)
            {
                var image = _imageService.GetByCenterId(item.Id);
                model.Add(new PeopleDetailViewModel
                {
                    Id = item.Id,
                    FirstName = item.Firstname,
                    LastName = item.Lastname,
                    Description = item.Description,
                    ImageName = image?.ImageName ?? "temp.png"
                });
            }

            return model;
        }
    }
}
