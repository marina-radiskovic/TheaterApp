using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Theater.Service.PlayService;

namespace Theater.MVC.Models.Validation
{
    public class PlayTimeTakenValidator : PropertyValidator
    {
        public PlayTimeTakenValidator() : base("This time is taken!") { }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var play = context.Instance as PlayViewModel;
            var playService = new PlayService();

            var taken = playService.PlayTimeTaken(play.StartDate, play.EndDate, play.Time, play.Duration);
            if (taken)
            {
                return false;
            }
            return true;
        }
    }
}