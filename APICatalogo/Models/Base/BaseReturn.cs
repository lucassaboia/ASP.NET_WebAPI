namespace APICatalogo.Models.Base
{
    public class BaseReturn<T>
    {
        public bool Sucesso { get; set; }
        public string? Mensagem { get; set; }
        public T? Dados { get; set; }

        public static BaseReturn<T> Ok(T dados) => new() { Sucesso = true, Dados = dados };
        public static BaseReturn<T> Falha(string mensagem) => new() { Sucesso = false, Mensagem = mensagem };
    }

}
