using MediatR;
using MediatRApisample.Commands;
using MediatRApisample.Models;
using MediatRApisample.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatRApisample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetStudentListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetStudentByIdQuery() {Id=id }));
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] StudentDetails studentDetails)
        {
            var createstudentcmd = new CreateStudentCommand(studentDetails.StudentName, studentDetails.StudentEmail, studentDetails.StudentAddress, studentDetails.StudentAge); 
            return Ok(await _mediator.Send(createstudentcmd));
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StudentDetails studentDetails)
        {
            var updatestudentcmd = new UpdateStudentCommand(studentDetails.Id, studentDetails.StudentName, studentDetails.StudentEmail, studentDetails.StudentAddress, studentDetails.StudentAge);
           return Ok( await _mediator.Send(updatestudentcmd));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteStudentCommand()
            {
                Id = id
            }));
        }
    }
}
