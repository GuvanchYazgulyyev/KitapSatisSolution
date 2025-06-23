#  Kitap Satış API (.NET 8 RESTful Uygulama)

Bu proje, kitap satışına yönelik temel işlemleri (ekleme, güncelleme, silme, listeleme) gerçekleştiren bir RESTful API'dir. 
Modern yazılım geliştirme yaklaşımları esas alınarak geliştirilmiştir. Aynı zamanda JWT ile kimlik doğrulama, CQRS yaklaşımı ve unit testler de uygulanmıştır.

---

##  Kullanılan Teknolojiler

- ASP.NET Core 8 (Web API)
- Entity Framework Core (SQL Server & InMemory)
- AutoMapper
- MediatR (CQRS için)
- JWT Authentication
- Swagger (API test ve dokümantasyon)
- xUnit & Moq (Birim testleri)

---

# Güvenlik Notları

Bu proje örnek bir yapı olmakla birlikte, güvenlik açısından aşağıdaki uygulamalar dikkate alınmalı ve gerektiğinde entegre edilmelidir:

    Rate Limiting: Kullanıcı başına istek sınırı getirerek brute-force ataklarının önüne geçilebilir.

    SQL Injection Koruması: EF Core doğal olarak koruma sağlar, ancak özel sorgular/stored procedure kullanılıyorsa dikkatli olunmalıdır.  (Uygulandı)

    JWT Süre & Yenileme: Token expiration süresi iyi yönetilmeli, gerekiyorsa refresh token sistemi eklenmelidir.  (Uygulandı)

    Şifreleme: Şifreler SHA-256 veya bcrypt gibi yöntemlerle hash'lenmelidir. (Uygulandı)

    Global Exception Handling: API'deki tüm beklenmeyen hatalar kullanıcıya uygun formatta döndürülür.  (Uygulandı)

    Logging & Monitoring: İsteğe bağlı olarak Serilog gibi araçlar kullanılarak uygulama izlenebilir. 

##  Kurulum Talimatları

```bash
https://github.com/GuvanchYazgulyyev/KitapSatisSolution.git
cd KitapSatisAPI
dotnet restore
dotnet run --project KitapSatisAPI


