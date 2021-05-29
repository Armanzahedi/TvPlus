using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvPlus.Core.Models;
using TvPlus.DataAccess;
using TvPlus.DataAccess.Repositories;

namespace TvPlus.Infrastructure.Services
{
    public interface IDiscountService : IDiscountRepository
    {
        string GenerateRandomCode();
    }
    public class DiscountService : DiscountRepository, IDiscountService
    {
        private readonly MyDbContext _context;
        public DiscountService(MyDbContext context) : base(context)
        {
            _context = context;
        }

        public string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var code = new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            if (_context.Discounts.Any(d => d.Code == code))
                GenerateRandomCode();

            return code;
        }
    }
}
