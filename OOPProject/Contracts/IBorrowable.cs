using OOPProject.Models;

namespace OOPProject.Contracts;

public interface IBorrowable
{
    void Borrow(Member member , int loansDays = 14);

    decimal Return();
    bool IsAvailabile();
}
