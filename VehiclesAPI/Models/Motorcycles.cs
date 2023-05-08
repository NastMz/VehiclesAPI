namespace VehiclesAPI.Models
{
    /// <summary>
    /// Class <c>Vehicle</c> Models a vehicle.
    /// </summary>
    public class Motorcycle
    {
        /// <value>
        /// Property <c>Id</c> represents the vehicle's unique Id.
        /// </value>
        public string Id { get; set; }

        /// <value>
        /// Property <c>Make</c> represents the brand or manufacturer of the vehicle, such as Toyota or Ford.
        /// </value>
        public string Make { get; set; }

        /// <value>
        /// Property <c>Model</c> represents the specific name or series of a particular vehicle, such as Camry or F-150.
        /// </value>
        public string Model { get; set; }

        /// <value>
        /// Property <c>Year</c> represents the Year it was manufactured.
        /// </value>
        public string Year { get; set; }

        /// <value>
        /// Property <c>CylinderCapacity</c> represents the cylinder capacity of the vehicle, such as 100CC or 200CC.
        /// </value>
        public string CylinderCapacity { get; set; }

        /// <value>
        /// Property <c>Color</c>  represents the color of vehicle.
        /// </value>
        public string Color { get; set; }

    }

    /// <summary>
    /// Class <c>Vehicle</c> Models a vehicle without Id.
    /// </summary>
    public class MotorcycleRequest
    {
        /// <value>
        /// Property <c>Make</c> represents the brand or manufacturer of the vehicle, such as Toyota or Ford.
        /// </value>
        public string Make { get; set; }

        /// <value>
        /// Property <c>Model</c> represents the specific name or series of a particular vehicle, such as Camry or F-150.
        /// </value>
        public string Model { get; set; }

        /// <value>
        /// Property <c>Year</c> represents the Year it was manufactured.
        /// </value>
        public string Year { get; set; }

        /// <value>
        /// Property <c>CylinderCapacity</c> represents the cylinder capacity of the vehicle, such as 100CC or 200CC.
        /// </value>
        public string CylinderCapacity { get; set; }

        /// <value>
        /// Property <c>Color</c> represents the color of vehicle.
        /// </value>
        public string Color { get; set; }

    }
}
