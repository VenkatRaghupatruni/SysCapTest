namespace ContactProcessor.Models
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            
        }

        public ContactViewModel(string s, string s1, string s2, string s3, string s4)
        {
            FirstName = s;
            LastName = s1;
            PhoneNumber = s2;
            Email = s3;
            FileName = s4;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FileName { get; set; }
    }
}