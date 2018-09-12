using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Theater.MVC.Models.Validation
{
    public class PlayViewModelValidator : AbstractValidator<PlayViewModel>
    {
        public PlayViewModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("The title is required!");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Please type a short description.");

            RuleFor(x => x.File)
                .NotNull().WithMessage("Please upload a photo.");

            RuleFor(x => x.SelectedActorsIds)
                .NotEmpty().WithMessage("Select actors for this play!");

            RuleFor(x => x.Duration)
                .NotEmpty().WithMessage("How long does this play last?");

            RuleFor(x => x.Time)
                .NotEmpty().WithMessage("Please enter schedule time.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Please enter start date.")
                .GreaterThan(DateTime.Now).WithMessage("Date can't be in past.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("Please enter end date.")
                .GreaterThan(x => x.StartDate.Value).WithMessage("End date must be after the start date.")
                .When(x => x.StartDate.HasValue)
                .GreaterThan(DateTime.Now).WithMessage("Date can't be in past.");

            RuleFor(x => x.File)
                .Must(IsImage).WithMessage("File must be image!")
                .When(x => x.File != null);
            
        }

        private bool IsImage(HttpPostedFileBase file)
        {
            if (file.ContentType.Contains("image"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}