namespace LibraryManager.Api.Domain.Entity
{
    public class Base
    {
        public int Id { get; private set; }
        public bool IsDeleted { get; private set; }

        public Base()
        {

        }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
