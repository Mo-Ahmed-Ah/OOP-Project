using Microsoft.VisualBasic;
using OOPProject.Contracts;
using System.Net.NetworkInformation;

namespace OOPProject.Models;

public class BorrowTransaction : IDisplayable
{
    private static int _counter = 1000;
    private const decimal finePerDay = 10m;
    private const string DateFormat = "dd/MM/yyyy";
    public int TransactionId { get; private set; }
    public Member Member { get; private set; }
    public BookCopy BookCopy { get; private set; }
    public DateOnly BorrowDate { get; private set; }
    public DateOnly DueDate { get; private set; }
    public DateOnly? ReturnDate { get; private set; }

    public BorrowTransaction(Member member, BookCopy bookCopy , int loansDays)
    {
        TransactionId = ++_counter;
        Member = member;
        BookCopy = bookCopy;
        BorrowDate = DateOnly.FromDateTime(DateTime.Now);
        DueDate = DateOnly.FromDateTime(DateTime.Now.AddDays(loansDays));
        ReturnDate = null;
    }

    public bool IsReturned() => ReturnDate.HasValue;
    public decimal CalculateFine()
    {
        DateOnly effictiveDate = ReturnDate ?? DateOnly.FromDateTime(DateTime.Now);
        int diff = effictiveDate.DayNumber - DueDate.DayNumber;
        return diff > 0 ? diff * finePerDay : 0;
    }

    public decimal CalculateFine(DateOnly returnDate)
    {
        int diff = returnDate.DayNumber - DueDate.DayNumber;
        return diff > 0 ? diff * finePerDay : 0;
    }
    public void MarkReturn(DateOnly returnDate) => ReturnDate = returnDate;
    public string ToDisplayString()
    {
        string status = ReturnDate.HasValue ? "Returnd" : "Active";
        decimal fine = CalculateFine();
        string returnInfo = ReturnDate.HasValue ? ReturnDate.Value.ToString() : "Not returnd yet";
        string fineLine = fine > 0 ? $"{fine:F2} EGP" : "Non";
        return $@"------------ Trancction #{TransactionId}
                  Book      : {BookCopy.Book.Title}
                  Copy Id   : {BookCopy.CopyId}
                  Borrowed  : {BorrowDate.ToString()}
                  Due       : {DueDate.ToString()}
                  Returnd   : {returnInfo}
                  Status    : {status}
                  Fine      : {fineLine}
";
    }
}
