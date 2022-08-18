Amiral Battı Oyunu

Amaç: Tcp/ip protokolü kullanılarak kurallara uygun bir oyun tasarımı 
yapmak.

Teknoloji:C# dili ve Visual Studio Windows Form Uygulaması.

Oyun Kuralları:
-2 kişiyle oynanır.
-Oyuncular birbirlerinin gemilerini görmemelidirler.
-Gemiler oyun alanında istenilen yere yerleştirebilir.
-Gemiler sadece dikey ya da yatay pozisyonda yerleştirilebilir.
-Gemiler aynı kare içinde bulunamazlar veya çakışma yaşanamaz.
-Eğer bir oyuncu atış yaptığında bir gemiyi vurursa tekrar atış yapma hakkı kazanır.
-Bir geminin batması için o geminin tüm karelerini vurmak zorundayız.
-Rakibinin tüm gemilerini batıran ilk oyuncu oyunu kazanır.

Classlar:
-Server Bağlan-->Ip adresi ve kullanıcı adı ile server'a bağlanıyoruz.
-Enemy Select-->Burada server'a bağlı kullanıcılar listeleniyor ve istenilen kullanıcı seçiliip oyuna davet isteği gönderiliyor.
-Offering Game-->İstek kullanıcı da beliriyor ve isteğe göre kabul edip oyun başlıyor ya da reddediyor.
-Form1(Oyun Sayfası)-->Burada oyun alanı açılıyor ve bilgilere göre gemiler yerleşiyor.Play butonu ile diğer oyuncu da hazır ise oyun başlıyor.
-Program(Main Sayfası)-->Burada ise serverdan alınan verilere göre oyunun temel akışı şekilleniyor.
-SynchronousSocketClient->Client ile server'a bilgi aktarımı.
-Server Project
--AsynchronousSocketListener->Server için gerekli methodlar tanımlandı.

Oyun Tasarımı:
-![a](https://user-images.githubusercontent.com/60553003/185487762-06a3abcb-3d3c-4f0c-8f36-7c69f728a00d.png)
![b](https://user-images.githubusercontent.com/60553003/185487775-72733af5-e2aa-4e71-930f-f29e5b0931fb.png)



Tasarlanan oyun bizim uygulamamızda nasıl çalışıyor olacak?
-İlk olarak giriş sayfaasında kullanıcı bir nickname ve serverdaki ip ile oyuna giriş yapacak ve lobby' e yönlenecek ardından online olan diğer oyuncularaoyun isteği yollayıp kabul aldığında oyun başlayacak.
-Oyun kuralları gereğince oyuncu gemileri ekrandaki bilgilere göre  map'e yerleştirerek hazır olduğunda PLAY butonuna basacak.
-Play butonuna basıldığında ekran güncellenecek ve atış yapabileceği EnemyMap ve ona karşı yapılan atışlar için kendi Map'i görünecek.
-Oyun kurallara göre oynanacak ve tüm gemileri vuran kazanacak.
-İyi ounlar..


