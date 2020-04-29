namespace FactoryProductSaver.Models
{
    public class Material
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public Material Clone()
        {
            return new Material
            {
                Name = Name,
                Id = Id,
                Count = Count
            };
        }

    }
}
