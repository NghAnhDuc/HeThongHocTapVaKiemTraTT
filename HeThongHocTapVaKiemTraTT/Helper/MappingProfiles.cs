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
            CreateMap<AccountDto, Account>();
            CreateMap<Class, ClassDto>();
            CreateMap<ClassDto, Class>();
            CreateMap<Semester, SemesterDto>();
            CreateMap<SemesterDto, Semester>();
            CreateMap<Schedule, ScheduleDto>();
            CreateMap<ScheduleDto, Schedule>();
            CreateMap<Scoreboard, ScoreboardDto>();
            CreateMap<ScoreboardDto, Scoreboard>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectDto, Subject>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();
            CreateMap<Test, TestDto>();
            CreateMap<TestDto, Test>();
        }
    }
}
