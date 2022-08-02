namespace Shashwat.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie GetPieById(int pieId);
        IEnumerable<Pie> FruitPies();
        IEnumerable<Pie> CheesPies();
        IEnumerable<Pie> SeasonPies();
        public int CreateOrder(Order order);
        public int UpdateOrder(Order order);
        public int UpdatePie(Pie pie);

        public IEnumerable<Order> AllOrder => throw new NotImplementedException();
        //public IEnumerable<Order> AllOrder => appDbContext.order;
    }
}
