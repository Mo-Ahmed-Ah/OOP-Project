namespace OOPProject.Models;

public class Librarian : LibraryUser
{
    

    public string LibrarianId { get; private set; }
    public decimal Salary { get; set; }
    public DateOnly HireDate { get; set; }

    public Librarian(string librarianId , string name , string phone, decimal salary, DateOnly hireDate):base(name , phone)
    {
        LibrarianId = librarianId;
        Salary = salary;
        HireDate = hireDate;
    }

    public override string ToDisplayString()
    {
        return $@"
         Id     :   {LibrarianId}
         Name   :   {Name}
         Phone  :   {Phone}
         Salary :   {Salary:c}
         Hired  :   {HireDate:dd/MM/yyyy}
";
    }
}
