using Application.Dto.Conditional;
using Application.Interface.Repository;
using Application.UseCases.Commons.Conditionals;

namespace Application.UseCases.User.Queries.GetUserQuery;

public class GetUserHandler
{
    private readonly IGenericRepository<Domain.Entities.UserEntity,Conditional<Domain.Entities.UserEntity>> _repository;
    private readonly GetUserQuery _query;
    
    public GetUserHandler(GetUserQuery query, IGenericRepository<Domain.Entities.UserEntity,Conditional<Domain.Entities.UserEntity>> repository)
    {
        _query = query;
        _repository = repository;
    }

    public Task Execute(List<ConditinalProperties> properties)
    {
        var conditional = new Conditional<Domain.Entities.UserEntity>(properties);
        return _repository.Get(conditional);
    }
}