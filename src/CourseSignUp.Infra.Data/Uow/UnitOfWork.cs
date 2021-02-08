using System;
using System.Diagnostics;
using CourseSignUp.Domain.Uow;
using CourseSignUp.Infra.Data.Context;

namespace CourseSignUp.Infra.Data.Uow
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly CourseSignUpContext _context;

        public UnitOfWork(CourseSignUpContext context)
        {
            _context = context;
        }


        public bool Commit()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
