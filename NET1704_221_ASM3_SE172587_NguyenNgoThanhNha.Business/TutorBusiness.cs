using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Data.Models;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Business
{
    public class TutorBusiness
    {
        private readonly TutorRepository _tutorRepository;

        public TutorBusiness(TutorRepository tutorRepository)
        {
            _tutorRepository = tutorRepository;
        }

        public async Task<List<Tutor>> GetAllTutorsAsync()
        {
            return await _tutorRepository.GetAllAsync();
        }

        public async Task<Tutor> GetTutorByIdAsync(Guid id)
        {
            return await _tutorRepository.GetOneWithConditionAsync(x => x.TutorId.Equals(id));
        }

        public async Task<Tutor> CreateTutorAsync(Tutor tutor)
        {
            await _tutorRepository.CreateAsync(tutor);
            return tutor;
        }

        public async Task<bool> UpdateTutorAsync(Tutor tutor)
        {
            await _tutorRepository.UpdateAsync(tutor);
            return true;
        }

        public async Task<bool> DeleteTutorAsync(Guid id)
        {
            var tutor = await _tutorRepository.GetOneWithConditionAsync(x => x.TutorId.Equals(id));
            if (tutor != null)
            {
                await _tutorRepository.RemoveAsync(tutor);
                return true;
            }
            return false;
        }
    }
}
