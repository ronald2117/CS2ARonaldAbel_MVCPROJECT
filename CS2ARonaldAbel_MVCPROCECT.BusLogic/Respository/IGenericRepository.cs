

namespace CS2ARonaldAbel_MVCPROCECT.BusLogic.Respository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
    }
}
