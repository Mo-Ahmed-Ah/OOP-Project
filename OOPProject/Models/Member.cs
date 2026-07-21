using System.Text;

namespace OOPProject.Models;

public class Member : LibraryUser
{

    private static int _counter = 1;
    public string MemberShipId { get; private set; }
    public DateOnly? DateOfBirth { get; private set; }
    public string? Email { get; private set; }
    public DateOnly MemberShipDate { get; private set; }
    private readonly List<BorrowTransaction> _transactions = new();
    public IReadOnlyList<BorrowTransaction> Transactions => _transactions;
    public Member(string name, string phone, DateOnly? dateOfBirth, string? email, DateOnly memberShipDate) : base(name, phone)
    {
        MemberShipId = $"MEM-{_counter++:D3}";
        DateOfBirth = dateOfBirth;
        Email = email;
        MemberShipDate = memberShipDate;
    }

    public Member(string name, string phone) : this(name, phone, null, null, DateOnly.FromDateTime(DateTime.Today))
    {

    }

    public void AddTransaction(BorrowTransaction transaction) => _transactions.Add(transaction);

    public override string ToDisplayString() => $@"ID    :    {MemberShipId}
         Name    :    {Name}
         Phone   :    {Phone}
         Email   :    {Email}
         Joined  :    {MemberShipDate}
         Borrows :    {Transactions.Count}
        ";

    public string GetHistoryDisplayString()
    {
        if (_transactions.Count == 0)
            return "No borrowing history found.";
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < _transactions.Count; i++) 
        {
            result.AppendLine(Transactions[i].ToDisplayString());        
        }
        return result.ToString();
    }
}
