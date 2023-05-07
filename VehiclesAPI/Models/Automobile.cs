namespace VehiclesAPI.Models
{
    /// <summary>
    /// Class <c>Vehicle</c> Models a vehicle.
    /// </summary>
    public class Automobile
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
        /// Property <c>BodyType</c> represents the shape and size of the vehicle, such as sedan, SUV, or pickup truck.
        /// </value>
        public string BodyType { get; set; }

        /// <value>
        /// Property <c>EngineSize</c> represents the volume of the engine, measured in liters or cubic centimeters (cc).
        /// </value>
        public string EngineSize { get; set; }

    }

    /// <summary>
    /// Class <c>Vehicle</c> Models a vehicle without Id.
    /// </summary>
    public class AutomobileRequest
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
        /// Property <c>BodyType</c> represents the shape and size of the vehicle, such as sedan, SUV, or pickup truck.
        /// </value>
        public string BodyType { get; set; }

        /// <value>
        /// Property <c>EngineSize</c> represents the volume of the engine, measured in liters or cubic centimeters (cc).
        /// </value>
        public string EngineSize { get; set; }

    }
}
