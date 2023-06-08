using DoctorWho.Db;

public class EnemyRepository
{
     private static readonly DoctorWhoContext _context = new DoctorWhoContext();
    
     public static void AddEnemy(Enemy enemy)
      { 
          _context.Enemies.Add(enemy); 
          _context.SaveChanges(); 
      }
   
      public static void UpdateEnemyData(Enemy enemy, Enemy data)
      {
          enemy = data;
          _context.Enemies.Update(enemy); 
          _context.SaveChanges();
      }
  
      public static void UpdateEnemyData(int id, Enemy data)
      {
          var enemy = _context.Enemies.Find(id);
          if (enemy == null)
              return; 
          enemy = data; 
          _context.Enemies.Update(enemy); 
          _context.SaveChanges(); 
      }
  
      public static void DeleteEnemy(Enemy enemy)
      {
          _context.Enemies.Remove(enemy);
          _context.SaveChanges(); 
      }
  
      public static void DeleteEnemy(int id)
      {
          var enemy = _context.Enemies.Find(id);
          if (enemy == null)
              return; 
          _context.Enemies.Remove(enemy);
          _context.SaveChanges(); 
      }   
}