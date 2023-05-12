using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VehiclesAPI.Models;

namespace VehiclesAPI.Controllers
{
    [ApiController]
    [Route("boat")]
    public class BoatController : ControllerBase
    {
        [HttpGet]
        [Route("list")]

        public IActionResult GetBoats()
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/boats.json");
                var boats = JsonSerializer.Deserialize<List<Boat>>(jsonData);

                if (boats == null || boats.Count == 0)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = "No vehicles were found.",
                        ErrorMessage = null
                    });
                }

                return Ok(new ApiResponse<List<Boat>>
                {
                    Success = true,
                    Data = boats,
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
        public IActionResult GetBoat(string id)
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/boats.json");
                var boats = JsonSerializer.Deserialize<List<Boat>>(jsonData);

                // Find the boat by Id
                var boat = boats.SingleOrDefault(b => b.Id == id);

                if (boat == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = "No vehicle was found.",
                        ErrorMessage = null
                    });
                }

                return Ok(new ApiResponse<Boat>
                {
                    Success = true,
                    Data = boat,
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
        public IActionResult SaveBoat([FromBody] BoatRequest request)
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/boats.json");
                var boats = JsonSerializer.Deserialize<List<Boat>>(jsonData);

                // Initialize the list if it is null
                boats ??= new List<Boat>();

                // Get the last id from the list and add it 1 to get the new id
                int lastId = boats.LastOrDefault()?.Id != null ? int.Parse(boats.Last().Id) : 0;

                // We create a new Boat object with the new application id and data
                var boat = new Boat
                {
                    Id = (lastId + 1).ToString(),
                    Name = request.Name,
                    Type = request.Type,
                    Size = request.Size,
                    Length = request.Length,
                    Capacity = request.Capacity
                };

                // Add the new entry
                boats.Add(boat);

                // Save the updated data in the JSON file
                var json = JsonSerializer.Serialize(boats);
                System.IO.File.WriteAllText("Data/boats.json", json);

                return Ok(new ApiResponse<Boat>
                {
                    Success = true,
                    Data = boat,
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
        public IActionResult UpdateBoat(string id, [FromBody] BoatRequest boat)
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/boats.json");
                var boats = JsonSerializer.Deserialize<List<Boat>>(jsonData);

                // Find the boat by Id
                var existingBoat = boats.SingleOrDefault(b => b.Id == id);

                if (existingBoat== null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = "No vehicle was found.",
                        ErrorMessage = null
                    });
                }

                // Remove old entry
                boats.Remove(existingBoat);

                // Update data
                existingBoat.Name = boat.Name;
                existingBoat.Type = boat.Type;
                existingBoat.Size = boat.Size;
                existingBoat.Length = boat.Length;
                existingBoat.Capacity = boat.Capacity;

                // Add the new entry
                boats.Add(existingBoat);

                // Save the updated data in the JSON file
                var json = JsonSerializer.Serialize(boats);
                System.IO.File.WriteAllText("Data/boats.json", json);

                return Ok(new ApiResponse<Boat>
                {
                    Success = true,
                    Data = existingBoat,
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
        public IActionResult DeleteBoat(string id)
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/boats.json");
                var boats = JsonSerializer.Deserialize<List<Boat>>(jsonData);

                // Find the automobile by Id
                var existingBoat = boats.SingleOrDefault(a => a.Id == id);

                if (existingBoat == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = "No vehicle was found.",
                        ErrorMessage = null
                    });
                }

                // Remove the entry
                boats.Remove(existingBoat);

                // Save the updated data in the JSON file
                var json = JsonSerializer.Serialize(boats);
                System.IO.File.WriteAllText("Data/boats.json", json);

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
