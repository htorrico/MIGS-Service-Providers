using Common;

namespace Service.Base
{
    public interface IBaseCrud<T> where T : class, new()
    {

        public EResponseBase<T> Get();
        public EResponseBase<T> GetById(int id);
        public EResponseBase<T> InsertOrUpdate(T model, int? Id);

    }
}
