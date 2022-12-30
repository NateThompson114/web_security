using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Account;

public class Login : PageModel
{
    [BindProperty]
    public Credential Credential { get; set; }
    public void OnGet()
    {
        
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if(!ModelState.IsValid) return Page();

        if (Credential.UserName != "admin" || Credential.Password != "password") return Page();
        
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            new(ClaimTypes.Name, "admin"),
            new(ClaimTypes.Email, "admin@mywebsite.com")
        };

        var identity = new ClaimsIdentity(claims, "MyCookie");
        var claimsPrincipal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync("MyCookie",claimsPrincipal);

        return RedirectToPage("/Index");
    }
}

public class Credential
{
    [Required] 
    public string UserName { get; set; } = string.Empty;

    [Required, DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}