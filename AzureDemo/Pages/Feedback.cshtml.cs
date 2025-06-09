using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

public class FeedbackModel : PageModel
{
    private readonly MyDbContext _context;
    private readonly EventHubService _eventHubService;

    public FeedbackModel(MyDbContext context, EventHubService eventHubService)
    {
        _context = context;
        _eventHubService = eventHubService;
    }

    [BindProperty]
    public Feedback Feedback { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.Feedbacks.Add(Feedback);
        await _context.SaveChangesAsync();

        // Send feedback to Event Hub
        var feedbackJson = JsonSerializer.Serialize(Feedback);
        await _eventHubService.SendMessageAsync(feedbackJson);

        return RedirectToPage("Success");
    }
}