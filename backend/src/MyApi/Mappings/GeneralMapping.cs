using AutoMapper;
using MyApi.Models.DTOs.AboutMeDtos;
using MyApi.Models.DTOs.EducationDtos;
using MyApi.Models.DTOs.ExperienceDtos;
using MyApi.Models.DTOs.LanguageDtos;
using MyApi.Models.DTOs.ProjectDtos;
using MyApi.Models.DTOs.SkillDtos;
using MyApi.Models.Entities;

namespace MyApi.Mappings;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        #region Project
        // Create: DTO -> Entity
        CreateMap<CreateProjectDto, Project>()
            .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src =>
                src.Descriptions.Select(value => new ProjectDescription
                {
                    Value = value,
                    CreatedDate = DateTime.UtcNow
                })));

        // Update: DTO -> Mevcut Entity
        CreateMap<UpdateProjectDto, Project>()
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.Descriptions, opt => opt.Ignore()); // Description'ları manuel yöneteceğiz (Clear/Add mantığı için)

        // Listeleme: Entity -> DTOs
        CreateMap<Project, ResultProjectDto>()
            .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src =>
                src.Descriptions.Select(x => x.Value).ToList()));

        CreateMap<Project, ResultProjectForUiDto>()
            .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src =>
                src.Descriptions.Select(x => x.Value).ToList()));
        #endregion

        #region Experience
        CreateMap<CreateExperienceDto, Experience>()
            .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src =>
                src.Descriptions.Select(value => new ExperienceDescription
                {
                    Value = value,
                    CreatedDate = DateTime.UtcNow
                })));

        CreateMap<UpdateExperienceDto, Experience>()
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.Descriptions, opt => opt.Ignore());

        CreateMap<Experience, ResultExperienceDto>()
            .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src =>
                src.Descriptions.Select(x => x.Value).ToList()));

        CreateMap<Experience, ResultExperienceForUiDto>()
            .ForMember(dest => dest.Descriptions, opt => opt.MapFrom(src =>
                src.Descriptions.Select(x => x.Value).ToList()));
        #endregion

        #region Skill
        CreateMap<CreateSkillDto, Skill>();
        CreateMap<UpdateSkillDto, Skill>();
        CreateMap<Skill, ResultSkillDto>();
        CreateMap<Skill, ResultForUiSkillDto>();
        #endregion

        #region AboutMe
        CreateMap<CreateAboutMeDto, AboutMe>();
        CreateMap<UpdateAboutMeDto, AboutMe>();
        CreateMap<AboutMe, ResultAboutMeDto>();
        CreateMap<AboutMe, ResultForUiAboutMeDto>();
        #endregion

        #region Language
        CreateMap<CreateLanguageDto, Language>();
        CreateMap<UpdateLanguageDto, Language>();
        CreateMap<Language, ResultLanguageDto>();
        CreateMap<Language, ResultForUiLanguageDto>();
        #endregion

        #region Education
        CreateMap<CreateEducationDto, Education>();
        CreateMap<UpdateEducationDto, Education>();
        CreateMap<Education, ResultEducationDto>();
        CreateMap<Education, ResultForUiEducationDto>();
        #endregion
    }
}