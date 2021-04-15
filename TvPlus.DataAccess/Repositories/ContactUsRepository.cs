using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TvPlus.Core.Models;

namespace TvPlus.DataAccess.Repositories
{
    public interface IContactUsRepository : IBaseRepository<ContactUs>
    {
        ContactUs GetFirst();
    }
    public class ContactUsRepository : BaseRepository<ContactUs>, IContactUsRepository
    {
        private readonly MyDbContext _context;
        public ContactUsRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public ContactUs GetFirst()
        {
           return _context.ContactUs.FirstOrDefault();
        }

    }
}
