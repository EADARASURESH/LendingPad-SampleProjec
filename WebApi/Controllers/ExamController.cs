using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Exams;
using WebApi.Models.Exams;

namespace WebApi.Controllers
{
    [RoutePrefix("exams")]
    public class ExamController : BaseApiController
    {
        private readonly ICreateExamService _createExamService;
        private readonly IDeleteExamService _deleteExamService;
        private readonly IGetExamService _getExamService;
        private readonly IUpdateExamService _updateExamService;

        public ExamController(ICreateExamService createExamService, IDeleteExamService deleteExamService, IGetExamService getExamService, IUpdateExamService updateExamService)
        {
            _createExamService = createExamService;
            _deleteExamService = deleteExamService;
            _getExamService = getExamService;
            _updateExamService = updateExamService;
        }

        [Route("{examId:guid}/create")]
        [HttpPost]
        public HttpResponseMessage CreateExam(Guid examId, [FromBody] ExamModel model)
        {
            var exam = _createExamService.Create(examId, model.Title, model.Description, model.DurationMinutes, model.MaxScore);
            return Found(new ExamData(exam));
        }

        [Route("{examId:guid}/update")]
        [HttpPost]
        public HttpResponseMessage UpdateExam(Guid examId, [FromBody] ExamModel model)
        {
            var exam = _getExamService.GetExam(examId);
            if (exam == null)
            {
                return DoesNotExist();
            }
            _updateExamService.Update(exam, model.Title, model.Description, model.DurationMinutes, model.MaxScore);
            return Found(new ExamData(exam));
        }

        [Route("{examId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteExam(Guid examId)
        {
            var exam = _getExamService.GetExam(examId);
            if (exam == null)
            {
                return DoesNotExist();
            }
            _deleteExamService.Delete(exam);
            return Found();
        }

        [Route("{examId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetExam(Guid examId)
        {
            var exam = _getExamService.GetExam(examId);
            return Found(new ExamData(exam));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetExams(int skip, int take, string title = null)
        {
            var exams = _getExamService.GetExams(title)
                                       .Skip(skip).Take(take)
                                       .Select(q => new ExamData(q))
                                       .ToList();
            return Found(exams);
        }

        [Route("clear")]
        [HttpDelete]
        public HttpResponseMessage DeleteAllExams()
        {
            _deleteExamService.DeleteAll();
            return Found();
        }

        [Route("list/title")]
        [HttpGet]
        public HttpResponseMessage GetExamsByTitle(string title)
        {
            var exams = _getExamService.GetExams(title);
            return Found(exams);
        }
    }
}
