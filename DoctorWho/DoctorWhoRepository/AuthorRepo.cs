using DoctorWho.Db;

namespace DoctorWhoRepository;

public static class AuthorRepo
{
    public static void AddAuthor(Author author)
    {
        using (var context = new DoctorWhoContext())
        {
            context.Authors.Add(author); 
            context.SaveChanges(); 
        }
    }

    public static void AddAuthor(int id, string Name)
    {
        using (var context = new DoctorWhoContext())
        {
            context.Authors.Add(new Author{AuthorId = id,AuthorName = Name});
            context.SaveChanges(); 
        }
    }
}