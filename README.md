# LibraryApplication

Bu proje, bir kütüphanede bulunan kitapların takibi ve ödünç verilmesini sağlayan bir ASP.NET Core uygulamasıdır. PostgreSQL veritabanı kullanılmaktadır.

## Kurulum

1. Projeyi bilgisayarınıza klonlayın:

    ```bash
    git clone https://github.com/goktugbaris/LibraryApplication.git
    cd kutuphane-uygulamasi
    ```

2. PostgreSQL veritabanını yükleyin ve bağlantı ayarlarını `appsettings.json` dosyasında güncelleyin.
3. Projeyi Visual Studio veya başka bir IDE ile açın.

4. Uygulamayı başlatın.

    > Not: Projeyi çalıştırmadan önce, `dotnet ef database update` komutunu kullanarak veritabanını oluşturun.

Uygulama şimdi http://localhost:7205 adresinde çalışmaktadır.

## Kullanım

1. Tarayıcınızdan [http://localhost:7205](http://localhost:7205) adresine gidin.

2. Ana ekran, kütüphanede bulunan kitapları alfabetik sırayla listeler. Her kitap, adı, yazarı, resmi ve durumuyla birlikte görüntülenir.

3. Kitap ödünç verilmek istendiğinde, "ödünç ver" düğmesine basılarak kitap adı ve ödünç alanın ismi girilir. Geri getirme tarihi sorulur ve kaydedilir.

4. Yeni kitap eklemek için ana ekran üzerinde bulunan "Kitap Ekle" linkine tıklayarak yeni bir kitap ekleyebilirsiniz.

## Hata Kontrolleri

Uygulama ön yüzde gerekli hata kontrollerini yapmaktadır. Örneğin, kitap ödünç verilirken boş alan bırakılamaz veya yanlış bir tarih formatı girilemez.

## Veri Tabanı ve Güvenlik

Projede kullanıcı girişi veya kimlik doğrulama bulunmamaktadır. Bu sadece basit bir örnek uygulamadır. Gerçek bir uygulamada güvenlik önlemleri eklenmelidir.

## Exception Handling ve Logging

Her türlü exception yakalanmakta ve loglanmaktadır.
