using CourseSignUp.Domain.Uow;

namespace CourseSignUp.Application
{
    public class BaseAppService
    {
        private readonly IUnitOfWork _uow;

        public BaseAppService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Commit()
        {
            _uow.Commit();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
