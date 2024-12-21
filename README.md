# Ford_Hackathon_YurtSistemi

# Yurt Otomasyon Sistemi

## Proje Hakkında

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş bir yurt otomasyon sistemidir. Sistem, bir yurt yönetiminde ihtiyaç duyulan öğrenci kaydı, oda yönetimi gibi temel işlevleri dijital ortamda kolayca yönetmeyi amaçlamaktadır.

## Özellikler
- **Öğrenci Yönetimi**: Öğrenci bilgilerini ekleme, düzenleme ve silme.
- **Oda Yönetimi**: Odaların durumlarını takip etme, doluluk oranlarını izleme.
- **Kullanıcı Yetkilendirme**: Yönetici ve personel seviyesinde kullanıcı rolleri.

## Gereksinimler
- **Platform**: .NET 6 veya üzeri
- **Veritabanı**: SQL Server 
- **Geliştirme Ortamı**: Visual Studio 2022

## Kurulum
1. **Proje Deposu**:
   ```bash
   git clone https://github.com/meryemcifci/Ford_Hackathon_YurtSistemi
   cd Ford_Hackathon_YurtSistemi
   ```

2. **Gerekli Bağımlılıkların Yüklenmesi**:
   Projeyi açtıktan sonra, bağımlılıkların otomatik olarak yüklenmesi için aşağıdaki komutu çalıştırabilirsiniz:
   ```bash
   dotnet restore
   ```

3. **Veritabanı Ayarları**:
   - `appsettings.json` dosyasındaki veritabanı bağlantı ayarlarını güncelleyin.
   - SQL Server kullanıyorsanız aşağıdaki örnek formatı kullanabilirsiniz:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Server=localhost;Database=DormSystem;Trusted_Connection=True;"
     }
     ```

4. **Veritabanı Migrasyonları**:
   Veritabanını oluşturmak için aşağıdaki komutları çalıştırın:
   ```bash
   dotnet ef database update
   ```

5. **Uygulamayı Çalıştırma**:
   ```bash
   dotnet run
   ```
   Uygulama, `https://localhost:7001` adresinde çalışacaktır.

## Kullanım
1. Yönetici hesabı ile giriş yaparak öğrencileri ve odaları sisteme ekleyin.
2. Öğrenci kayıt işlemlerini gerçekleştirin.


## Katkıda Bulunma
Projeye katkıda bulunmak için aşağıdaki adımları izleyin:
1. Projeyi forklayın.
2. Değişikliklerinizi yapın ve bir branch oluşturun.
3. Pull request gönderin.


