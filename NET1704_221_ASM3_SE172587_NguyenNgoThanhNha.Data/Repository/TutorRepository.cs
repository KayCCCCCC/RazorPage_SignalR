using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Data.Repository
{
    public class TutorRepository : GenericRepository<Tutor>
    {
        public TutorRepository()
        {
            
        }

        public TutorRepository(AppDbContext context) =>  _context = context;
    }
}
