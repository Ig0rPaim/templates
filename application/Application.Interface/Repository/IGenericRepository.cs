namespace Application.Interface.Repository;

public interface IGenericRepository<TModel, TConditional> where TModel : class 
{
    Task<IEnumerable<TModel>> Get(TConditional conditional);
    Task<Guid> Update(TModel model);
    Task<Guid> Delete(TModel model);
    Task<Guid> Insert(TModel model);
}