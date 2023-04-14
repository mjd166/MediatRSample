using MediatR;

public class DeleteStudentCommand : IRequest<int>
{
    public int Id { get; set; }
}