using ConsoleTheme;
using OOPProject.Extentions;
using OOPProject.Models;

namespace OOPProject.Services;

public  class LibraryService
{
    LibraryBranch _branch;
    DisplayService _displayService;

    public LibraryService(LibraryBranch branch, DisplayService displayService)
    {
        _branch = branch;
        _displayService = displayService;
    }

    public void HandleBorrow()
    {
        string memberId = ThemeHelper.Prompt("Enter Member ID: ").NormalizeId();
        var member = _branch.FindMember(memberId);

        _displayService.ShowAvailableCopies(_branch);
        string copyId = ThemeHelper.Prompt("Enter Copy Id To Borrow: ").NormalizeId();
        var copy = _branch.FindCopy(copyId);
            
        copy.Borrow(member);
        _displayService.ShowBorrowSuccess(copy,member);
    }
    public void HandleReturn()
    {
        string copyId = ThemeHelper.Prompt("Enter Copy Id To Borrow: ").NormalizeId();
        var copy = _branch.FindCopy(copyId);

        var fine = copy.Return();
        _displayService.ShowReturnSuccess(copy, fine);
    }
    public void HandleHistory()
    {
        string memberId = ThemeHelper.Prompt("Enter Member ID: ").NormalizeId();
        var member = _branch.FindMember(memberId);
        _displayService.ShowMemberHistory(member);
    }
    public void HandelRegisterMember()
    {
        string memberName = ThemeHelper.Prompt("Enter Member Name:");
        string phoneNumber = ThemeHelper.Prompt("Enter Phone Number:");
        if (!phoneNumber.IsDiget())
            throw new InvalidOperationException("Phone must be at last one digit");
        string email = ThemeHelper.Prompt("Enter Email Address:");
        if(!email.FormatEmail())
            throw new InvalidOperationException("Invalid Format Email");
        var member =  _branch.RegisterMember(memberName, phoneNumber, null , DateOnly.FromDateTime(DateTime.Today) , email);
        _displayService.ShowRegisterSuccess(member);
    }

}
