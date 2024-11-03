using System;

// Düğüm sınıfı
public class Dugum
{
    public int Veri; // Düğümdeki veri
    public Dugum Sonraki; // Bir sonraki düğümü tutar

    // Yapıcı metod
    public Dugum(int veri)
    {
        this.Veri = veri;
        this.Sonraki = null;
    }
}

// Dairesel bağlı liste sınıfı
public class DaireselBagliListe
{
    private Dugum Son; // Listenin sonundaki düğümü temsil eder

    // Yapıcı metod
    public DaireselBagliListe()
    {
        Son = null; // Başlangıçta liste boş
    }

    // Listenin başına eleman ekleme
    public void BaşaEkle(int veri)
    {
        Dugum yeniDugum = new Dugum(veri); // Yeni düğüm oluştur

        if (Son == null) // Liste boşsa
        {
            Son = yeniDugum; // Son düğüm yeni düğüm olur
            Son.Sonraki = Son; // Düğüm kendisini işaret eder (daire oluşturur)
        }
        else // Liste boş değilse
        {
            yeniDugum.Sonraki = Son.Sonraki; // Yeni düğüm ilk düğümü işaret eder
            Son.Sonraki = yeniDugum; // Son düğüm yeni düğümü işaret eder
        }
    }

    // Listenin sonuna eleman ekleme
    public void SonaEkle(int veri)
    {
        Dugum yeniDugum = new Dugum(veri); // Yeni düğüm oluştur

        if (Son == null) // Liste boşsa
        {
            Son = yeniDugum; // Son düğüm yeni düğüm olur
            Son.Sonraki = Son; // Düğüm kendisini işaret eder (daire oluşturur)
        }
        else // Liste boş değilse
        {
            yeniDugum.Sonraki = Son.Sonraki; // Yeni düğüm ilk düğümü işaret eder
            Son.Sonraki = yeniDugum; // Son düğüm yeni düğümü işaret eder
            Son = yeniDugum; // Son düğüm güncellenir
        }
    }

    // İstenilen sıraya eleman ekleme
    public void SiraEkle(int veri, int sira)
    {
        Dugum yeniDugum = new Dugum(veri); // Yeni düğüm oluştur

        if (sira == 1) // Sıra 1 ise başa ekle
        {
            BaşaEkle(veri);
            return;
        }

        Dugum temp = Son.Sonraki; // İlk düğümü işaret etmek için temp oluşturuyoruz
        for (int i = 1; i < sira - 1 && temp != Son; i++) // Döngümüz sıraya kadar dönecek
        {
            temp = temp.Sonraki; // Bir sonraki düğüme geç
        }

        yeniDugum.Sonraki = temp.Sonraki; // Yeni düğümünün sonraki düğümünü güncelle
        temp.Sonraki = yeniDugum; // Önceki düğüm yeni düğümü işaret eder

        if (temp == Son) // Eğer eklenen düğüm son düğümse
        {
            Son = yeniDugum; // Son düğümü güncellenir
        }
    }

    // Baştan eleman silme
    public void BaştanSil()
    {
        if (Son == null) // Eğer liste boşsa
        {
            Console.WriteLine("Liste boş.");
            return;
        }

        if (Son.Sonraki == Son) // Eğer yalnızca bir düğüm varsa
        {
            Son = null; // Listeyi null yapıyoruz
        }
        else // Birden fazla düğüm varsa
        {
            Son.Sonraki = Son.Sonraki.Sonraki; // İlk düğümü siliyoruz
        }
    }

    // Sondan eleman silme
    public void SondanSil()
    {
        if (Son == null) // Eğer liste boşsa
        {
            Console.WriteLine("Liste boş.");
            return;
        }

        if (Son.Sonraki == Son) // Eğer yalnızca bir düğüm varsa
        {
            Son = null; // Listeyi null yapıyoruz
            return;
        }

        Dugum temp = Son.Sonraki; // İlk düğümü işaret etmek için temp
        while (temp.Sonraki != Son) // Sondan bir önceki düğüme kadar döngü
        {
            temp = temp.Sonraki; // Sonraki düğüme geç
        }

        temp.Sonraki = Son.Sonraki; // Son düğümü siliyoruz
        Son = temp; // Son düğüm güncelleniyor
    }

    // İstenilen sıradan eleman silme
    public void SiraSil(int sira)
    {
        if (sira == 1) // Sıra 1 ise baştan sil
        {
            BaştanSil();
            return;
        }

        Dugum temp = Son.Sonraki; // İlk düğümü işaret etmek için temp
        for (int i = 1; i < sira - 1 && temp.Sonraki != Son; i++) // Döngü sıraya kadar döner
        {
            temp = temp.Sonraki; // Sonraki düğüme geç
        }

        if (temp.Sonraki == Son) // Eğer silinen düğüm son düğümse
        {
            Son = temp; // Son düğümü güncellenir
        }

        temp.Sonraki = temp.Sonraki.Sonraki; // Düğümü sil
    }

    // Listenin son halini yazdırmak için metot
    public void Yazdir()
    {
        if (Son == null)
        {
            Console.WriteLine("Liste boş.");
            return;
        }

        Dugum temp = Son.Sonraki; // İlk düğümü işaret et
        do // İlk düğüme tekrar gelene kadar döngü
        {
            Console.Write(temp.Veri + " "); // Düğüm verisini yazdır
            temp = temp.Sonraki; // Sonraki düğüme geç
        } while (temp != Son.Sonraki); // İlk düğü geri dönene kadar
        Console.WriteLine(); // Daha düzenli görünmesi için boşluk bırakıyoruz
    }

    // Main metodu
    class Program
    {
        static void Main(string[] args)
        {
            DaireselBagliListe liste = new DaireselBagliListe(); // Yeni dairesel bağlı liste oluştur

            // Örnek eklemeler
            liste.BaşaEkle(10);
            liste.SonaEkle(20);
            liste.SonaEkle(30);
            liste.SiraEkle(15, 2); // Sıra 2'ye ekle

            Console.WriteLine("Liste elemanları:");
            liste.Yazdir(); // Listeyi yazdır

            // Silme örnekleri
            liste.BaştanSil(); // Baştan sil
            Console.WriteLine("Baştaki elemanı sildikten sonra liste:");
            liste.Yazdir(); // Listeyi yazdır

            liste.SondanSil(); // Sondan sil
            Console.WriteLine("Sondan silme sonrası liste:");
            liste.Yazdir(); // Listeyi yazdır

            liste.SiraSil(2); // İkinci sıradan sil
            Console.WriteLine("İkinci sıradan silme sonrası liste:");
            liste.Yazdir(); // Listeyi yazdır
        }
    }
}