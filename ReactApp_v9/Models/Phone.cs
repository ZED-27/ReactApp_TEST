namespace ReactApp_v9.Models
{
    public class Phone
    {
        private static int idCounter = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Phone(string name, int price)
        {
            Id = idCounter;
            idCounter++;
            Name = name;
            Price = price;
        }
    }
}
