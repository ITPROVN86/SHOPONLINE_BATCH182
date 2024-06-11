namespace BaiTestC_
{
    public interface IContactRepository
    {
        void AddContact(Contact contact);
        void DeleteContact(int contactID);
        void UpdateContact(Contact contact);
        List<Contact> GetAllContacts();
        List<Contact> GetContactsByStatus(bool status);
        List<Contact> GetContactsByAddress(string address);
        List<Contact> SearchContactsByName(string name);
        void SortContactsByName();
    }
}