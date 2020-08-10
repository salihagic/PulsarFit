using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using PulsarFit.CORE.Domain;
using PulsarFit.CORE.Helpers;
using PulsarFit.DAL.EF;
using PulsarFit.DAL.Services;
using static PulsarFit.CORE.Constants.Enumerations;
using static Pulsar.MultimediaFileProvider.Client.PulsarEnumerations;

namespace PulsarFit.DAL.Helpers
{
    public class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            var databaseContext = serviceProvider.GetService<DatabaseContext>();

            if (databaseContext == null)
                return;

            //databaseContext.Database.EnsureDeleted();
            databaseContext.Database.EnsureCreated();

            //ReinitializeGeolocations(serviceProvider);
            ReinitializeGeolocationsLight(serviceProvider, databaseContext);
            Users(serviceProvider, databaseContext);
            ExerciseCategories(serviceProvider, databaseContext);
            Exercises(serviceProvider, databaseContext);
            Workouts(serviceProvider, databaseContext);
            Plans(serviceProvider, databaseContext);
        }

        public static void Users(IServiceProvider serviceProvider, DatabaseContext databaseContext)
        {
            if (databaseContext.Users.Any())
                return;

            var usersService = serviceProvider.GetService<IUsersService>();

            usersService.Add<ExecutionUser>(new User
            {
                Username = "demo.superadmin",
                Email = "demo.superadmin@example.com",
                PasswordHash = "demo",
                FirstName = "Demo",
                LastName = "Superadmin",
                Gender = Gender.Male,
                CityId = databaseContext.Cities.FirstOrDefault()?.Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/736716/pexels-photo-736716.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                    ThumbnailUrl = "https://images.pexels.com/photos/736716/pexels-photo-736716.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                },
                UserRoles = new List<UserRole> { new UserRole { Role = Role.Superadmin } }
            }, null).Wait();

            usersService.Add<ExecutionUser>(new User
            {
                Username = "demo.admin",
                Email = "demo.admin@example.com",
                PasswordHash = "demo",
                FirstName = "Demo",
                LastName = "Admin",
                Gender = Gender.Male,
                CityId = databaseContext.Cities.FirstOrDefault()?.Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/1222271/pexels-photo-1222271.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                    ThumbnailUrl = "https://images.pexels.com/photos/1222271/pexels-photo-1222271.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                },
                UserRoles = new List<UserRole> { new UserRole { Role = Role.Admin } }
            }, null).Wait();

            usersService.Add<ExecutionUser>(new User
            {
                Username = "demo.trainer",
                Email = "demo.trainer@example.com",
                PasswordHash = "demo",
                FirstName = "Demo",
                LastName = "Trainer",
                Gender = Gender.Male,
                CityId = databaseContext.Cities.FirstOrDefault()?.Id,                
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                    ThumbnailUrl = "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                },
                UserRoles = new List<UserRole> { new UserRole { Role = Role.Trainer } },
                Trainer = new Trainer
                {
                    LicenseNumber = "RJIGVOERIJ09REG099RE0G9"
                }
            }, null).Wait();

            usersService.Add<ExecutionUser>(new User
            {
                Username = "demo.client",
                Email = "demo.client@example.com",
                PasswordHash = "demo",
                FirstName = "Demo",
                LastName = "Client",
                Gender = Gender.Male,
                CityId = databaseContext.Cities.FirstOrDefault()?.Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/1239291/pexels-photo-1239291.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                    ThumbnailUrl = "https://images.pexels.com/photos/1239291/pexels-photo-1239291.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                },
                UserRoles = new List<UserRole> { new UserRole { Role = Role.Client } }
            }, null).Wait();
        }

        public static void ExerciseCategories(IServiceProvider serviceProvider, DatabaseContext databaseContext)
        {
            if (databaseContext.ExerciseCategories.Any())
                return;

            databaseContext.ExerciseCategories.Add(new ExerciseCategory { Name = "Abs & Core" });
            databaseContext.ExerciseCategories.Add(new ExerciseCategory { Name = "Upper body" });
            databaseContext.ExerciseCategories.Add(new ExerciseCategory { Name = "Lower body" });
            databaseContext.ExerciseCategories.Add(new ExerciseCategory { Name = "Cardio" });
            databaseContext.ExerciseCategories.Add(new ExerciseCategory { Name = "Streching" });
            databaseContext.ExerciseCategories.Add(new ExerciseCategory { Name = "Yoga" });

            databaseContext.SaveChanges();
        }

        public static void Exercises(IServiceProvider serviceProvider, DatabaseContext databaseContext)
        {
            if (databaseContext.Exercises.Any())
                return;

            var description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

            databaseContext.Exercises.Add(new Exercise
            {
                Name = "Warior III",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/1552242/pexels-photo-1552242.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "High Knees",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/1954524/pexels-photo-1954524.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "Heisman Lunges",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/17840/pexels-photo.jpg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "Mountain Walkers",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/416809/pexels-photo-416809.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "Standing Torso Twist",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/2247179/pexels-photo-2247179.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "Back Plank & Kick",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/414029/pexels-photo-414029.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "Alternating Leg Raises",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/136404/pexels-photo-136404.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "Arm Raise Plank",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/38630/bodybuilder-weight-training-stress-38630.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "Bridge Kick",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/917653/pexels-photo-917653.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=2000",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "Supine Marching",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/2294403/pexels-photo-2294403.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "V Sit Rowing",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/116077/pexels-photo-116077.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "Walking Plank",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/3253501/pexels-photo-3253501.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "Crow Pose",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/136405/pexels-photo-136405.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });
            databaseContext.Exercises.Add(new Exercise
            {
                Name = "Grasshopper Push-Ups",
                IsPublic = true,
                Description = description,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/3289711/pexels-photo-3289711.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                ExerciseCategoryId = databaseContext.ExerciseCategories.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id
            });

            databaseContext.SaveChanges();
        }

        public static void Workouts(IServiceProvider serviceProvider, DatabaseContext databaseContext)
        {
            if (databaseContext.Plans.Any())
                return;

            databaseContext.Workouts.Add(new Workout
            {
                Name = "Full Body",
                IsPublic = true,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/1552242/pexels-photo-1552242.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                WorkoutExercises = new List<WorkoutExercise>
                {
                    new WorkoutExercise { NumberOfRepetitions = 14, OrderNumber = 1, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 2, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 3, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 20, OrderNumber = 4, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 5, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 6, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 7, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 8, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 9, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 10, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                }
            });
            databaseContext.Workouts.Add(new Workout
            {
                Name = "Insane Six Pack",
                IsPublic = true,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/1431282/pexels-photo-1431282.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                WorkoutExercises = new List<WorkoutExercise>
                {
                    new WorkoutExercise { NumberOfRepetitions = 14, OrderNumber = 1, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 2, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 3, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 20, OrderNumber = 4, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 5, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 6, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 7, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 8, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 9, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 10, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                }
            });
            databaseContext.Workouts.Add(new Workout
            {
                Name = "Complex Core",
                IsPublic = true,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/17840/pexels-photo.jpg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                WorkoutExercises = new List<WorkoutExercise>
                {
                    new WorkoutExercise { NumberOfRepetitions = 14, OrderNumber = 1, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 2, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 3, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 20, OrderNumber = 4, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 5, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 6, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 7, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 8, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 9, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 10, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                }
            });
            databaseContext.Workouts.Add(new Workout
            {
                Name = "Strong Back",
                IsPublic = true,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/38630/bodybuilder-weight-training-stress-38630.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                WorkoutExercises = new List<WorkoutExercise>
                {
                    new WorkoutExercise { NumberOfRepetitions = 14, OrderNumber = 1, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 2, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 3, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 20, OrderNumber = 4, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 5, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 6, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 7, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 8, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 9, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 10, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                }
            });
            databaseContext.Workouts.Add(new Workout
            {
                Name = "Complex Lower Body",
                IsPublic = true,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/1552106/pexels-photo-1552106.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                WorkoutExercises = new List<WorkoutExercise>
                {
                    new WorkoutExercise { NumberOfRepetitions = 14,  OrderNumber = 1, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10,  OrderNumber = 2, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15,  OrderNumber = 3, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 20,  OrderNumber = 4, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15,  OrderNumber = 5, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10,  OrderNumber = 6, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15,  OrderNumber = 7, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50,  OrderNumber = 8, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15,  OrderNumber = 9, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50,  OrderNumber = 10, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                }
            });
            databaseContext.Workouts.Add(new Workout
            {
                Name = "Chest And Arms",
                IsPublic = true,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/1229356/pexels-photo-1229356.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                WorkoutExercises = new List<WorkoutExercise>
                {
                    new WorkoutExercise { NumberOfRepetitions = 14, OrderNumber = 1, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 2, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 3, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 20, OrderNumber = 4, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 5, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 6, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 7, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 8, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 9, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 10, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                }
            });
            databaseContext.Workouts.Add(new Workout
            {
                Name = "Explosive Power Jumbs",
                IsPublic = true,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/260447/pexels-photo-260447.jpeg?auto=compress&cs=tinysrgb&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                WorkoutExercises = new List<WorkoutExercise>
                {
                    new WorkoutExercise { NumberOfRepetitions = 14, OrderNumber = 1, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 2, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 3, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 20, OrderNumber = 4, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 5, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 6, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 7, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 8, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 9, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 10, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                }
            });
            databaseContext.Workouts.Add(new Workout
            {
                Name = "Shoulder And Upper Back",
                IsPublic = true,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/1756959/pexels-photo-1756959.jpeg?auto=compress&cs=tinysrgb&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                WorkoutExercises = new List<WorkoutExercise>
                {
                    new WorkoutExercise { NumberOfRepetitions = 14, OrderNumber = 1, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 2, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 3, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 20, OrderNumber = 4, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 5, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 6, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 7, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 8, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 9, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 10, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                }
            });
            databaseContext.Workouts.Add(new Workout
            {
                Name = "Complex Upper Body",
                IsPublic = true,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/669582/pexels-photo-669582.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                WorkoutExercises = new List<WorkoutExercise>
                {
                    new WorkoutExercise { NumberOfRepetitions = 14, OrderNumber = 1, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 2, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 3, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 20, OrderNumber = 4, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 5, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 6, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 7, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 8, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 9, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 10, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                }
            });
            databaseContext.Workouts.Add(new Workout
            {
                Name = "Amazing Chest",
                IsPublic = true,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/2078062/pexels-photo-2078062.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                WorkoutExercises = new List<WorkoutExercise>
                {
                    new WorkoutExercise { NumberOfRepetitions = 14, OrderNumber = 1, ExerciseId = databaseContext.Exercises.AsEnumerable().AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 2, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 3, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 20, OrderNumber = 4, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 5, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 10, OrderNumber = 6, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 7, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 8, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 15, OrderNumber = 9, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new WorkoutExercise { NumberOfRepetitions = 50, OrderNumber = 10, ExerciseId = databaseContext.Exercises.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                }
            });

            databaseContext.SaveChanges();
        }

        public static void Plans(IServiceProvider serviceProvider, DatabaseContext databaseContext)
        {
            if (databaseContext.Plans.Any())
                return;

            databaseContext.Plans.Add(new Plan
            {
                Name = "Full Body Gainer",
                IsPublic = true,
                Description = "Prepare your body for the increased demand in the next 4 weeks",
                PlanLevel = PlanLevel.Advanced,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/1954524/pexels-photo-1954524.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                PlanWorkouts = new List<PlanWorkout>
                {
                    new PlanWorkout { OrderNumber = 1, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 2, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 3, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 4, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 5, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 6, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 7, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 8, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 9, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 10, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                },
                PlanTags = new List<PlanTag>
                {
                    new PlanTag { Name = "Strength Building" },
                    new PlanTag { Name = "Full-Body Exercise" },
                    new PlanTag { Name = "Low Rep Counts" },
                    new PlanTag { Name = "Resistance Exercises" },
                },
                PlanResults = new List<PlanResult>
                {
                    new PlanResult { Name = "Build muscle efectively" },
                    new PlanResult { Name = "Build functional strength" },
                    new PlanResult { Name = "Build discipline, look better, feel stronger" },
                }
            });
            databaseContext.Plans.Add(new Plan
            {
                Name = "Muscle & Strength Starter",
                IsPublic = true,
                Description = "Prepare your body for the increased demand in the next 4 weeks",
                PlanLevel = PlanLevel.Advanced,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/2261477/pexels-photo-2261477.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                PlanWorkouts = new List<PlanWorkout>
                {
                    new PlanWorkout { OrderNumber = 1, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 2, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 3, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 4, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 5, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 6, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 7, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 8, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 9, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 10, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                },
                PlanTags = new List<PlanTag>
                {
                    new PlanTag { Name = "Strength Building" },
                    new PlanTag { Name = "Full-Body Exercise" },
                    new PlanTag { Name = "Low Rep Counts" },
                    new PlanTag { Name = "Resistance Exercises" },
                },
                PlanResults = new List<PlanResult>
                {
                    new PlanResult { Name = "Build muscle efectively" },
                    new PlanResult { Name = "Build functional strength" },
                    new PlanResult { Name = "Build discipline, look better, feel stronger" },
                }
            });
            databaseContext.Plans.Add(new Plan
            {
                Name = "Split Body Gainer",
                IsPublic = true,
                Description = "Prepare your body for the increased demand in the next 4 weeks",
                PlanLevel = PlanLevel.Advanced,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/1552249/pexels-photo-1552249.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                PlanWorkouts = new List<PlanWorkout>
                {
                    new PlanWorkout { OrderNumber = 1, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 2, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 3, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 4, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 5, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 6, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 7, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 8, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 9, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 10, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                },
                PlanTags = new List<PlanTag>
                {
                    new PlanTag { Name = "Strength Building" },
                    new PlanTag { Name = "Full-Body Exercise" },
                    new PlanTag { Name = "Low Rep Counts" },
                    new PlanTag { Name = "Resistance Exercises" },
                },
                PlanResults = new List<PlanResult>
                {
                    new PlanResult { Name = "Build muscle efectively" },
                    new PlanResult { Name = "Build functional strength" },
                    new PlanResult { Name = "Build discipline, look better, feel stronger" },
                }
            });
            databaseContext.Plans.Add(new Plan
            {
                Name = "Explosive Tone Up",
                IsPublic = true,
                Description = "Prepare your body for the increased demand in the next 4 weeks",
                PlanLevel = PlanLevel.Advanced,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/2827400/pexels-photo-2827400.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                PlanWorkouts = new List<PlanWorkout>
                {
                    new PlanWorkout { OrderNumber = 1, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 2, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 3, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 4, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 5, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 6, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 7, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 8, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 9, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 10, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                },
                PlanTags = new List<PlanTag>
                {
                    new PlanTag { Name = "Strength Building" },
                    new PlanTag { Name = "Full-Body Exercise" },
                    new PlanTag { Name = "Low Rep Counts" },
                    new PlanTag { Name = "Resistance Exercises" },
                },
                PlanResults = new List<PlanResult>
                {
                    new PlanResult { Name = "Build muscle efectively" },
                    new PlanResult { Name = "Build functional strength" },
                    new PlanResult { Name = "Build discipline, look better, feel stronger" },
                }
            });
            databaseContext.Plans.Add(new Plan
            {
                Name = "Muscle Shredder",
                IsPublic = true,
                Description = "Prepare your body for the increased demand in the next 4 weeks",
                PlanLevel = PlanLevel.Advanced,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/2261483/pexels-photo-2261483.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                PlanWorkouts = new List<PlanWorkout>
                {
                    new PlanWorkout { OrderNumber = 1, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 2, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 3, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 4, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 5, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 6, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 7, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 8, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 9, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 10, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                },
                PlanTags = new List<PlanTag>
                {
                    new PlanTag { Name = "Strength Building" },
                    new PlanTag { Name = "Full-Body Exercise" },
                    new PlanTag { Name = "Low Rep Counts" },
                    new PlanTag { Name = "Resistance Exercises" },
                },
                PlanResults = new List<PlanResult>
                {
                    new PlanResult { Name = "Build muscle efectively" },
                    new PlanResult { Name = "Build functional strength" },
                    new PlanResult { Name = "Build discipline, look better, feel stronger" },
                }
            });
            databaseContext.Plans.Add(new Plan
            {
                Name = "Fit & Strong",
                IsPublic = true,
                Description = "Prepare your body for the increased demand in the next 4 weeks",
                PlanLevel = PlanLevel.Advanced,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/2261485/pexels-photo-2261485.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                PlanWorkouts = new List<PlanWorkout>
                {
                    new PlanWorkout { OrderNumber = 1, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 2, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 3, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 4, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 5, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 6, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 7, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 8, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 9, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 10, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                },
                PlanTags = new List<PlanTag>
                {
                    new PlanTag { Name = "Strength Building" },
                    new PlanTag { Name = "Full-Body Exercise" },
                    new PlanTag { Name = "Low Rep Counts" },
                    new PlanTag { Name = "Resistance Exercises" },
                },
                PlanResults = new List<PlanResult>
                {
                    new PlanResult { Name = "Build muscle efectively" },
                    new PlanResult { Name = "Build functional strength" },
                    new PlanResult { Name = "Build discipline, look better, feel stronger" },
                }
            });
            databaseContext.Plans.Add(new Plan
            {
                Name = "Mens Body Special",
                IsPublic = true,
                Description = "Prepare your body for the increased demand in the next 4 weeks",
                PlanLevel = PlanLevel.Advanced,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/3112004/pexels-photo-3112004.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                PlanWorkouts = new List<PlanWorkout>
                {
                    new PlanWorkout { OrderNumber = 1, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 2, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 3, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 4, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 5, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 6, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 7, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 8, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 9, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 10, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                },
                PlanTags = new List<PlanTag>
                {
                    new PlanTag { Name = "Strength Building" },
                    new PlanTag { Name = "Full-Body Exercise" },
                    new PlanTag { Name = "Low Rep Counts" },
                    new PlanTag { Name = "Resistance Exercises" },
                },
                PlanResults = new List<PlanResult>
                {
                    new PlanResult { Name = "Build muscle efectively" },
                    new PlanResult { Name = "Build functional strength" },
                    new PlanResult { Name = "Build discipline, look better, feel stronger" },
                }
            });
            databaseContext.Plans.Add(new Plan
            {
                Name = "Fit Life Starter",
                IsPublic = true,
                Description = "Prepare your body for the increased demand in the next 4 weeks",
                PlanLevel = PlanLevel.Advanced,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/1552106/pexels-photo-1552106.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                PlanWorkouts = new List<PlanWorkout>
                {
                    new PlanWorkout { OrderNumber = 1, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 2, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 3, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 4, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 5, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 6, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 7, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 8, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 9, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 10, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                },
                PlanTags = new List<PlanTag>
                {
                    new PlanTag { Name = "Strength Building" },
                    new PlanTag { Name = "Full-Body Exercise" },
                    new PlanTag { Name = "Low Rep Counts" },
                    new PlanTag { Name = "Resistance Exercises" },
                },
                PlanResults = new List<PlanResult>
                {
                    new PlanResult { Name = "Build muscle efectively" },
                    new PlanResult { Name = "Build functional strength" },
                    new PlanResult { Name = "Build discipline, look better, feel stronger" },
                }
            });
            databaseContext.Plans.Add(new Plan
            {
                Name = "Full Stack Fitness",
                IsPublic = true,
                Description = "Prepare your body for the increased demand in the next 4 weeks",
                PlanLevel = PlanLevel.Advanced,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/2294361/pexels-photo-2294361.jpeg?auto=compress&cs=tinysrgb&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                PlanWorkouts = new List<PlanWorkout>
                {
                    new PlanWorkout { OrderNumber = 1, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 2, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 3, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 4, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 5, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 6, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 7, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 8, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 9, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 10, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                },
                PlanTags = new List<PlanTag>
                {
                    new PlanTag { Name = "Strength Building" },
                    new PlanTag { Name = "Full-Body Exercise" },
                    new PlanTag { Name = "Low Rep Counts" },
                    new PlanTag { Name = "Resistance Exercises" },
                },
                PlanResults = new List<PlanResult>
                {
                    new PlanResult { Name = "Build muscle efectively" },
                    new PlanResult { Name = "Build functional strength" },
                    new PlanResult { Name = "Build discipline, look better, feel stronger" },
                }
            });
            databaseContext.Plans.Add(new Plan
            {
                Name = "Endurance Builder",
                IsPublic = true,
                Description = "Prepare your body for the increased demand in the next 4 weeks",
                PlanLevel = PlanLevel.Advanced,
                StrengthLevel = StrengthLevel.High,
                CardioLevel = CardioLevel.Medium,
                MultimediaFile = new MultimediaFile
                {
                    Url = "https://images.pexels.com/photos/416778/pexels-photo-416778.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=200&w=200",
                    MultimediaFileType = MultimediaFileTypes.Image
                },
                TrainerId = databaseContext.Trainers.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id,
                PlanWorkouts = new List<PlanWorkout>
                {
                    new PlanWorkout { OrderNumber = 1, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 2, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 3, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 4, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 5, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 6, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 7, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 8, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 9, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                    new PlanWorkout { OrderNumber = 10, WorkoutId = databaseContext.Workouts.AsEnumerable().OrderBy(x => Guid.NewGuid().ToString()).First().Id },
                },
                PlanTags = new List<PlanTag>
                {
                    new PlanTag { Name = "Strength Building" },
                    new PlanTag { Name = "Full-Body Exercise" },
                    new PlanTag { Name = "Low Rep Counts" },
                    new PlanTag { Name = "Resistance Exercises" },
                },
                PlanResults = new List<PlanResult>
                {
                    new PlanResult { Name = "Build muscle efectively" },
                    new PlanResult { Name = "Build functional strength" },
                    new PlanResult { Name = "Build discipline, look better, feel stronger" },
                }
            });

            databaseContext.SaveChanges();
        }

        public static void ReinitializeGeolocationsLight(IServiceProvider serviceProvider, DatabaseContext databaseContext)
        {
            if (databaseContext.Countries.Any())
                return;

            databaseContext.Cities.Add(new City
            {
                Name = "Mostar",
                Country = new Country
                {
                    Name = "Bosna i Hercegovina",
                    Currency = new Currency
                    {
                        Name = "US Dollar",
                        Code = "USD",
                        Symbol = "$"
                    }
                }
            });

            databaseContext.SaveChanges();
        }

        public static void ReinitializeGeolocations(IServiceProvider serviceProvider, DatabaseContext databaseContext)
        {
            try
            {
                if (!databaseContext.Countries.Any())
                {
                    string jsonCountries = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Helpers/MockData/countries.json");
                    var countries = JsonConvert.DeserializeObject<List<Geolocations.Country>>(jsonCountries).Select(x => new Country
                    {
                        Code = x.code.ToUpper(),
                        Name = x.name,
                        Currency = x.primary_currency != null ? new Currency
                        {
                            Code = x.primary_currency.code,
                            Name = x.primary_currency.name,
                            Symbol = x.primary_currency.symbol
                        } : null,
                        Cities = x.cities?.Select(y => new City
                        {
                            Name = y.name,
                            Latitude = y.latitude,
                            Longitude = y.longitude
                        })?.ToList()
                    }).ToList();

                    var currencies = countries.Where(x => x.Currency != null).Select(x => x.Currency);

                    databaseContext.Currencies.AddRange(currencies);
                    databaseContext.SaveChanges();

                    countries.ForEach(x =>
                    {
                        if (x.Currency != null)
                        {
                            x.Currency = currencies.FirstOrDefault(y => y.Code == x.Currency.Code);
                        }
                    });

                    databaseContext.Countries.AddRange(countries);
                    databaseContext.SaveChanges();
                }

                if (!databaseContext.Languages.Any())
                {
                    string json2 = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Helpers/MockData/languages.json");
                    var languages = JsonConvert.DeserializeObject<List<Geolocations.Language>>(json2).Select(x => new Language
                    {
                        Code = x.code.ToUpper(),
                        Name = x.name
                    });

                    databaseContext.Languages.AddRange(languages);
                    databaseContext.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }
        }

        public class Geolocations
        {
            public class Country
            {
                public string code { get; set; }
                public string name { get; set; }
                public Currency primary_currency { get; set; }
                public List<City> cities { get; set; }
            }

            public class City
            {
                public string name { get; set; }
                public double latitude { get; set; }
                public double longitude { get; set; }
            }

            public class Currency
            {
                public string code { get; set; }
                public string name { get; set; }
                public string symbol { get; set; }
            }

            public class Language
            {
                public string code { get; set; }
                public string name { get; set; }
            }
        }
    }
}
