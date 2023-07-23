using System;
using anketdeneme.Models;
using FluentValidation;

namespace anketdeneme.Validations
{
	public class SoruValidator:AbstractValidator<Sorular>
	{
		public SoruValidator()
		{
			RuleFor(x => x.Ad).NotEmpty().WithMessage("İsim alanı boş bırakılamaz.").MaximumLength(150);
			RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Email boş bırakılamaz ve geçerli bir mail adresi girin.").MaximumLength(300);
			RuleFor(x => x.Departman).NotEmpty().WithMessage("Departman Boş Bırakılamaz");
			RuleFor(x => x.MesajKutusu).NotEmpty().WithMessage("Mesaj Kutusu Boş Bırakılamaz");
			RuleFor(x => x.Soyad).NotEmpty().WithMessage("Soyad Boş bırakılamaz");
		}
	}
}

