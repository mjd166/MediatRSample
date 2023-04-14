using MediatR;
using MediatRApisample.Commands;
using MediatRApisample.Models;
using MediatRApisample.Repository;

namespace MediatRApisample.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, StudentDetails>
    {
        private readonly IStudentRepository _studentRepository;
        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentDetails> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentRepository.AddStudentAsync(new StudentDetails
            {
                 StudentAddress= request.StudentAddress,
                 StudentName= request.StudentName,
                 StudentAge= request.StudentAge,
                 StudentEmail= request.StudentEmail,

            });
        }
    }
}
