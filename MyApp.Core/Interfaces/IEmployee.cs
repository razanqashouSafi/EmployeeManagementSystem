using MyApp.Core.DTOs.Request;
using MyApp.Core.DTOs.Response;
using Microsoft.AspNetCore.Http;

namespace MyApp.Core.Interfaces
{
    public interface IEmployee
    {
         Task<string>CreateEmployee(CreateEmployeeInputDTO input);

        Task<UploadImageResult> UploadImage(int id, IFormFile profileImage);

        Task<UploadImageResult> UpdateImageUpload(int id, IFormFile profileImage);
        Task<string> UpdateEmployee(UpdateEmployeeDTO input);


        Task<string> DeleteEmployee(int id);

        Task<List<EmployeeDelatis>> GetEmployee(int id);

        Task<List<AllEmployeeOutputDTO>> GetAllEmployee();

    }
}
