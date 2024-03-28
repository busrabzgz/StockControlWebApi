# Stok Yönetim Sistemi Web API 📦

Bu proje, **ASP.NET Core 8** kullanılarak geliştirilmiş ve **MongoDB** ile stok yönetimi için **CRUD** (Oluştur, Oku, Güncelle, Sil) işlemlerini sağlayan bir Web API'dir.

## 🚀 Başlarken

Bu bölüm, projeyi yerel geliştirme ortamınızda nasıl çalıştıracağınızı ve API'leri nasıl test edeceğinizi açıklar.

### 📋 Gereksinimler

- **.NET 8 SDK**
- **MongoDB Server**
- **Visual Studio** veya **Visual Studio Code**

### 🔧 Projeyi İndirme ve Çalıştırma

1. Bu repository'i GitHub üzerinden `git clone` komutu ile klonlayın veya ZIP olarak indirin ve yerel bilgisayarınıza çıkartın.
    ```
    git clone <repository-url>
    ```
2. MongoDB'yi [MongoDB'nin resmi sitesinden](https://www.mongodb.com/try/download/community) indirip kurun ve servisini başlatın.
3. Visual Studio veya Visual Studio Code kullanarak projeyi açın.
4. `appsettings.json` dosyasında MongoDB yapılandırmanızı güncelleyin.
5. Visual Studio'da, projeyi sağ tıklayıp **"Set as StartUp Project"** seçeneğini belirleyin. Ardından, projeyi **IIS Express** ile çalıştırmak için yeşil oynat butonuna basın.
6. Visual Studio Code kullanıyorsanız, terminali açın ve projenin bulunduğu dizine gidip `dotnet run` komutunu çalıştırın.
    ```
    cd <proje-dizini>
    dotnet run
    ```

### 📝 API'leri Test Etme

Projeyi çalıştırdıktan sonra, Swagger UI otomatik olarak varsayılan web tarayıcınızda açılacaktır. Eğer otomatik olarak açılmazsa, web tarayıcınızda `https://localhost:5001/swagger` adresine giderek API belgelerine ulaşabilirsiniz.

Swagger UI, mevcut tüm API endpoint'lerini ve bu endpoint'lere nasıl istek gönderileceğini gösteren bir arayüz sağlar. Her bir endpoint için;

- **Try it out** butonuna tıklayarak API isteği yapabilir,
- Gerekli parametreleri girerek test isteklerini gönderebilir,
- API'nin dönüş yapısını ve durum kodlarını görebilirsiniz.



