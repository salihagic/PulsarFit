using AutoMapper;
using Pulsar.MultimediaFileProvider.Client;
using PulsarFit.CORE.Domain;

namespace PulsarFit.CORE.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            MapCity();

            MapClientPlan();

            MapClient();

            MapCountry();

            MapCurrency();

            MapExerciseCategory();

            MapExercise();

            MapLanguage();

            MapMultimediaFile();

            MapPlanResult();

            MapPlan();
            
            MapPlanTag();

            MapPlanWorkout();

            MapTrainer();

            MapUserRole();

            MapUser();

            MapUserSession();

            MapUserSetting();

            MapWorkoutExercise();

            MapWorkout();

            MapWorkoutSession();
        }

        void MapCity()
        {
            CreateMap<City, CityDTO>();
            CreateMap<CityInsertRequest, City>();
            CreateMap<CityDTO, CityUpdateRequest>();
            CreateMap<CityUpdateRequest, City>();
        }

        void MapClientPlan()
        {
            CreateMap<ClientPlan, ClientPlanDTO>();
            CreateMap<ClientPlanInsertRequest, ClientPlan>();
            CreateMap<ClientPlanDTO, ClientPlanUpdateRequest>();
            CreateMap<ClientPlanUpdateRequest, ClientPlan>();
        }

        void MapClient()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<ClientInsertRequest, Client>();
            CreateMap<ClientDTO, ClientUpdateRequest>();
            CreateMap<ClientUpdateRequest, Client>();
        }

        void MapCountry()
        {
            CreateMap<Country, CountryDTO>();
            CreateMap<CountryInsertRequest, Country>();
            CreateMap<CountryDTO, CountryUpdateRequest>();
            CreateMap<CountryUpdateRequest, Country>();
        }

        void MapCurrency()
        {
            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyInsertRequest, Currency>();
            CreateMap<CurrencyDTO, CurrencyUpdateRequest>();
            CreateMap<CurrencyUpdateRequest, Currency>();
        }

       void MapExerciseCategory()
        {
            CreateMap<ExerciseCategory, ExerciseCategoryDTO>();
            CreateMap<ExerciseCategoryInsertRequest, ExerciseCategory>();
            CreateMap<ExerciseCategoryDTO, ExerciseCategoryUpdateRequest>();
            CreateMap<ExerciseCategoryUpdateRequest, ExerciseCategory>();
        }

        void MapExercise()
        {
            CreateMap<Exercise, ExerciseDTO>();
            CreateMap<ExerciseInsertRequest, Exercise>();
            CreateMap<ExerciseDTO, ExerciseUpdateRequest>();
            CreateMap<ExerciseUpdateRequest, Exercise>();
        }

        void MapLanguage()
        {
            CreateMap<Language, LanguageDTO>();
            CreateMap<LanguageInsertRequest, Language>();
            CreateMap<LanguageDTO, LanguageUpdateRequest>();
            CreateMap<LanguageUpdateRequest, Language>();
        }

        void MapMultimediaFile()
        {
            CreateMap<MultimediaFile, MultimediaFileDTO>();
            CreateMap<MultimediaFileInsertRequest, PulsarMultimediaFileInsertRequest>();
            CreateMap<MultimediaFileDTO, MultimediaFileUpdateRequest>();
            CreateMap<MultimediaFileUpdateRequest, MultimediaFile>();
            CreateMap<PulsarMultimediaFile, MultimediaFile>();
        }

        void MapPlanResult()
        {
            CreateMap<PlanResult, PlanResultDTO>();
            CreateMap<PlanResultInsertRequest, PlanResult>();
            CreateMap<PlanResultDTO, PlanResultUpdateRequest>();
            CreateMap<PlanResultUpdateRequest, PlanResult>();
        }

        void MapPlan()
        {
            CreateMap<Plan, PlanDTO>();
            CreateMap<PlanInsertRequest, Plan>();
            CreateMap<PlanDTO, PlanUpdateRequest>();
            CreateMap<PlanUpdateRequest, Plan>();
        }

        void MapPlanTag()
        {
            CreateMap<PlanTag, PlanTagDTO>();
            CreateMap<PlanTagInsertRequest, PlanTag>();
            CreateMap<PlanTagDTO, PlanTagUpdateRequest>();
            CreateMap<PlanTagUpdateRequest, PlanTag>();
        }

        void MapPlanWorkout()
        {
            CreateMap<PlanWorkout, PlanWorkoutDTO>();
            CreateMap<PlanWorkoutInsertRequest, PlanWorkout>();
            CreateMap<PlanWorkoutDTO, PlanWorkoutUpdateRequest>();
            CreateMap<PlanWorkoutUpdateRequest, PlanWorkout>();
        }

        void MapTrainer()
        {
            CreateMap<Trainer, TrainerDTO>();
            CreateMap<TrainerInsertRequest, Trainer>();
            CreateMap<TrainerDTO, TrainerUpdateRequest>();
            CreateMap<TrainerUpdateRequest, Trainer>();
        }

        void MapUserRole()
        {
            CreateMap<UserRole, UserRoleDTO>();
            CreateMap<UserRoleInsertRequest, UserRole>();
            CreateMap<UserRoleUpdateRequest, UserRole>();
            CreateMap<UserRoleSearchRequest, UserRoleSearchResponse>();
        }

        void MapUser()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserInsertRequest, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
            CreateMap<UserRegisterRequest, User>();
            CreateMap<UserDTO, UserUpdateRequest>();
            CreateMap<UserUpdateRequest, User>();
            CreateMap<UserDTO, UserUpdateProfileRequest>();
            CreateMap<UserUpdateProfileRequest, User>();
        }

        void MapUserSession()
        {
            CreateMap<UserSession, UserSessionDTO>();
            CreateMap<UserSessionInsertRequest, UserSession>();
            CreateMap<UserSessionUpdateRequest, UserSession>();
            CreateMap<UserSessionSearchRequest, UserSessionSearchResponse>();
        }

        void MapUserSetting()
        {
            CreateMap<UserSetting, UserSettingDTO>();
            CreateMap<UserSettingInsertRequest, UserSetting>();
            CreateMap<UserSettingDTO, UserSettingUpdateRequest>();
            CreateMap<UserSettingUpdateRequest, UserSetting>();
        }        
        
        void MapWorkoutExercise()
        {
            CreateMap<WorkoutExercise, WorkoutExerciseDTO>();
            CreateMap<WorkoutExerciseInsertRequest, WorkoutExercise>();
            CreateMap<WorkoutExerciseDTO, WorkoutExerciseUpdateRequest>();
            CreateMap<WorkoutExerciseUpdateRequest, WorkoutExercise>();
        }        
        
        void MapWorkout()
        {
            CreateMap<Workout, WorkoutDTO>();
            CreateMap<WorkoutInsertRequest, Workout>();
            CreateMap<WorkoutDTO, WorkoutUpdateRequest>();
            CreateMap<WorkoutUpdateRequest, Workout>();
        }
        
        void MapWorkoutSession()
        {
            CreateMap<WorkoutSession, WorkoutSessionDTO>();
            CreateMap<WorkoutSessionInsertRequest, WorkoutSession>();
            CreateMap<WorkoutSessionDTO, WorkoutSessionUpdateRequest>();
            CreateMap<WorkoutSessionUpdateRequest, WorkoutSession>();
        }
    }
}
