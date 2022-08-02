namespace PieApiDemo.Models
{
    public interface IPieRepository
    {
        
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        IEnumerable<Pie> FruitPies();
        IEnumerable<Pie> CheesPies();
        IEnumerable<Pie> SeasonPies();
        Pie Insert(Pie pie);
       Pie Update(Pie pie);
        Pie Delete(int id);
        public Pie GetPieById(int id);

    }
}
