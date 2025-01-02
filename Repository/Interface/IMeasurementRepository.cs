using Dtos.Measurement;

namespace Repository.Interface
{
    public interface IMeasurementRepository
    {
        Task<IEnumerable<MeasurementDto>> GetAllMeasureInFlatfrom();
        Task AddNewMeasurement(NewMeasurementDto measurementDto);
        Task<MeasurementDto> GetMeasurementInFlatfrom(string measurementName);
        Task DeleteMeasurement(int measurementID);
        Task<MeasurementDto> GetMeasurementByID(int measurementID);
    }
}
