using FlightTicketWebApi.Models;
using FluentValidation;

namespace FlightTicketWebApi.Validation;

public class FlightSearchModelValidator : AbstractValidator<FlightSearchModel>
{
    public FlightSearchModelValidator()
    {
        RuleFor(x => x.Origin).NotEmpty().WithMessage("Kalkış noktası boş olamaz.");
        RuleFor(x => x.Destination).NotEmpty().WithMessage("Varış noktası boş olamaz.")
            .NotEqual(x => x.Origin).WithMessage("Kalkış ve varış noktaları aynı olamaz.");

        RuleFor(x => x.DepartureDate).NotEmpty().WithMessage("Gidiş tarihi boş olamaz.")
            .LessThanOrEqualTo(x => x.ReturnDate).WithMessage("Gidiş tarihi, dönüş tarihinden büyük olamaz.");

        RuleFor(x => x.ReturnDate).NotEmpty().WithMessage("Dönüş tarihi boş olamaz."); //Case sadece gidiş-dönüş üzerine kurgulandığı için returnDate bilgisini de zorunlu kıldım
    }
}
