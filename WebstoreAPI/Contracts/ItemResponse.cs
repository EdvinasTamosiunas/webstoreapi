using API.Models;

namespace API.DataTransferObjects
{
    public class ItemResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Weighed { get; set; }

        public ItemResponse () { }
        public ItemResponse (Item item)
        {

            Id = item.Id;
            Name = item.Name;
            Price = item.Price;
            Weighed = item.Weighed;

        }
    }
}