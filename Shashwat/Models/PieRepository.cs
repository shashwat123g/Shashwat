using Microsoft.EntityFrameworkCore;

namespace Shashwat.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        private readonly ICategoryRepository _categoryRepository;

        public IEnumerable<Pie> AllPies// => appDbContext.Pies;
       { get { return appDbContext.Pies.Include(c => c.Category); } }

       

        public IEnumerable<Pie> PiesOfTheWeek => appDbContext.Pies.Where(pie => pie.IsPieOfTheWeek);


        public Pie GetPieById(int pieId)
        {
            return this.AllPies.FirstOrDefault(pie => pie.PieId ==pieId); ;
        }
        

       
    }
}
