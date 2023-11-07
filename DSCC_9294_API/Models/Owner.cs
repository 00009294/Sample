namespace DSCC_9294_API.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public IList<Car> Cars { get; set; }
    }
}
