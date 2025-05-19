using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class Programa4_arregloAleatorioModel : PageModel
    {
        public List<int> NumerosAleatorios { get; set; } = new List<int>();
        public List<int> NumerosOrdenados { get; set; } = new List<int>();
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Modas { get; set; } = new List<int>();
        public double Mediana { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            // Generar numeros
            Random r = new Random();
            NumerosAleatorios = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                NumerosAleatorios.Add(r.Next(0, 101));
            }

            // Ordenar lista
            NumerosOrdenados = new List<int>(NumerosAleatorios);
            for (int i = 0; i < NumerosOrdenados.Count - 1; i++)
            {
                for (int j = i + 1; j < NumerosOrdenados.Count; j++)
                {
                    if (NumerosOrdenados[i] > NumerosOrdenados[j])
                    {
                        int temp = NumerosOrdenados[i];
                        NumerosOrdenados[i] = NumerosOrdenados[j];
                        NumerosOrdenados[j] = temp;
                    }
                }
            }

            Suma = 0;
            for (int i = 0; i < NumerosAleatorios.Count; i++)
            {
                Suma += NumerosAleatorios[i];
            }

            Promedio = (double)Suma / NumerosAleatorios.Count;

            // Moda
            List<int> modas = new List<int>();
            int maxVeces = 0;

            for (int i = 0; i < NumerosAleatorios.Count; i++)
            {
                int actual = NumerosAleatorios[i];
                int veces = 0;

                for (int j = 0; j < NumerosAleatorios.Count; j++)
                {
                    if (NumerosAleatorios[j] == actual)
                    {
                        veces++;
                    }
                }

                if (veces > maxVeces)
                {
                    modas.Clear();
                    modas.Add(actual);
                    maxVeces = veces;
                }
                else if (veces == maxVeces && !modas.Contains(actual))
                {
                    modas.Add(actual);
                }
            }

            Modas = modas;

            // Mediana
            int medio = NumerosOrdenados.Count / 2;
            if (NumerosOrdenados.Count % 2 == 0)
            {
                Mediana = (NumerosOrdenados[medio - 1] + NumerosOrdenados[medio]) / 2.0;
            }
            else
            {
                Mediana = NumerosOrdenados[medio];
            }

            ModelState.Clear();
        }
    }
}
