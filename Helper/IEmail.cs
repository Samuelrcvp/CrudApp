using System.Globalization;

namespace CrudApp.Helper
{
    public interface IEmail
    {
        bool Enviar(string email, string assunto, string mensagem);
    }
}
