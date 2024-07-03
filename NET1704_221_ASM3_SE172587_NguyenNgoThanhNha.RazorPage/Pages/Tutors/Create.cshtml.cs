using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Business;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Data.Models;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.RazorPage.Pages.Hubs;
using System.Net.Sockets;

namespace NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.RazorPage.Pages.Tutors
{
    public class CreateModel : PageModel
    {
        private readonly TutorBusiness _tutorBusiness;
        private readonly IHubContext<TutorHub> _hubContext;

        public CreateModel(TutorBusiness tutorBusiness, IHubContext<TutorHub> hubContext)
        {
            _tutorBusiness = tutorBusiness;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Tutor Tutor { get; set; } = new Tutor();

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Tutor.TutorId = Guid.NewGuid();
            var createdTutor = await _tutorBusiness.CreateTutorAsync(Tutor);
            await _hubContext.Clients.All.SendAsync("ReceiveTutorCreate", createdTutor);
            return RedirectToPage("./Create");
        }
    }
}
