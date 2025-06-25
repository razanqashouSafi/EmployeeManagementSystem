using EmployeeSystem_API.DTOs.Request;
using EmployeeSystem_API.DTOs.Response;

namespace EmployeeSystem_API.Interfaces
{
    public interface IEmployee
    {
        Task<string>CreateEmployee(CreateEmployeeInput input);

        Task<UploadImageResult> UploadImage(int id, IFormFile profileImage);

        Task<UploadImageResult> UpdateImageUpload(int id, IFormFile profileImage);
        Task<string> UpdateEmployee(UpdateEmployeeDTO input);


        Task<string> DeleteEmployee(int id);

        Task<List<EmployeeDelatis>> GetEmployee(int id);

        Task<List<AllEmployeeOutputDTO>> GetAllEmployee();

    }
}
