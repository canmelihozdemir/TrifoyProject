using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrifoyProject.Core.DTOs;

namespace TrifoyProject.Service.Validations
{
    public class PlayerRegisterDTOValidator:AbstractValidator<PlayerRegisterDTO>
    {
        public PlayerRegisterDTOValidator()
        {
            RuleFor(x=>x.UserName).NotNull().WithMessage("{PropertyName} alanı null olamaz!").NotEmpty().WithMessage("{PropertyName} alanı boş olamaz!");
            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} alanı null olamaz").NotEmpty().WithMessage("{PropertyName} alanı boş olamaz");
            RuleFor(x => x.Password!.Length).InclusiveBetween(6, 20).WithMessage("{PropertyName} alanı 6-20 karakter arası olmalıdır");
        }
    }
}
