using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace c_sharp_lab12
{
    internal class PhoneDirectory
    {
        private List<Organization> organizations = new List<Organization>();

        public void Add(Organization org)
        {
            organizations.Add(org);
        }

        public void Delete(string name)
        {
            Organization org = organizations.Find(o => o.Name == name);
            if (org != null)
            {
                organizations.Remove(org);
            }
        }

        public Organization FindOrganizationByName(string name)
        {
            return organizations.Find(o => o.Name == name);
        }

        public void PrintAll()
        {
            foreach (Organization org in organizations)
            {
                Console.WriteLine(org);
            }
        }

        public void SaveToXml(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Organization>));
            using (StreamWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, organizations);
            }
        }

        public static PhoneDirectory LoadFromXml(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Organization>));
            using (StreamReader reader = new StreamReader(path))
            {
                List<Organization> organizations = (List<Organization>)serializer.Deserialize(reader);
                PhoneDirectory PD = new PhoneDirectory();
                PD.organizations = organizations;
                return PD;
            }
        }
    }
}
