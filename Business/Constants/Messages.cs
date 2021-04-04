using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string MessageAdded = "Ekleme işlemi gerçekleştirildi.";
        public static string MessageDeleted = "Silme işlemi gerçekleştirildi.";
        public static string MessageUpdated = "Güncelleme işlemi gerçekleşleştirildi.";
        public static string DailyPriceInvalid = "Araç günlük fiyat 0 TL'den büyük olmalı";  
        public static string BrandNameInvalid = "Yetersiz karakter!";
        public static string MessageError = "Hatalı işlem. Lütfen tekrar deneyiniz!";

    }
}
