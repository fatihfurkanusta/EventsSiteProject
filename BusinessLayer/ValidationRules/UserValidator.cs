using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() 
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz.");
            RuleFor(x => x.UserSurname).NotEmpty().WithMessage("Soyadı Boş Olamaz.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla giriş yapmayın.");
        } 
    }
}
