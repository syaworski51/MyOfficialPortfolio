namespace MyOfficialPortfolio.Models.InputForms
{
    public class ContactForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Company { get; set; }
        public string? JobTitle { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string PreferredContactMethod { get; set; }
        public string Message { get; set; }
        public bool AgreedToPrivacyPolicy { get; set; }
    }
}