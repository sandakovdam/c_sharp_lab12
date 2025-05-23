namespace OrgDirectoryApi.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string INN { get; set; }
        public string Email { get; set; }
        public string ReceptionPhone { get; set; }
        public string HRPhone { get; set; }
        public string AccountingPhone { get; set; }
    }
}