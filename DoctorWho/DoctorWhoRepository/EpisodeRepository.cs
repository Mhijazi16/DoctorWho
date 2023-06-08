using DoctorWho.Db;

namespace DoctorWhoRepository;

public class EpisodeRepository
{
      private static readonly DoctorWhoContext _context = new DoctorWhoContext();
     
      public static void AddEpisode(Episode episode)
       { 
           _context.Episodes.Add(episode); 
           _context.SaveChanges(); 
       }
    
       public static void UpdateEpisodeData(Episode episode, Episode data)
       {
           episode = data;
           _context.Episodes.Update(episode); 
           _context.SaveChanges();
       }
   
       public static void UpdateEpisodeData(int id, Episode data)
       {
           var episode = _context.Episodes.Find(id);
           if (episode == null)
               return; 
           episode = data; 
           _context.Episodes.Update(episode); 
           _context.SaveChanges(); 
       }
   
       public static void DeleteEpisode(Episode episode)
       {
           _context.Episodes.Remove(episode);
           _context.SaveChanges(); 
       }
   
       public static void DeleteEpisode(int id)
       {
           var episode = _context.Episodes.Find(id);
           if (episode == null)
               return; 
           _context.Episodes.Remove(episode);
           _context.SaveChanges(); 
       }

       public static void setEpisodeAuthor(Episode episode, int authorId)
       {
           episode.AuthorId = authorId;
           _context.Episodes.Update(episode);
           _context.SaveChanges(); 
       }

       public static void setEpisodeDoctor(Episode episode, int doctorId)
       {
           episode.DoctorId = doctorId;
           _context.Episodes.Update(episode);
           _context.SaveChanges();
       }
}