using System;

namespace _01_Framework.Domain
{
    public class DomainBase<T>
    {
        public T Id { get; private set; }
        public DateTime CreationDate { get; private set; }

        public DomainBase()
        {
            CreationDate = DateTime.Now;
        }
    }
}
