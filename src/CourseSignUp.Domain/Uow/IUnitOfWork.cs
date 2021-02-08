namespace CourseSignUp.Domain.Uow
{
    public interface IUnitOfWork
    {
        bool Commit();
        void Dispose();
    }
}
