namespace WarehouseMaterialsSaver.Models
{
    /// <summary>
    /// Model representing material model 
    /// </summary>
    public class Material
    {
        /// <summary>
        /// The identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Count of reference element to <see cref="Warehouse"/> object
        /// </summary>
        public int Count { get; set; }
    }
}
