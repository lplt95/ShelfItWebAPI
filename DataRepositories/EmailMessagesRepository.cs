using System;
using System.Collections.Generic;
using System.Linq;
using DataTransfer;
using System.Threading.Tasks;

namespace DataRepositories
{
    public class EmailMessagesRepository
    {
        public static EmailMessagesDto register = new EmailMessagesDto()
        {
            subject = "Rejestracja w aplikacji ShelfIt",
            body = "Witaj, <br><br>Wygląda na to, że zarejestrowałeś nowe konto w aplikacji ShelfIt. <br>Kliknij w link poniżej, aby potwierdzić swoją rejestrację<br><br>" +
                "<<<link>>> <br><br>Jeśli nie Ty rejestrowałeś swoje konto, zignoruj poniższą wiadomość. <br>Link aktywacyjny wygaśnie w ciągu 48 godzin od wygenerowania niniejszej wiadomości" +
                "<br><br>Pozdrawiamy, <br>Zespół ShelfIt. <br><br>Niniejsza wiadomość została wygenerowana automatycznie. Nie odpowiadaj na nią. Skrzynka nie jest monitorowana.",
            phrasesToChange = new List<string>() { "<<<link>>>" }
        };
        public static EmailMessagesDto changePass = new EmailMessagesDto()
        {
            subject = "Zmiana hasła w aplikacji ShelfIt",
            body = "Czy hasło zostało zmienione przez Ciebie?<br><br>Zauważyliśmy, że niedawno zmieniono hasło do Twojego konta ShelfIt. Jeśli to nie Ty, natychmiast kliknij w ten <<<link>>>.Jeśli to Ty zignoruj ten e - mail. ",
            phrasesToChange = new List<string>() { "<<<link>>>" }
        };
    }
}
