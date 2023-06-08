using DoctorWho.Db;

namespace DoctorWhoRepository;

public static class AuthorRepo
{
    private static readonly DoctorWhoContext _context = new DoctorWhoContext();
    public static void AddAuthor(Author author)
    { 
        _context.Authors.Add(author); 
        _context.SaveChanges(); 
    }

    public static void AddAuthor(int id, string name)
    { 
        _context.Authors.Add(new Author{AuthorId = id,AuthorName = name}); 
        _context.SaveChanges(); 
    }
 
    public static void UpdateAuthorName(Author author, string name)
    { 
        author.AuthorName = name; 
        _context.Authors.Update(author); 
        _context.SaveChanges();
    }

    public static void UpdateAuthorName(int id, string name)
    {
        var author = _context.Authors.Find(id);
        if (author == null)
            return; 
        author.AuthorName = name; 
        _context.Authors.Update(author); 
        _context.SaveChanges(); 
    }
}