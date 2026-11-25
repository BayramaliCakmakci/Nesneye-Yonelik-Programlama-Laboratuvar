
using System;
using System.Collections.Generic;

enum CihazTuru
{
    Lamba = 1,
    Klima = 2,
    GuvenlikSistemi = 3
}

class Cihaz
{
    public int Kimlik { get; }
    public string Ad { get; }
    public CihazTuru Tur { get; }
    public bool AcikMi { get; private set; }

    public Cihaz(int kimlik, string ad, CihazTuru tur)
    {
        Kimlik = kimlik;
        Ad = ad;
        Tur = tur;
        AcikMi = false;
    }

    public void Ac()
    {
        if (AcikMi == true)
        {
            return;
        }
        else
        {
            AcikMi = true;
        }
    }

    public void Kapat()
    {
        if (AcikMi == false)
        {
            return;
        }
        else
        {
            AcikMi = false;
        }
    }

    public void BilgileriGoster()
    {
        Console.WriteLine("Cihaz Kimliği: " + Kimlik);
        Console.WriteLine("Cihaz Adı: " + Ad);
        Console.WriteLine("Cihaz Türü: " + Tur);

        if (AcikMi == false)
        {
            Console.WriteLine("Cihaz Kapalı");
        }
        else
        {
            Console.WriteLine("Cihaz Açık");
        }

        Console.WriteLine("--------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Cihaz> cihazlar = new List<Cihaz>();

        cihazlar.Add(new Cihaz(1, "Salon Lambası", CihazTuru.Lamba));
        cihazlar.Add(new Cihaz(2, "Oda Kliması", CihazTuru.Klima));
        cihazlar.Add(new Cihaz(3, "Ev Güvenliği", CihazTuru.GuvenlikSistemi));

        while (true)
        {
            Console.WriteLine("\n--- Akıllı Ev Sistemi ---");
            Console.WriteLine("1 - Cihazları Listele");
            Console.WriteLine("2 - Yeni Cihaz Ekle");
            Console.WriteLine("3 - Cihaz Aç");
            Console.WriteLine("4 - Cihaz Kapat");
            Console.WriteLine("0 - Çıkış");
            Console.Write("Seçiminiz: ");

            int secim;

            if (!int.TryParse(Console.ReadLine(), out secim))
            {
                Console.WriteLine("Geçersiz seçim!");
                continue;
            }

            switch (secim)
            {
                case 1:
                    foreach (Cihaz cihaz in cihazlar)
                    {
                        cihaz.BilgileriGoster();
                    }
                    break;

                case 2:
                    Console.Write("Cihaz kimliği: ");
                    int kimlik;

                    if (!int.TryParse(Console.ReadLine(), out kimlik))
                    {
                        Console.WriteLine("Geçersiz kimlik!");
                        break;
                    }

                    if (CihazBul(cihazlar, kimlik) != null)
                    {
                        Console.WriteLine("Bu kimliğe sahip cihaz zaten var!");
                        break;
                    }

                    Console.Write("Cihaz adı: ");
                    string ad = Console.ReadLine();

                    Console.WriteLine("1 - Lamba");
                    Console.WriteLine("2 - Klima");
                    Console.WriteLine("3 - Güvenlik Sistemi");
                    Console.Write("Cihaz türü: ");

                    int tur;

                    if (!int.TryParse(Console.ReadLine(), out tur) ||
                        tur < 1 || tur > 3)
                    {
                        Console.WriteLine("Geçersiz cihaz türü!");
                        break;
                    }

                    Cihaz yeniCihaz = new Cihaz(kimlik, ad, (CihazTuru)tur);
                    cihazlar.Add(yeniCihaz);

                    Console.WriteLine("Cihaz başarıyla eklendi.");
                    break;

                case 3:
                    Console.Write("Açılacak cihazın kimliği: ");
                    int acilacakKimlik;

                    if (!int.TryParse(Console.ReadLine(), out acilacakKimlik))
                    {
                        Console.WriteLine("Geçersiz kimlik!");
                        break;
                    }

                    Cihaz acilacakCihaz = CihazBul(cihazlar, acilacakKimlik);

                    if (acilacakCihaz == null)
                    {
                        Console.WriteLine("Cihaz bulunamadı!");
                    }
                    else
                    {
                        acilacakCihaz.Ac();
                        Console.WriteLine("Cihaz açık.");
                    }
                    break;

                case 4:
                    Console.Write("Kapatılacak cihazın kimliği: ");
                    int kapanacakKimlik;

                    if (!int.TryParse(Console.ReadLine(), out kapanacakKimlik))
                    {
                        Console.WriteLine("Geçersiz kimlik!");
                        break;
                    }

                    Cihaz kapanacakCihaz = CihazBul(cihazlar, kapanacakKimlik);

                    if (kapanacakCihaz == null)
                    {
                        Console.WriteLine("Cihaz bulunamadı!");
                    }
                    else
                    {
                        kapanacakCihaz.Kapat();
                        Console.WriteLine("Cihaz kapalı.");
                    }
                    break;

                case 0:
                    Console.WriteLine("Program kapatılıyor.");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }
        }
    }

    static Cihaz CihazBul(List<Cihaz> cihazlar, int kimlik)
    {
        foreach (Cihaz cihaz in cihazlar)
        {
            if (cihaz.Kimlik == kimlik)
            {
                return cihaz;
            }
        }

        return null;
    }
}
