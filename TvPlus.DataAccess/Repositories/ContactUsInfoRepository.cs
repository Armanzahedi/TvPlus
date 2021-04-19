using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using TvPlus.Core.Models;
using TvPlus.Utility.Enums;

namespace TvPlus.DataAccess.Repositories
{
    public interface IContactUsInfoRepository : IBaseRepository<ContactUsInfo>
    {
        ContactUsInfo GetFirst();
    }
    public class ContactUsInfoRepository : BaseRepository<ContactUsInfo>, IContactUsInfoRepository
    {
        private readonly MyDbContext _context;
        public ContactUsInfoRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public ContactUsInfo GetFirst()
        {
            return _context.ContactUsInfoes.FirstOrDefault();
        }
    }
}
