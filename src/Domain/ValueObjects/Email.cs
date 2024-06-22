namespace Domain.ValueObjects;

public record Email
{
    public string Value { get; private set; }

    public Email(string value)
    {
        if (!IsEmailValid(value))
            throw new InvalidDataException("Email is invalid");

        Value = value.Trim().ToLower();
    }

    bool IsEmailValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;
        if (!value.Contains('@'))
            return false;
        if (value.EndsWith("."))
            return false;

        try
        {
            var addr = new System.Net.Mail.MailAddress(value);
            return addr.Address == value.Trim();
        }
        catch
        {
            return false;
        }
    }
}
