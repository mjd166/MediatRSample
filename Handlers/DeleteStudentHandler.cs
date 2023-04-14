using MediatR;
using MediatRApisample.Repository;

namespace MediatRApisample.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var search = await  _studentRepository.GetStudentByIdAsync(request.Id);
            if (search == null) return default;
            return await _studentRepository.DeleteStudentAsync(request.Id);
        }
    }
}
