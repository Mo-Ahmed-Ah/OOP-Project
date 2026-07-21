using OOPProject.Contracts;

namespace OOPProject.Models;

public class LibraryBranch : IDisplayable
{
    public string BranchId { get; set; }
    public string BranchName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string OpeningHours { get; set; }
    public Librarian Manager { get; set; }
    private readonly List<BookCopy> _copies = new();
    public IReadOnlyList<BookCopy> BookCopies => _copies;
    private readonly List<Member> _members = new();
    public IReadOnlyList<Member> Members => _members;
    public IReadOnlyList<LibraryUser> Users
    {
        get
        {
            List<LibraryUser> users = new List<LibraryUser>();
            users.Add(Manager);
            users.AddRange(_members);
            return users;
        }
    }
    public LibraryBranch(string branchId, string branchName, string address, string phone, string openingHours, Librarian manager)
    {
        BranchId = branchId;
        BranchName = branchName;
        Address = address;
        Phone = phone;
        OpeningHours = openingHours;
        Manager = manager;
    }

    public Member RegisterMember(string name, string phone)
    {
        var member = new Member(name, phone);
        _members.Add(member);
        return member;
    }

    public Member RegisterMember(string name, string phone, DateOnly? DOB, DateOnly memberShipDate, string email)
    {
        var member = new Member(name, phone, DOB, email, memberShipDate);
        _members.Add(member);
        return member;
    }

    public Member FindMember(string memberShipId)
    {
        memberShipId = memberShipId.Normalize();
        for (int i = 0; i < _members.Count; i++)
        {
            if (_members[i].MemberShipId == memberShipId)
                return _members[i]; 
        }
        throw new InvalidOperationException("Memeber Not Found.");
    }

    public void AddBookCopy(BookCopy copy) => _copies.Add(copy);

    public BookCopy FindCopy(string copyId)
    {
        copyId = copyId.Normalize();
        for (int i = 0; i < _copies.Count; i++)
        {
            if (_copies[i].CopyId == copyId)
                return _copies[i];
        }
        throw new InvalidOperationException("Book Copy Not Found.");
    }

    public List<BookCopy> GetAvaliableCopies()
    {
        var copies = new List<BookCopy>();
        for(int i = 0; i < _copies.Count ; i++)
        {
            if (_copies[i].IsAvailabile())
                copies.Add(_copies[i]);
        }
        return copies;
    }

    public string ToDisplayString() => $@"
        ID                : {BranchId}
        Name              : {BranchName}
        Address           : {Address}
        Opening Hours     : {OpeningHours}
        Manager           : {Manager}
        Total Members     : {_members.Count()}
        Total Book Copies : {_copies.Count()}
    ";
}
