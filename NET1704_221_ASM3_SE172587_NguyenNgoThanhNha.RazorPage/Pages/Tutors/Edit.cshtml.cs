using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Business;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Data.Models;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.RazorPage.Pages.Hubs;
using System.Net.Sockets;

namespace NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.RazorPage.Pages.Tutors
{
    public class EditModel : PageModel
    {
        private readonly TutorBusiness tutorBusiness;
        private readonly IHubContext<TutorHub> _hubContext;

        public EditModel(TutorBusiness tutorBusiness, IHubContext<TutorHub> hubContext)
        {
            this.tutorBusiness = tutorBusiness;
            _hubContext = hubContext;
        }

        [BindProperty] public Tutor Tutor { get; set; }
        [BindProperty] public string idEdit { get; set; }
        [BindProperty] public string idEditPk { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tutorEdit = await tutorBusiness.GetTutorByIdAsync(id);
            if (tutorEdit == null)
            {
                return NotFound();
            }
            Tutor = tutorEdit;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            Tutor.Id = int.Parse(idEditPk);
            Tutor.TutorId = Guid.Parse(idEdit);
            var success = await tutorBusiness.UpdateTutorAsync(Tutor);
            if (success)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveTutorUpdate", Tutor);
                return RedirectToPage("./List");
            }
            return Page();          
        }
    }
}
