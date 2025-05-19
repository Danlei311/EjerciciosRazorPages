using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class Programa2_CifradoCesarModel : PageModel
    {
        [BindProperty]
        public string MensajeACifrar { get; set; } = "";

        [BindProperty]
        public int ClaveCifrado { get; set; }

        [BindProperty]
        public string MensajeADescifrar { get; set; } = "";

        [BindProperty]
        public int ClaveDescifrado { get; set; }

        public string ResultadoCifrado { get; set; } = "";
        public string ResultadoDescifrado { get; set; } = "";

        private string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVXYZ";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (MensajeACifrar != null && MensajeACifrar != "" && ClaveCifrado > 0)
            {
                ResultadoCifrado = Cifrar(MensajeACifrar.ToUpper(), ClaveCifrado);
            }
            if (MensajeADescifrar != null && MensajeADescifrar != "" && ClaveDescifrado > 0)
            {
                ResultadoDescifrado = Descifrar(MensajeADescifrar.ToUpper(), ClaveDescifrado);
            }
            
        }

        private string Cifrar(string mensaje, int clave)
        {
            string resultado = "";

            for (int i = 0; i < mensaje.Length; i++)
            {
                char letra = mensaje[i];
                if (alfabeto.Contains(letra))
                {
                    int pos = alfabeto.IndexOf(letra);
                    int nuevaPos = (pos + clave) % alfabeto.Length;
                    resultado += alfabeto[nuevaPos];
                }
                else if (letra == ' ')
                {
                    resultado += ' ';
                }
            }

            return resultado;
        }

        private string Descifrar(string mensaje, int clave)
        {
            string resultado = "";

            for (int i = 0; i < mensaje.Length; i++)
            {
                char letra = mensaje[i];
                if (alfabeto.Contains(letra))
                {
                    int pos = alfabeto.IndexOf(letra);
                    int nuevaPos = (pos - clave + alfabeto.Length) % alfabeto.Length;
                    resultado += alfabeto[nuevaPos];
                }
                else if (letra == ' ')
                {
                    resultado += ' ';
                }
            }

            return resultado;
        }
    }
}
