using AutoMapper;
using Dtos.Measurement;
using Repository.Interface;
using Service.Exception;
using Service.Interface;

namespace Service.Implement
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IMeasurementRepository _measurementRepository;
        private readonly IMapper _mapper;

        public MeasurementService(
           IMeasurementRepository measurementRepository,
           IMapper mapper)
        {
            _mapper = mapper;
            _measurementRepository = measurementRepository;
        }

        public async Task AddNewMeasurement(NewMeasurementDto measurementDto)
        {
            var measurement = await _measurementRepository.GetMeasurementInFlatfrom(measurementDto.MeasurementName);

            if (measurement != null)
            {
                throw new ServiceException("Đơn vị này đã tồn tại !");
            }
            await _measurementRepository.AddNewMeasurement(measurementDto);
            return;
        }

        public async Task DeleteMeasurement(int measurementID)
        {
            var measurement = await _measurementRepository.GetMeasurementByID(measurementID);

            if (measurement == null)
            {
                throw new ServiceException("Đơn vị này không tồn tại !");
            }
            await _measurementRepository.DeleteMeasurement(measurementID);
            return;
        }

        public async Task<IEnumerable<MeasurementDto>> GetAllMeasureInFlatfrom()
        {
            return await _measurementRepository.GetAllMeasureInFlatfrom();
        }
    }
}
