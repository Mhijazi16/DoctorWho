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

       public static void SetEpisodeAuthor(Episode episode, int authorId)
       {
           episode.AuthorId = authorId;
           _context.Episodes.Update(episode);
           _context.SaveChanges(); 
       }

       public static void SetEpisodeDoctor(Episode episode, int doctorId)
       {
           episode.DoctorId = doctorId;
           _context.Episodes.Update(episode);
           _context.SaveChanges();
       }

       public static void AddEnemyToEpisode(Episode episode, Enemy enemy)
       {
           int epID = episode.EpisodeId;
           int enID = enemy.EnemyId;
           
           var record = new EpisodeEnemy{ EpisodeId = epID, EnemyId = enID, Enemy = enemy, Episode = episode};
           episode.TblEpisodeEnemies.Add(record);
           enemy.TblEpisodeEnemies.Add(record);

           _context.Update(enemy);
           _context.Update(episode);
           _context.SaveChanges();
       }

       public static void AddCompanionToEpisode(Episode episode, Companion companion)
       {
           int epID = episode.EpisodeId;
           int cpID = companion.CompanionId;

           var record = new EpisodeCompanion
               { EpisodeId = epID, CompanionId = cpID, Episode = episode, Companion = companion }; 
           episode.TblEpisodeCompanions.Add(record);
           companion.TblEpisodeCompanions.Add(record);

           _context.Update(episode);
           _context.Update(companion); 
       }
       
}