using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SuccessMessages = "Process Success";
        public static string Deleted = "Product Deleted";
        public static string Updated = "Product Updated";
        public static string ProductNameAlreadyExists = " Product Name Already Exists";
        public static string AuthorizationDenied = "Yetkisiz İşlem";
        public static string UserRegistered = "Kullanıcı kaydoldu";
        public static string UserNotFound = "Kullanıcı bulunamadı ";
        public static string PasswordError = "Hatalı Parola";
        public static string SuccessfulLogin = " Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        public static string CarImageAdded = "Resim eklendi";
        public static string CarImageUpdated = "Resim Güncellendi";
        public static string CarImageDeleted = "Resim Silindi";
    }
}
