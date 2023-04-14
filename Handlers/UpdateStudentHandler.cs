using MediatR;
using MediatRApisample.Models;
using MediatRApisample.Repository;

namespace MediatRApisample.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var search=await _studentRepository.GetStudentByIdAsync(request.Id);
            if (search == null) return default;

            return await _studentRepository.UpdateStudentAsync(new StudentDetails
            {
                Id = request.Id,
                StudentAddress = request.StudentAddress,
                StudentAge = request.StudentAge,
                StudentEmail = request.StudentEmail,
                StudentName = request.StudentName,

            });
        }
    }
}
