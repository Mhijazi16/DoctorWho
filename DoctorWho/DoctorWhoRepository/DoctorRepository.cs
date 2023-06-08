using DoctorWho.Db;

namespace DoctorWhoRepository;

public static class DoctorRepository
{
    private static readonly DoctorWhoContext _context = new DoctorWhoContext();
   
    public static void AddDoctor(Doctor doctor)
     { 
         _context.Doctors.Add(doctor); 
         _context.SaveChanges(); 
     }
  
     public static void UpdateDoctorData(Doctor doctor, Doctor data)
     {
         doctor = data;
         _context.Doctors.Update(doctor); 
         _context.SaveChanges();
     }
 
     public static void UpdateDoctorData(int id, Doctor data)
     {
         var doctor = _context.Doctors.Find(id);
         if (doctor == null)
             return; 
         doctor = data; 
         _context.Doctors.Update(doctor); 
         _context.SaveChanges(); 
     }
 
     public static void DeleteDoctor(Doctor doctor)
     {
         _context.Doctors.Remove(doctor);
         _context.SaveChanges(); 
     }
 
     public static void DeleteDoctor(int id)
     {
         var doctor = _context.Doctors.Find(id);
         if (doctor == null)
             return; 
         _context.Doctors.Remove(doctor);
         _context.SaveChanges(); 
     }  
}