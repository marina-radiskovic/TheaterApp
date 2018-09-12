using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Theater.MVC.Models.Validation
{
    public class EditPlayViewModelValidator : AbstractValidator<EditPlayViewModel>
    {
        public EditPlayViewModelValidator()
        {
            RuleFor(x => x.StartDate)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Date can't be in past.");

            RuleFor(x => x.EndDate)
                .GreaterThanOrEqualTo(x => x.StartDate.Value).WithMessage("End date must be after the start date.")
                .When(x => x.StartDate.HasValue)
                .GreaterThan(DateTime.Now).WithMessage("Date can't be in past.");

            RuleFor(x => x.File)
                .Must(IsImage).WithMessage("File must be image!")
                .When(x => x.File != null);

            RuleFor(x => x.Time).SetValidator(new PlayTimeTakenValidator());
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