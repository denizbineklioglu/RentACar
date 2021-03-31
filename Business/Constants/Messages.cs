using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Eklendi.";
        public static string CarNameInvalid = "Araba adı geçersiz.";
        public static string Listed = "Listelendi.";
        public static string Deleted = "Silindi.";
        public static string Updated = "Guncellendi.";
        public static string CarInvalid = "Araba şuan başka müşterimizde olduğu için kiralama işlemi gerçekleştirilemedi.";
        public static string CarPicturesLimitExceed="Arabaya 5'ten fazla fotoğraf eklenemez!";
        public static string AccessHasBeen="Erişim sağlandı";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string PasswordError="Parola hatası";
        public static string SuccessfulLogin="Başarılı giriş";
        public static string Registered="Kayıt olundu";
        public static string UserEntered="Kullanıcı girildi.";
        public static string AuthorizationDenied="Yetkiniz yok.";
        public static string PasswordChanged = "Şifre başarıyla değiştirildi";
        public static string ProfileUpdate = "Profil Guncellendi";
    }
}
