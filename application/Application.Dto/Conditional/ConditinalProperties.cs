using System.Linq.Expressions;

namespace Application.Dto.Conditional;

public class ConditinalProperties
{
    public string PropertyName { get; private set; }
    public System.Linq.Expressions.ExpressionType ExpressionTypeBetweenPropertyAndValue { get; private set; }
    public object Value { get; private set; }
    public System.Linq.Expressions.ExpressionType ExpressionTypeBetweenConditionals { get; private set; }

    public ConditinalProperties(string propertyName, ExpressionType expressionTypeBetweenPropertyAndValue, object value,
        ExpressionType expressionTypeBetweenConditionals)
    {
        PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        ExpressionTypeBetweenPropertyAndValue = expressionTypeBetweenPropertyAndValue;
        Value = value ?? throw new ArgumentNullException(nameof(value));
        ExpressionTypeBetweenConditionals = expressionTypeBetweenConditionals;
    }
}