using Autofac;
using FirstDemo.Infrastructure.Membership;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FirstDemo.Web.Models;

public class RegistrationModel
{
    private ILifetimeScope _scope;
    private UserManager<ApplicationUser> _userManager;
    private SignInManager<ApplicationUser> _signInManager;

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
    public string? ReturnUrl { get; set; }

    internal async Task Register()
    {
        throw new NotImplementedException();
    }

    internal void Resolve(ILifetimeScope scope)
    {
        _scope = scope;
    }

}
