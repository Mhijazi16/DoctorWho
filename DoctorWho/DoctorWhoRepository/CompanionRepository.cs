using DoctorWho.Db;

namespace DoctorWhoRepository;

public class CompanionRepository
{
     private static readonly DoctorWhoContext _context = new DoctorWhoContext();
      public static void AddCompanion(Companion companion)
       { 
           _context.Companions.Add(companion); 
           _context.SaveChanges(); 
       }
    
       public static void UpdateCompanionData(Companion companion, Companion data)
       {
           companion = data;
           _context.Companions.Update(companion); 
           _context.SaveChanges();
       }
   
       public static void UpdateCompanionData(int id, Companion data)
       {
           var companion = _context.Companions.Find(id);
           if (companion == null)
               return; 
           companion = data; 
           _context.Companions.Update(companion); 
           _context.SaveChanges(); 
       }
   
       public static void DeleteCompanion(Companion companion)
       {
           _context.Companions.Remove(companion);
           _context.SaveChanges(); 
       }
   
       public static void DeleteCompanion(int id)
       {
           var companion = _context.Companions.Find(id);
           if (companion == null)
               return; 
           _context.Companions.Remove(companion);
           _context.SaveChanges(); 
       }    

}