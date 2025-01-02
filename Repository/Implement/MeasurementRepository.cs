using AutoMapper;
using Dao;
using Dtos.Measurement;
using Dtos.Service;
using Models;
using Repository.Interface;

namespace Repository.Implement
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly IMapper _mapper;
        public MeasurementRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task AddNewMeasurement(NewMeasurementDto measurementDto)
        {
            var measurement = _mapper.Map<Measurement>(measurementDto);
            measurement.MeasurementName = measurementDto.MeasurementName;
            measurement.MeasurementDescription = measurementDto.MeasurementDescription;
            measurement.MeasurementType = measurementDto.MeasurementType;
            await MeasurementDao.Instance.CreateAsync(measurement);

            return;
        }

        public async Task DeleteMeasurement(int measurementID)
        {
            var measurement = await MeasurementDao.Instance.GetMeasurementID(measurementID);
            await MeasurementDao.Instance.RemoveAsync(measurement);

            return;
        }

        public async Task<IEnumerable<MeasurementDto>> GetAllMeasureInFlatfrom()
        {
            var measurements = await MeasurementDao.Instance.GetAllAsync();
            return _mapper.Map<IEnumerable<MeasurementDto>>(measurements);
        }

        public async Task<MeasurementDto> GetMeasurementByID(int measurementID)
        {
            var measurement = await MeasurementDao.Instance.GetMeasurementID(measurementID);

            return _mapper.Map<MeasurementDto>(measurement);
        }

        public async Task<MeasurementDto> GetMeasurementInFlatfrom(string measurementName)
        {
            var measurement = await MeasurementDao.Instance.GetMeasuremnetName(measurementName);

            return _mapper.Map<MeasurementDto>(measurement);
        }
    }
}
