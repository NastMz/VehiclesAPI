using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VehiclesAPI.Models;

namespace VehiclesAPI.Controllers
{
    [ApiController]
    [Route("motorcycle")]
    public class MotorcycleController : ControllerBase
    {
        [HttpGet]
        [Route("list")]
        public IActionResult GetMotorcycles()
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/motorcycles.json");
                var motorcycles = JsonSerializer.Deserialize<List<Motorcycle>>(jsonData);

                if (motorcycles == null || motorcycles.Count == 0)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = "No vehicles were found.",
                        ErrorMessage = null
                    });
                }

                return Ok(new ApiResponse<List<Motorcycle>>
                {
                    Success = true,
                    Data = motorcycles,
                    ErrorMessage = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = $"Error occurred while reading JSON file: {ex.Message}"
                });
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetMotorcycle(string id)
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/motorcycles.json");
                var motorcycles = JsonSerializer.Deserialize<List<Motorcycle>>(jsonData);

                // Find the motorcycle by Id
                var motorcycle = motorcycles.SingleOrDefault(a => a.Id == id);

                if (motorcycle == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = "No vehicle was found.",
                        ErrorMessage = null
                    });
                }

                return Ok(new ApiResponse<Motorcycle>
                {
                    Success = true,
                    Data = motorcycle,
                    ErrorMessage = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = $"An error occurred when searching for the car: {ex.Message}"
                });
            }
        }

        [HttpPost]
        [Route("save")]
        public IActionResult SaveMotorcycle([FromBody] MotorcycleRequest request)
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/motorcycles.json");
                var motorcycles = JsonSerializer.Deserialize<List<Motorcycle>>(jsonData);

                // Initialize the list if it is null
                motorcycles ??= new List<Motorcycle>();

                // Get the last id from the list and add it 1 to get the new id
                int lastId = motorcycles.LastOrDefault()?.Id != null ? int.Parse(motorcycles.Last().Id) : 0;

                // We create a new Motorcycle object with the new application id and data
                var motorcycle = new Motorcycle
                {
                    Id = (lastId + 1).ToString(),
                    Make = request.Make,
                    Model = request.Model,
                    Year = request.Year,
                    CylinderCapacity = request.CylinderCapacity,
                    Color = request.Color
                };

                // Add the new entry
                motorcycles.Add(motorcycle);

                // Save the updated data in the JSON file
                var json = JsonSerializer.Serialize(motorcycles);
                System.IO.File.WriteAllText("Data/motorcycles.json", json);

                return Ok(new ApiResponse<Motorcycle>
                {
                    Success = true,
                    Data = motorcycle,
                    ErrorMessage = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = $"An error occurred when saving the vehicle: {ex.Message}"
                });
            }
        }

        [HttpPut]
        [Route("update/{id}")]
        public IActionResult UpdateMotorcycle(string id, [FromBody] MotorcycleRequest motorcycle)
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/motorcycles.json");
                var motorcycles = JsonSerializer.Deserialize<List<Motorcycle>>(jsonData);

                // Find the motorcycle by Id
                var existingMotorcycle = motorcycles.SingleOrDefault(a => a.Id == id);

                if (existingMotorcycle == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = "No vehicle was found.",
                        ErrorMessage = null
                    });
                }

                // Remove old entry
                motorcycles.Remove(existingMotorcycle);

                // Update data
                existingMotorcycle.Make = motorcycle.Make;
                existingMotorcycle.Model = motorcycle.Model;
                existingMotorcycle.Year = motorcycle.Year;
                existingMotorcycle.CylinderCapacity = motorcycle.CylinderCapacity;
                existingMotorcycle.Color = motorcycle.Color;

                // Add the new entry
                motorcycles.Add(existingMotorcycle);

                // Save the updated data in the JSON file
                var json = JsonSerializer.Serialize(motorcycles);
                System.IO.File.WriteAllText("Data/motorcycles.json", json);

                return Ok(new ApiResponse<Motorcycle>
                {
                    Success = true,
                    Data = existingMotorcycle,
                    ErrorMessage = null
                }); ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = $"An error occurred when updating the vehicle: {ex.Message}"
                });
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteMotorcycle(string id)
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/motorcycles.json");
                var motorcycles = JsonSerializer.Deserialize<List<Motorcycle>>(jsonData);

                // Find the motorcycle by Id
                var existingMotorcycle = motorcycles.SingleOrDefault(a => a.Id == id);

                if (existingMotorcycle == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = "No vehicle was found.",
                        ErrorMessage = null
                    });
                }

                // Remove the entry
                motorcycles.Remove(existingMotorcycle);

                // Save the updated data in the JSON file
                var json = JsonSerializer.Serialize(motorcycles);
                System.IO.File.WriteAllText("Data/motorcycles.json", json);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Data = "Vehicle deleted successfully.",
                    ErrorMessage = null
                }); ;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = $"An error occurred when deleting the vehicle: {ex.Message}"
                });
            }
        }

    }
}
