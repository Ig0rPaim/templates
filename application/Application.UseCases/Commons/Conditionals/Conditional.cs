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
        if(_properties.Count <= 0) throw new ArgumentException("The properties list cannot be empty", nameof(properties));
    }

    public Expression<Func<T, bool>> GetConditional(IQueryable<T> model)
    {
        if (model == null) throw new ArgumentNullException(nameof(model));
        
        var expressionParameter = Expression.Parameter(typeof(T), "p");

        Expression combinedBody = null;

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

            combinedBody = combinedBody is null ? currentExpression :  Expression.MakeBinary(
                condition.ExpressionTypeBetweenConditionals,
                combinedBody, 
                currentExpression
            );  
            
        }
        return Expression.Lambda<Func<T, bool>>(combinedBody, expressionParameter);
    }
}