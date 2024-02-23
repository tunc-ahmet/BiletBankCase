BiletBank Case Projesi Kapsamında Yapılanlar;

FlightTicketWebAPI:

- Api projesi oluşturuldu, FlightProvider projesi api projesine WCF olarak eklendi.
- Gerekli modeller ve servisler oluşturuldu, dependency injection kuralları yazıldı.
- Dependency Injection, daha sade görünüm sağlamak için program.cs'ten ayrıştırıldı.
- Oluşturulan Flight servisine tek yönlü ve çift yönlü uçuşlar için metotlar eklendi.
- Controller tarafında çift yönlü metoda istek atacak bir endpoint oluşturuldu.
- Endpointte istenilen modele yönelik fluent validation kullanılarak validasyon kuralları yazıldı.
- WCF projesinin kendi dönüş yapıları olmasına rağmen, proje geniş kapsamlı bir proje olacakmış gibi düşünülerek utilities altında dönüş konsepti oluşturuldu.
- Projede çıkabilecek hatalara yönelik, Global Exception Handler eklendi. Bu sayede; hata kontrolü tek bir yerde sağlanmış olup, tek tip hata mesajı dönülmesi ve kullanıcıya hata detayı verilmemesi sağlandı.
- HealthCheck eklenerek, WCF durum kontrolü sağlandı. url/health üzerinden ulaşılabilir.
- Güvenliğe yönelik middleware eklenerek, server, x-powered-by, x-aspnet-version bilgilerinin headerdan silinmesi sağlanmış olup; yine güvenlik için Content-Security-Policy eklenmiştir.
- Projede oluşturulan modellerle, wcf projesindeki model eşlemelerinde sorun oluşmaması için AutoMapper kullanılmıştır.
- İşlem sonucu kullanıcıya dönülecek mesajlar için Constants oluşturulmuştur.
- Controller ve Business işlemlerine yönelik, test projesi eklenilmiş, ilgili metotlara yönelik test caseleri oluşturulmuştur.

---------------------------------------------------------------------------------------------------------------------------------------

FlightTicketWebUI:

- Default olarak oluşan Home/Index sayfasına yönelik tasarımsal ve dinamiksel geliştirmelerde bulunulmuştur.
- Gidiş ve Varış havalimanlarına yönelik oluşturulan select inputları için Selectize kullanılmıştır.
- Tüm inputların doluluk kontrolünde uyarı mesajları için sweetalert2 kullanılmıştır.
- Uçuş bilgilerinin listelenmesi için ViewComponent oluşturulmuş, uçuş bilgileri bu component içerisine basılmış, component ise ajax sonrası .html komutu ile index sayfasına aktarılmıştır.
- WCF'de uçuşa yönelik detay bilgisi çok az olduğu için, detay bilgisine koltuk seçimi gibi alanlar eklenmiştir.
- Gidiş-Dönüş gibi seçimler için tasarımda Wizard kullanılmıştır.
- Api projesiyle aynı olması amacıyla, utilities altında dönüş konsepti oluşturulmuştur.
- Api linklerine yönelik Common altında ApiUrl classı oluşturulmuş, classı dolduracak bilgiler appsettingse eklenilmiştir. Program.cs içerisinde ilgili classa configure edilmesi sağlanılmıştır.
- Atılacak istekler için business servisleri oluşturulmuş, istekler httpclient üzerinden gerçekleştirilmiştir.


