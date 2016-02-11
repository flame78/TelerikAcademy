namespace Twitter.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string User { get; set; }
    }
}