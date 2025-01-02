using Dtos.Measurement;

namespace Service.Interface
{
    public interface IMeasurementService
    {
        Task<IEnumerable<MeasurementDto>> GetAllMeasureInFlatfrom();
        Task AddNewMeasurement(NewMeasurementDto measurementDto);
        Task DeleteMeasurement(int measurementID);
    }
}
