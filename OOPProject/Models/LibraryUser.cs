using OOPProject.Contracts;

namespace OOPProject.Models;

public abstract class LibraryUser : IDisplayable
{
    protected    LibraryUser(string name, string phone)
    {
        Name = name;
        Phone = phone;
    }

    public string Name { get; protected set; }
    public string  Phone { get; protected set; }

    public abstract string ToDisplayString();
}
