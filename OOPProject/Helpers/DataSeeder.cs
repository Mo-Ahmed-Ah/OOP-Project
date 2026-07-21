using System;
using OOPProject.Models;

namespace OOPProject.Helpers;

public static class DataSeeder
{
    public static LibraryBranch Seed()
    {
        var manager = new Librarian( "LIB-001", "Ahmed Mohamad",
                                    "0123456789",15000m, DateOnly.FromDateTime(new(2020, 1, 15))
                                );

        var branch = new LibraryBranch(
                        "BR-001",
                         "Central Library",
                         "123 Main St",
                        "0122-555-0100",
                        "9:00 - 17:00",
                        manager
        );

        // Members registered via RegisterMember
        branch.RegisterMember(
                 "Omar Ali",
                 "01001234567",
                DateOnly.FromDateTime(new(1995, 5, 20)),
                 DateOnly.FromDateTime(DateTime.Today),
                "omar@example.com"
        );

        branch.RegisterMember(
            name: "Sara Ibrahim",
            phone: "01109876543"
        );

        branch.RegisterMember(
            name: "Nour Salah",
            phone: "01011112222",
            DOB: DateOnly.FromDateTime(new(1990, 3, 15)),
            memberShipDate: DateOnly.FromDateTime(DateTime.Today),
            email: "nour@example.com"
        );

        // Books and copies
        Book book1 = new("9780143128540", "Sapiens", "Yuval Noah Harari", "History", 2011);
        Book book2 = new("9780140449136", "Meditations", "Marcus Aurelius", "Philosophy", 2006);
        Book book3 = new("BK-001", "The Pragmatic Programmer");

        BookCopy copy1 = new("C-001", book1);
        BookCopy copy2 = new("C-002", book2);
        BookCopy copy3 = new("C-003", book3, condition: "Fair");

        branch.AddBookCopy(copy1);
        branch.AddBookCopy(copy2);
        branch.AddBookCopy(copy3);

        return branch;
    }
}
