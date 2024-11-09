using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_lab12
{
    public class Organization
    {
        public string Name { get; set; }
        public string INN { get; set; }
        public string Email { get; set; }
        public string ReceptionPhone { get; set; }
        public string HRPhone { get; set; }
        public string AccountingPhone { get; set; }

        public Organization() { }

        public Organization(string name, string inn, string email, string receptionPhone, string hrPhone, string accountingPhone)
        {
            Name = name;
            INN = inn;
            Email = email;
            ReceptionPhone = receptionPhone;
            HRPhone = hrPhone;
            AccountingPhone = accountingPhone;
        }

        public override string ToString()
        {
            return $"{Name} (ИНН: {INN}, Email: {Email}, Приемная: {ReceptionPhone}, Отдел кадров: {HRPhone}, Бухгалтерия: {AccountingPhone})";
        }
    }
}
