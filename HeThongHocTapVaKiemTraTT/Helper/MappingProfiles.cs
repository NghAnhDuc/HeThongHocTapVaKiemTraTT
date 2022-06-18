using AutoMapper;
using HeThongHocTapVaKiemTraTT.Dto;
using HeThongHocTapVaKiemTraTT.Models;

namespace HeThongHocTapVaKiemTraTT.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<Class, ClassDto>();
            CreateMap<Semester, SemesterDto>();
            CreateMap<Schedule, ScheduleDto>();
        }
    }
}
