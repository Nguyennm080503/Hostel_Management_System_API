using Dtos.Hiring;
using Repository.Interface;
using Service.Exception;
using Service.Interface;

namespace Service.Implement
{
    public class MemberHiringService : IMemberHiringService
    {
        private readonly IMemberHiringRepository _repository;
        private readonly IHiringHostelRepository _hostelRepository;
        public MemberHiringService(IMemberHiringRepository repository, IHiringHostelRepository hiringHostelRepository)
        {
            _repository = repository;
            _hostelRepository = hiringHostelRepository;
        }

        public async Task CreateMember(NewHiringMemberDto memberDto)
        {
            var hiring = await _hostelRepository.GetHiringByID(memberDto.HiringRoomHostelID);
            if (hiring == null)
            {
                throw new ServiceException("Yêu cầu không tồn tại để tạo thành viên phòng !");
            }
            await _repository.CreateNewMember(memberDto);

            return;
        }
    }
}
