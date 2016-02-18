namespace LibrarySystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using LibrarySystem.Common;
    using LibrarySystem.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
