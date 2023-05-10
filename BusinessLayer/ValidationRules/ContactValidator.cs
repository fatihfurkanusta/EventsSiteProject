using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.ContactMail).NotEmpty().WithMessage("Mail adresini boş geçemezsiniz.");

            RuleFor(x => x.ContactName).NotEmpty().WithMessage("Kategori Adı Boş Olamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Olamaz.");
            RuleFor(x => x.ContactName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapın.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 20 karakterden fazla giriş yapmayın.");

        }
    }
}
