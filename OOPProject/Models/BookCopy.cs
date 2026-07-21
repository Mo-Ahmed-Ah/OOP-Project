using OOPProject.Contracts;
using OOPProject.Models.Enums;

namespace OOPProject.Models;

public class BookCopy : IDisplayable, IBorrowable
{
    public BookCopy(string copyId, Book book, string condition = "Good")
    {
        CopyId = copyId;
        Condition = condition;
        Status = CopyStatus.Available;
        Book = book;
    }

    public string CopyId { get; private set; }
    public string Condition { get; private set; }
    public CopyStatus Status { get; private set; }
    public Book Book { get; private set; }
    public BorrowTransaction? ActiveTransaction { get; private set; }
    public void Borrow(Member member, int loansDays = 14)
    {
        if (Status != CopyStatus.Available)
            throw new InvalidOperationException($"Copy {CopyId} is not available (Status : {Status})");
        Status = CopyStatus.Borrowed;
        ActiveTransaction = new BorrowTransaction(member, this, loansDays);
        member.AddTransaction(ActiveTransaction);
    }


    public bool IsAvailabile() => Status == CopyStatus.Available;

    public decimal Return()
    {
        if (ActiveTransaction == null)
            throw new InvalidOperationException("No Active Transaction for this book");
        if (Status != CopyStatus.Borrowed)
            throw new InvalidOperationException($"Copy {CopyId} is not currnetly borrowd");
        ActiveTransaction.MarkReturn(DateOnly.FromDateTime(DateTime.Now));
        decimal fine = ActiveTransaction.CalculateFine(DateOnly.FromDateTime(DateTime.Now));
        Status = CopyStatus.Available;
        ActiveTransaction = null;
        return fine;
    }

    public string ToDisplayString()
    {
        string avail = IsAvailabile() ? "Availabile" : $"{Status}";
        return $"Copy [{CopyId}] | {Book.Title} | condition : {Condition} | {avail}";
     }
}