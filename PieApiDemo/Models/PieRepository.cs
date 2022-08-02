using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query; 
namespace PieApiDemo.Models
{
    public class PieRepository:IPieRepository
    {
        private readonly AppDbContext appDbContext;
        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<Pie> AllPies => appDbContext.Pies;
       




        public IEnumerable<Pie> PiesOfTheWeek => appDbContext.Pies;

        public IEnumerable<Pie> FruitPies()
        { return AllPies.Where(pie => pie.CategoryId == 1); }
        public IEnumerable<Pie> CheesPies()
        { return AllPies.Where(pie => pie.CategoryId == 2); }
        public IEnumerable<Pie> SeasonPies()
        { return AllPies.Where(pie => pie.CategoryId == 3); }
        public Pie GetPieById(int pieId)
        {
            return this.AllPies.FirstOrDefault(pie => pie.PieId == pieId); ;
        }
        public Pie Insert(Pie pie)
        {

            var entry = this.appDbContext.Pies.Add(pie);
            this.appDbContext.SaveChanges();
            return entry.Entity;





        }

        public Pie Update(Pie pie)
        {
            var entry = this.appDbContext.Pies.Update(pie);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }

        public Pie Delete(int pieId)
        {
            var pie = AllPies.FirstOrDefault(pie => pie.PieId == pieId);
            var entry = this.appDbContext.Pies.Remove(pie);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }



    }
}
