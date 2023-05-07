using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using VehiclesAPI.Models;

namespace VehiclesAPI.Controllers
{
    [ApiController]
    [Route("automobile")]
    public class AutomobileController : ControllerBase
    {
        [HttpGet]
        [Route("list")]
        public IActionResult GetAutomobiles()
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/automobiles.json");
                var automobiles = JsonSerializer.Deserialize<List<Automobile>>(jsonData);

                if (automobiles == null || automobiles.Count == 0)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = "No vehicles were found.",
                        ErrorMessage = null
                    });
                }

                return Ok(new ApiResponse<List<Automobile>>
                {
                    Success = true,
                    Data = automobiles,
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
        public IActionResult GetAutomobile(string id)
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/automobiles.json");
                var automobiles = JsonSerializer.Deserialize<List<Automobile>>(jsonData);

                // Find the automobile by Id
                var automobile = automobiles.SingleOrDefault(a => a.Id == id);

                if (automobile == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = "No vehicle was found.",
                        ErrorMessage = null
                    });
                }

                return Ok(new ApiResponse<Automobile>
                {
                    Success = true,
                    Data = automobile,
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
        public IActionResult SaveAutomobile([FromBody] AutomobileRequest request)
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/automobiles.json");
                var automobiles = JsonSerializer.Deserialize<List<Automobile>>(jsonData);

                // Initialize the list if it is null
                automobiles ??= new List<Automobile>();

                // Get the last id from the list and add it 1 to get the new id
                int lastId = automobiles.LastOrDefault()?.Id != null ? int.Parse(automobiles.Last().Id) : 0;

                // We create a new Automobile object with the new application id and data
                var automobile = new Automobile
                {
                    Id = (lastId + 1).ToString(),
                    Make = request.Make,
                    Model = request.Model,
                    Year = request.Year,
                    BodyType = request.BodyType,
                    EngineSize = request.EngineSize
                };

                // Add the new entry
                automobiles.Add(automobile);

                // Save the updated data in the JSON file
                var json = JsonSerializer.Serialize(automobiles);
                System.IO.File.WriteAllText("Data/automobiles.json", json);

                return Ok(new ApiResponse<Automobile>
                {
                    Success = true,
                    Data = automobile,
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
        public IActionResult UpdateAutomobile(string id, [FromBody] AutomobileRequest automobile)
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/automobiles.json");
                var automobiles = JsonSerializer.Deserialize<List<Automobile>>(jsonData);

                // Find the automobile by Id
                var existingAutomobile = automobiles.SingleOrDefault(a => a.Id == id);

                if (existingAutomobile == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = "No vehicle was found.",
                        ErrorMessage = null
                    });
                }

                // Remove old entry
                automobiles.Remove(existingAutomobile);

                // Update data
                existingAutomobile.Make = automobile.Make;
                existingAutomobile.Model = automobile.Model;
                existingAutomobile.Year = automobile.Year;
                existingAutomobile.BodyType = automobile.BodyType;
                existingAutomobile.EngineSize = automobile.EngineSize;

                // Add the new entry
                automobiles.Add(existingAutomobile);

                // Save the updated data in the JSON file
                var json = JsonSerializer.Serialize(automobiles);
                System.IO.File.WriteAllText("Data/automobiles.json", json);

                return Ok(new ApiResponse<Automobile>
                {
                    Success = true,
                    Data = existingAutomobile,
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
        public IActionResult DeleteAutomobile(string id)
        {
            try
            {
                // Read existing data from JSON file
                var jsonData = System.IO.File.ReadAllText("Data/automobiles.json");
                var automobiles = JsonSerializer.Deserialize<List<Automobile>>(jsonData);

                // Find the automobile by Id
                var existingAutomobile = automobiles.SingleOrDefault(a => a.Id == id);

                if (existingAutomobile == null)
                {
                    return NotFound(new ApiResponse<string>
                    {
                        Success = false,
                        Data = "No vehicle was found.",
                        ErrorMessage = null
                    });
                }

                // Remove the entry
                automobiles.Remove(existingAutomobile);

                // Save the updated data in the JSON file
                var json = JsonSerializer.Serialize(automobiles);
                System.IO.File.WriteAllText("Data/automobiles.json", json);

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
