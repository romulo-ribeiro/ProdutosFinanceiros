using ProdutosFinanceiros.Domain.Enums;

namespace ProdutosFinanceiros.Domain;
public class User : Entity
{
    public UserType Type { get; private set; }
    public string Email {get; private set;}
    public string Password {get; private set;}

    public User(string name, string email, string password)
    {
        AddName(name);
        Email = email;
        Password = password;
    }

    public void SetManager()
    {
        Type = UserType.Manager;
    }

    public void SetCustomer()
    {
        Type = UserType.Customer;
    }

    public void SetAdmin(){
        Type = UserType.Admin;
    }   
}
