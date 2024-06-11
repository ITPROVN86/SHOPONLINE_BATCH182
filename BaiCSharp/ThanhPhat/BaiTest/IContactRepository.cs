namespace BaiTest
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        void DeleteContact(int id);
        void UpdateContact(Contact contact);
        Contact GetContact(int id);
        List<Contact> GetAllContacts();
        List<Contact> GetActiveContacts();
        List<Contact> GetContactsByAddress(string address);
        List<Contact> SearchContactsByName(string name);
        List<Contact> SortContactsByName();
    }
}
