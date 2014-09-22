namespace Exam.WebServices.Controllers
{
    using System.Web.Http;

    using Exam.DAL;

    public class BaseApiController : ApiController
    {
        protected IExamData Data;

        public BaseApiController() : this(new ExamData())
        {
        }

        public BaseApiController(IExamData data)
        {
            this.Data = data;
        }
    }
}