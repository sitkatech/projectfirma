namespace LtInfo.Common.Interfaces
{
    public interface IRecaptchaModel
    {
       // ReSharper disable InconsistentNaming
        string recaptcha_challenge_field { get; set; }
        string recaptcha_response_field { get; set; }
       // ReSharper restore InconsistentNaming

        string ClientIP { get; set; }
        string ValidationUrl { get; set; }
        string PrivateKey { get; set; }
        bool IsValid { get; set; }        
    }
}
