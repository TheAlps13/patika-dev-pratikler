namespace todo
{
    public struct Messages
    {
        public const string Menu = "Lütfen yapmak istediğiniz işlemi seçiniz :) \n*******************************************\n(1) Board Listelemek\n(2) Board'a Kart Eklemek\n(3) Board'dan Kart Silmek\n(4) Kart Taşımak\n(5) Çıkış";
        public const string Header = "Başlık      :";
        public const string Content = "İçerik      :";
        public const string AppointedPerson = "Atanan Kişi :";
        public const string Size = "Büyüklük    :";
        public const string Line = "Line        :";
        public const string TodoLine = "TODO Line\n************************";
        public const string InProgressLine = "IN PROGRESS Line\n************************";
        public const string DoneLine = "DONE Line\n************************";
        public const string Empty = "~ BOŞ ~\n";
        public const string EnterHeader = "Başlık Giriniz                                  :";
        public const string EnterContent = "İçerik Giriniz                                  :";
        public const string EnterAppointedPers = "Kişi ID Giriniz                                    :";
        public const string EnterSize = "Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  :";
        public const string SelectCardToRmv = "Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.";
        public const string EnterCardHeader = "Lütfen kart başlığını yazınız :";
        public const string CardNotFound = "Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.";
        public const string EndRmv = "* Silmeyi sonlandırmak için : (1)";
        public const string TryAgain = "* Yeniden denemek için : (2)";
        public const string SelectCardToMove = "Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.";
        public const string EndOperation = "* İşlemi sonlandırmak için : (1)";
        public const string FoundCardInf = "Bulunan Kart Bilgileri:\n**************************************";
        public const string SelectTheLineToMove = "Lütfen taşımak istediğiniz Line'ı seçiniz: \n(1) TODO\n(2) IN PROGRESS\n(3) DONE";
        public const string IDNotFound = "\nHatalı giriş yaptınız, belirtilen ID' de bir takım üyesi yok\n";
        public const string SelectionErr = "\nHata ! Girişiniz seçenekler dahilinde bir sayı olmalı.\n";
        public const string CardMoveSuccess = "\nKart başarıyla taşındı.\n";
    }
}