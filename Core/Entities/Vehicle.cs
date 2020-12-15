using Core.Enums;

namespace Core.Entities
{
    public class Vehicle : BaseEntity
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Make of the vehicle
        /// </summary>
        public string Make { get; set; }
        
        /// <summary>
        /// Model of the vehicle
        /// </summary>
        public string Model { get; set; }
        
        /// <summary>
        /// Vehicle type
        /// </summary>
        public VehicleType VehicleType { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// Owner of the vehicle
        /// </summary>
        public string OwnerId { get; set; }
        
        /// <summary>
        /// Nav.Property
        /// </summary>
        public virtual ApplicationUser Owner { get; set; }
    }
}