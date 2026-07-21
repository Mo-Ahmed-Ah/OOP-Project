using OOPProject.Contracts;

namespace OOPProject.Models;

public class Book : IDisplayable
{

    public string ISBN { get; private set; }
    public string Title { get; private set; }
    public string AuthorName { get; private set; }
    public string Category { get; private set; }
    public int PublicationYear { get; private set; }

    public Book(string iSBN, string title, string authorName, string category, int publicationYear)
    {
        ISBN = iSBN;
        Title = title;
        AuthorName = authorName;
        Category = category;
        PublicationYear = publicationYear;
    }
    public Book(string iSBN, string title): this(iSBN , title , "Unkown" , "General" , 0)
    {

    }
    public string ToDisplayString() => $"[{ISBN}] : {Title} - by {AuthorName} - {PublicationYear} - {Category}";
}
