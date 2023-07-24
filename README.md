
**Proje Adı: Kitap Kütüphanesi**  
**Açıklama**:  
Bir kitap kütüphanesi yönetim sistemi geliştirmek istiyorsunuz. Bu projede, kitapları ekleyebilecek, düzenleyebilecek, silebilecek ve arama yapabileceksiniz. Ayrıca, kullanıcılar kitapları ödünç alabilecek ve iade edebileceklerdir.  

**Teknik Gereksinimler:**  
 -   Proje C# / .NET Core 5 veya üzeri kullanılarak geliştirilecektir.
   -   Veritabanı olarak PostgreSQL gibi bir ilişkisel veritabanı kullanılacaktır.
   -   API,  [ASP.NET](http://asp.net/)  Core ile geliştirilmelidir.
   -   Kitap ödünç alma ve iade işlemleri için JWT tabanlı bir kimlik doğrulama mekanizması kullanılmalıdır.
   -   SpecFlow kullanarak senaryo bazlı testler yazılmalıdır.

**Beklenen Çalışmalar:**  
Adayın bu projeyi geliştirmek için aşağıdaki adımları takip etmesi beklenir:  

**1.  Veritabanı Tasarımı:**
-   Entity Framework Core'u kullanarak kitaplar için bir veritabanı modeli oluşturun.
-   Code First yaklaşımıyla veritabanını entitylerden oluşturun.

**2.  API Rotaları ve Controller'lar:**
-   Kitapları getirmek, yeni kitap eklemek, kitap güncellemek ve silmek gibi API rotalarını tanımlayın.
-   Ödünç alma ve iade işlemleri için ilgili rotaları oluşturun.
-   API rotaları için JWT tabanlı kimlik doğrulama ve yetkilendirme mekanizmasını entegre edin.

**3.  Kimlik Doğrulama ve Yetkilendirme:**

-   Kitap ödünç alma ve iade işlemlerini korumak için JWT (JSON Web Token) tabanlı kimlik doğrulama mekanizması ekleyin.
-   Kullanıcıların kaydolmasını, giriş yapmasını ve yetkilendirilmesini sağlayın.

**4.  SpecFlow Senaryoları ve Testler:**

-   SpecFlow ile senaryo bazlı testler yazın.
-   Senaryoları API rotalarını ve işlevselliği test edecek şekilde oluşturun.
-   Testlerin geçmesi veya hata durumlarının doğru şekilde raporlanması beklenir.

**5.  Clean Code ve Düzenleme:**

-   Kodun okunabilirliğini ve sürdürülebilirliğini artırmak için clean code prensiplerine dikkat edin.
-   İyi isimlendirme, kod tekrarının önlenmesi gibi kuralları uygulayın.

**6.  Docker Entegrasyonu:**

-   Projenin Docker konteynerine taşınabilmesi için Dockerfile oluşturun.
-   Gerekli adımları içeren Dockerfile ile proje çalıştırılabilir bir konteyner oluşturun.
-   Projeyi Docker kullanarak yerel bir konteynerde çalıştırın ve test edin.
