using OOPProject.Models;
using ConsoleTheme;

namespace OOPProject.Services;

public class DisplayService
{
    public void ShowBranchInfo(LibraryBranch branch)
    {
        ThemeHelper.PrintHeader("LIBRARY BRANCH  INFO");
        Console.WriteLine(branch.ToDisplayString());
    }

    public void ShowAllUsers(LibraryBranch branch) 
    {
        ThemeHelper.PrintHeader("All Registration Users");
        var users = branch.Users;
        if (users.Count == 0)
            throw new InvalidOperationException("No Users Available");
        for (int i = 0; i < users.Count; i++) 
        {
            var title = users[i] is Librarian ? "LIBRARIAN PROFILE" : "MEMBER PROFILE";
            ThemeHelper.PrintSectionTitle(title);
            Console.WriteLine(users[i].ToDisplayString());
        }
    }

    public void ShowAvailableCopies(LibraryBranch branch)
    {
        ThemeHelper.PrintHeader("Available Book Copies");
        var copies = branch.GetAvaliableCopies();
        if (copies.Count == 0)
            throw new InvalidOperationException("No Copies Available Found");
        for (int i = 0; i < copies.Count; i++)
        {
            Console.WriteLine(copies[i].ToDisplayString());
        }
    }

    public void ShowAllCopies(LibraryBranch branch)
    {
        ThemeHelper.PrintHeader("Available Book Copies");
        var copies = branch.BookCopies;
        if (copies.Count == 0)
            throw new InvalidOperationException("No Copies Available Found");
        for (int i = 0; i < copies.Count; i++)
        {
            Console.WriteLine(copies[i].ToDisplayString());
        }
    }
    public void ShowMemberHistory(Member member)
    {
        var transactions = member.Transactions;
        if (transactions.Count == 0)
            throw new InvalidOperationException("No Borrowing History Found");
        for(int i = 0; i < transactions.Count; i++)
        {
            ThemeHelper.PrintSectionTitle($"Ttransaction #{transactions[i].TransactionId}");
            Console.WriteLine(transactions[i].ToDisplayString());
        }
    }
    
    public void ShowBorrowSuccess(BookCopy bookCopy , Member member)
    {
        ThemeHelper.PrintSuccess($"Copy [{bookCopy.CopyId}] \"{bookCopy.Book.Title}\" borrowed by {member.Name}");
        ThemeHelper.PrintSuccess($"Due Date : {bookCopy.ActiveTransaction.DueDate}");
    }

    public void ShowReturnSuccess(BookCopy bookCopy, decimal fine) 
    {
        ThemeHelper.PrintSuccess($"Copy [{bookCopy.CopyId}] : {bookCopy.Book.Title} returned");
        if (fine == 0)
            ThemeHelper.PrintSuccess("Returned on time. No fine");
        else
            ThemeHelper.PrintWarning($"Late return fine : {fine:f2} EGP");
    }

    public void ShowRegisterSuccess(Member member)
    {
        ThemeHelper.PrintSuccess($"Memeber: {member.Name} - [{member.MemberShipId}] registered.");
    }

    public void ShowAddBookCopySuccess(BookCopy bookCopy)
    {
        ThemeHelper.PrintSuccess($"BookCopy: {bookCopy.Book.Title} - [{bookCopy.CopyId}] Added.");
    }
}
