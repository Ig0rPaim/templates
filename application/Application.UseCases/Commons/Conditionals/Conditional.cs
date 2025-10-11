using System.Linq.Expressions;
using Application.Dto.Conditional;
using BinaryExpression = System.Linq.Expressions.BinaryExpression;

namespace Application.UseCases.Commons.Conditionals;

public class Conditional<T>
{
    private List<ConditinalProperties> _properties;

    public Conditional(List<ConditinalProperties> properties)
    {
        _properties = properties ?? throw new ArgumentNullException(nameof(properties));
    }

    public IEnumerable<T> GetConditional(IQueryable<T> parameter)
    {
        var expressionParameter = Expression.Parameter(typeof(T), "p");
    
        Expression combinedBody = Expression.Constant(true);

        foreach (var condition in _properties)
        {
            MemberExpression propertyExpression = Expression.Property(expressionParameter, condition.PropertyName);
        
            object convertedValue = Convert.ChangeType(condition.Value, propertyExpression.Type);
            ConstantExpression constantExpression = Expression.Constant(convertedValue, propertyExpression.Type);
            
            BinaryExpression currentExpression = Expression.MakeBinary(
                condition.ExpressionTypeBetweenPropertyAndValue, 
                propertyExpression, 
                constantExpression
            );

            combinedBody = Expression.MakeBinary(
                condition.ExpressionTypeBetweenConditionals,
                combinedBody, 
                currentExpression
            );
        }
        var lambda = Expression.Lambda<Func<T, bool>>(combinedBody, expressionParameter);

        return parameter.Where(lambda);
    }
}