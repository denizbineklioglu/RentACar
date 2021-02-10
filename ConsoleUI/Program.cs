using Business.Concrete;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (1 > 0)
            {
                Console.WriteLine("-------Araba kiralama sistemimize hoşgeldiniz-------- \n" +
                    "1) Öge ekle \n 2) Öge sil \n 3) Öge güncelle \n 4) Öge listele");
                int secilen = Convert.ToInt32(Console.ReadLine());
                switch (secilen)
                {
                    case 1:
                        try
                        {
                            Ekle();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Bir hata olustu!");
                        }
                        break;
                    case 2:
                        try
                        {
                            Sil();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Bir hata olustu!");

                        }
                        break;
                    case 3:
                        try
                        {
                            Guncelle();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Bir hata olustu!");

                        }
                        break;
                    case 4:
                        try
                        {
                            Listele();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Bir hata olustu!");
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Cikis yapmak icin q'ya basiniz");
                string cikis = Console.ReadLine();
                if (cikis == "q" || cikis == "Q")
                {
                    break;
                }
                Console.Clear();
            }
        }
        private static void Ekle()
        {
            Console.WriteLine("Eklenecek ögeyi seciniz: " +
                            "1)Araba \n 2)Marka \n 3) Renk");
            int secilen = Convert.ToInt32(Console.ReadLine());
            switch (secilen)
            {
                case 1:
                    Console.WriteLine("Marka Id'si:");
                    int markaId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Renk Id'si: ");
                    int renkId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Araba adı:");
                    string arabaAdi = Console.ReadLine();
                    Console.WriteLine("Arabanın model yılı: ");
                    int modelYili = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Günlük kiralama bedeli:");
                    int kiralamaBedeli = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Açıklama (istege bagli):");
                    string aciklama = Console.ReadLine();
                    Car car = new Car
                    {
                        BrandId = markaId,
                        ColorId = renkId,
                        CarName = arabaAdi,
                        DailyPrice = kiralamaBedeli,
                        Description = aciklama,
                        ModelYear = modelYili
                    };
                    CarManager carManager = new CarManager(new EfCarDal());
                    carManager.Add(car);
                    break;
                case 2:
                    Console.WriteLine("Marka'nin adi:");
                    string markaAdi = Console.ReadLine();
                    Brand brand = new Brand
                    {
                        BrandName = markaAdi
                    };
                    BrandManager brandManager = new BrandManager(new EfBrandDal());
                    brandManager.Add(brand);
                    break;
                case 3:
                    Console.WriteLine("Renk adi giriniz: ");
                    string renkAdi = Console.ReadLine();
                    Color color = new Color
                    {
                        ColorName = renkAdi
                    };
                    ColorManager colorManager = new ColorManager(new EfColorDal());
                    colorManager.Add(color);
                    break;
                default:
                    Console.WriteLine("Yanlis tusa bastiniz!");
                    break;                   
            }         
        }
        private static void Guncelle()
        {
            Console.WriteLine("Guncellenecek ögeyi seciniz: " +
                            "1) Araba \n 2) Marka \n 3)Renk ");
            int secilen = Convert.ToInt32(Console.ReadLine());
            switch (secilen)
            {
                case 1:
                    Console.WriteLine("Guncellenecek arabanin Id'si: ");
                    int arabaId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Marka Id'si:");
                    int markaId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Renk Id'si: ");
                    int renkId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Araba adı:");
                    string arabaAdi = Console.ReadLine();
                    Console.WriteLine("Arabanın model yılı: ");
                    int modelYili = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Günlük kiralama bedeli:");
                    int kiralamaBedeli = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Açıklama (istege bagli):");
                    string aciklama = Console.ReadLine();
                    Car car = new Car
                    {
                        Id = arabaId,
                        BrandId = markaId,
                        ColorId = renkId,
                        CarName = arabaAdi,
                        DailyPrice = kiralamaBedeli,
                        Description = aciklama,
                        ModelYear = modelYili
                    };
                    CarManager carManager = new CarManager(new EfCarDal());
                    carManager.Update(car);
                    break;
                case 2:
                    Console.WriteLine("Marka Id'si: ");
                    int mrkaId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Marka'nin adi:");
                    string markaAdi = Console.ReadLine();
                    Brand brand = new Brand
                    {
                        Id = mrkaId,
                        BrandName = markaAdi
                    };
                    BrandManager brandManager = new BrandManager(new EfBrandDal());
                    brandManager.Update(brand);
                    break;
                case 3:
                    Console.WriteLine("Renk Id'si giriniz: ");
                    int colorId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Renk adi giriniz: ");
                    string renkAdi = Console.ReadLine();
                    Color color = new Color
                    {
                        Id = colorId,
                        ColorName = renkAdi
                    };
                    ColorManager colorManager = new ColorManager(new EfColorDal());
                    colorManager.Update(color);
                    break;
                default:
                    Console.WriteLine("Yanlis bir tusa bastiniz!");
                    break;
            }
        }
        private static void Sil()
        {
            Console.WriteLine("Silinecek öğgeyi seciniz: " +
                "1) Araba \n 2) Marka \n 3) Renk");
            int secilen = Convert.ToInt32(Console.ReadLine());
            switch (secilen)
            {
                case 1:
                    Console.WriteLine("Silinecek arabanın Id'sini giriniz:");
                    int arabaId = Convert.ToInt32(Console.ReadLine());
                    Car car = new Car
                    {
                        Id = arabaId
                    };
                    CarManager carManager = new CarManager(new EfCarDal());
                    carManager.Delete(car);
                    break;
                case 2:
                    Console.WriteLine("Silinecek markanın Id'sini giriniz: ");
                    int markaId = Convert.ToInt32(Console.ReadLine());
                    BrandManager brandManager = new BrandManager(new EfBrandDal());
                    Brand brand = new Brand
                    {
                        Id = markaId
                    };
                    brandManager.Delete(brand);
                    break;
                case 3:
                    Console.WriteLine("Silinecek rengin Id'sini giriniz: ");
                    int renkId = Convert.ToInt32(Console.ReadLine());
                    Color color = new Color
                    {
                        Id = renkId
                    };
                    ColorManager colorManager = new ColorManager(new EfColorDal());
                    colorManager.Delete(color);
                    break;
                default:
                    break;
            }
        }
        private static void Listele()
        {
                Console.WriteLine("Listelenecek ögeyi seçiniz: " +
                    "1) Araba \n 2)Marka \n 3) Renk");
                int secilen = Convert.ToInt32(Console.ReadLine());
                switch (secilen)
                {
                    case 1:
                        CarManager carManager = new CarManager(new EfCarDal());
                        foreach (var car in carManager.GetCarDetailDtos())
                        {
                            Console.WriteLine("Araba adı: {0} \n Marka adı: {1} \n Rengi: {2} \n Günlük bedeli: {3} \n"
                                , car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
                        }
                        break;
                    case 2:
                        BrandManager brandManager = new BrandManager(new EfBrandDal());
                        foreach (var brand in brandManager.GetAll())
                        {
                            Console.WriteLine(brand.BrandName);
                        }
                        break;
                    case 3:
                        ColorManager colorManager = new ColorManager(new EfColorDal());
                        foreach (var color in colorManager.GetAll())
                        {
                            Console.WriteLine(color.ColorName);
                        }
                        break;
                    default:
                        Console.WriteLine("Yanlış bir tuşa bastınız!");
                        break;
                } 
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Mercedes" });
            brandManager.Delete(new Brand { Id = 6 });
            brandManager.Update(new Brand { Id = 6, BrandName = "Rolls Royce" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Purple" });
            colorManager.Delete(new Color { Id = 6 });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 1,
                CarName = "HONDA",
                ColorId = 1,
                DailyPrice = 40000,
                Description = "Honda",
                ModelYear = 2000
            });
            carManager.Delete(new Car
            {
                Id=14
            });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }
            carManager.GetById(14);

            foreach (var car in carManager.GetCarDetailDtos())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName);
            }
        }
    }
}
