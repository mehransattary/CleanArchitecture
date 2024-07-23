namespace Contracts;

public interface ISmsService
{
    void SendSms(SmsBody smsBody);
}
