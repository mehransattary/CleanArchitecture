namespace Domain.Shared;

public class Money : BaseValueObject
{
    /// <summary>
    /// Rial
    /// </summary>
    public int Value { get; }

    public Money(int rialValue)
    {
        if (rialValue < 0)
            throw new InvalidDataException();

        Value = rialValue;
    }

    public static Money FromRial(int value)
    {
        return new Money(value);
    }
    public static Money FromTooman(int value)
    {
        return new Money(value * 10);
    }

    public static Money operator +(Money firstMony, Money mony2)
    {
        return new Money(firstMony.Value + mony2.Value);
    }

    public override string ToString()
    {
        return Value.ToString("#,0");
    }

    public static Money operator -(Money firstMony, Money mony2)
    {
        return new Money(firstMony.Value - mony2.Value);
    }
}
