namespace _01_Framework.Infrastructure
{
    public interface IUnitOfWork
    {
        void BeginTran();
        void CommitTran();
        void RollBack();
    }
}
