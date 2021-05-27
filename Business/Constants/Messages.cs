using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Başarıyla Eklendi.";
        public static string Deleted = "Başarıyla Silindi.";
        public static string Updated = "Başarıyla Güncellendi.";
        public static string ListAdded = "Listesi Eklendi";
        public static string Empty = "Null";

        public static string UserNotFound = "Kullanıcı Bulunamadı";

        public static string PasswordError = "Şifre Hatalı";

        public static string SuccessfulLogin = "Sisteme Giriş Başarılı";

        public static string UserAlreadyExist = "Kullanıcı zaten mevcut";

        public static string UserRegistered = "Kullanıcı Başarıyla Kaydedildi";

        public static string AccessTokenCreated = "Access Token Başarıyla Oluşturuldu";

        public static string CarImageLimitExceded = "Hata ! Bir aracın 5'den fazla resmi olamaz";
    }
}
