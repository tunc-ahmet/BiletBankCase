namespace FlightTicketWebApi.Models
{
    public class FlightOptionModel
    {
        public string? FlightNumber { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public decimal Price { get; set; }
        public string FlightDuration
        {
            get
            {
                //WCF uygulamasında, kalkış ve dönüş saatleri yanlış oluşturulmuş. Kalkış saati, gidiş saatinden sonra gözüküyor.
                //Bundan dolayı işlem sonucu -'li çıktığı için, math.abs kullandım
                TimeSpan duration = ArrivalDateTime - DepartureDateTime;
                return $"{Math.Abs(duration.Hours)} saat, {Math.Abs(duration.Minutes)} dakika";
            }
        }
    }
}
