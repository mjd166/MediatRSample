using MediatR;
using MediatRApisample.Models;

namespace MediatRApisample.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentDetails>
    {
        public int Id { get; set; }
    }
}
