﻿using System.Collections.Generic;
using PulsarFit.CORE.Helpers;
using static PulsarFit.CORE.Constants.Enumerations;

namespace PulsarFit.CORE.Domain
{
    public class WorkoutDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public StrengthLevel StrengthLevel { get; set; }
        public CardioLevel CardioLevel { get; set; }
        public bool IsPublic { get; set; }
        public int TrainerId { get; set; }
        public int MultimediaFileId { get; set; }

        public TrainerDTO Trainer { get; set; }
        public MultimediaFileDTO MultimediaFile { get; set; }
        public IEnumerable<PlanWorkoutDTO> PlanWorkouts { get; set; }
        public IEnumerable<WorkoutExerciseDTO> WorkoutExercises { get; set; }
    }
}
