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


        public int UpdatePie(Pie pie)
        {
            this.appDbContext.Pies.Update(pie);
            return this.appDbContext.SaveChanges();

        }

        public IEnumerable<Pie> PiesOfTheWeek => appDbContext.Pies.Where(pie => pie.IsPieOfTheWeek);

        public IEnumerable<Pie>FruitPies()
        { return AllPies.Where(pie => pie.CategoryId == 1); }
        public IEnumerable<Pie> CheesPies()
        { return AllPies.Where(pie => pie.CategoryId == 2); }
        public IEnumerable<Pie> SeasonPies()
        { return AllPies.Where(pie => pie.CategoryId == 3); }
        public Pie GetPieById(int pieId)
        {
            return this.AllPies.FirstOrDefault(pie => pie.PieId ==pieId); 
        }

        public int CreateOrder(Order order)
        {

            appDbContext.order.Add(order);
            return appDbContext.SaveChanges();
        }
        public int UpdateOrder(Order order)
        {
            appDbContext.order.Update(order);
            return appDbContext.SaveChanges();
        }
        public IEnumerable<Order> AllOrder => appDbContext.order;
    }
}
