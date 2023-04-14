using MediatR;
using MediatRApisample.Models;

namespace MediatRApisample.Queries
{
    public class GetStudentListQuery :IRequest<List<StudentDetails>>
    {

    }
}
