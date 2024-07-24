using Domain.Shared;

namespace Domain.Users.ValueObjects;

public class PhoneBook : BaseValueObject
{
    public PhoneNumber TelePhone { get; }
    public PhoneNumber Fax { get; }

    public PhoneBook(PhoneNumber telePhone, PhoneNumber fax)
    {
        TelePhone = telePhone;
        Fax = fax;
    }
}
