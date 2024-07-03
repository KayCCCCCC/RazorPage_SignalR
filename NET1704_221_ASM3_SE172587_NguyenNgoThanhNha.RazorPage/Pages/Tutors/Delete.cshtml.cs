using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Business;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Data.Models;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.RazorPage.Pages.Hubs;

namespace NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.RazorPage.Pages.Tutors
{
    public class DeleteModel : PageModel
    {
        private readonly TutorBusiness tutorBusiness;
        private readonly IHubContext<TutorHub> _hubContext;

        public DeleteModel(TutorBusiness tutorBusiness, IHubContext<TutorHub> hubContext)
        {
            this.tutorBusiness = tutorBusiness;
            _hubContext = hubContext;
        }

        [BindProperty] public Tutor Tutor { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tutorDelete = await tutorBusiness.GetTutorByIdAsync(id);
            if (tutorDelete == null)
            {
                return NotFound();
            }
            Tutor = tutorDelete;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            bool success = await tutorBusiness.DeleteTutorAsync(id);
            if (success)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveTutorDelete", id);
            }

            return RedirectToPage("./List");
        }
    }
}
