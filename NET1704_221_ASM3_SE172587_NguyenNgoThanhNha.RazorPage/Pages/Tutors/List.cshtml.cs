using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Business;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Data.Models;
using System.Net.Sockets;

namespace NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.RazorPage.Pages.Tutors
{
    public class ListModel : PageModel
    {
        private readonly TutorBusiness tutorBusiness;

        public ListModel(TutorBusiness tutorBusiness)
        {
            this.tutorBusiness = tutorBusiness;
        }

        [BindProperty]
        public IList<Tutor> Tutors { get; set; } = new List<Tutor>();

        public async Task OnGetAsync()
        {
            var tutors = await tutorBusiness.GetAllTutorsAsync();
            Tutors =  tutors.OrderByDescending(t => t.Id).ToList();
        }
    }
}
