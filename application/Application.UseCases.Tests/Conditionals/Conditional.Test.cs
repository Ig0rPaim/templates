using System.Linq.Expressions;
using Application.Dto.Conditional;
using Application.UseCases.Commons.Conditionals;
using Domain.Entities;

namespace Application.UseCases.Tests.Conditionals;

public class ConditionalTest
{
    [Fact]
    public void Users()
    {
        #region Arrange
        UserEntity user =
            new(Guid.NewGuid(), "John", "john@example.com", true, null, new List<Role>());
        var users = new List<UserEntity>
        {
            user,
            new(Guid.NewGuid(), "Jane", "jane@example.com", true, null, new List<Role>()),
            new(Guid.NewGuid(), "Doe", "doe@example.com", false, null, new List<Role>()),
            new(Guid.NewGuid(), "Alice", "alice@example.com", true, null, new List<Role>()),
            new(Guid.NewGuid(), "Bob", "bob@example.com", false, null, new List<Role>())
        };
        
        var conditinalProperties = new List<ConditinalProperties>()
        {
            new(nameof(user.Name), ExpressionType.Equal, "John"),
            new(nameof(user.Email), ExpressionType.Equal, "bob@example.com", ExpressionType.Or),
            new(nameof(user.IsActive), ExpressionType.Equal, true, ExpressionType.AndAlso)
        };
        #endregion
        
        #region Act
        var condition = new Conditional<UserEntity>(conditinalProperties);
        var filter = condition.GetConditional(users.AsQueryable());
        #endregion
        
        #region Assert
        Assert.Equal(users.AsQueryable().Where(filter),
            users.Where(u => u.Name.Equals("John") || u.Email.Equals("bob@example.com") && u.IsActive));
        #endregion
    }
}