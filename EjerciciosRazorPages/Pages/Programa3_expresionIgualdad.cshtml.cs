using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class Programa3_expresionIgualdadModel : PageModel
    {
        [BindProperty]
        public double A { get; set; }
        [BindProperty]
        public double B { get; set; }
        [BindProperty]
        public double X { get; set; }
        [BindProperty]
        public double Y { get; set; }
        [BindProperty]
        public int N { get; set; }

        public string Resultado { get; set; } = "";

        public string ResultadoDirecto { get; set; } = "";
        public List<string> Pasos { get; set; } = new List<string>();
        public void OnGet()
        {
        }
        public void OnPost()
        {
            double resultadoFinal = 0;

            // Primera parte
            double resultadoDirecto = Math.Pow(A * X + B * Y, N);
            ResultadoDirecto = resultadoDirecto.ToString();

            // Segunda parte
            for (int k = 0; k <= N; k++)
            {
                long coeficiente = ObtenerCoeficiente(N, k);
                double terminoA = Math.Pow(A * X, N - k);
                double terminoB = Math.Pow(B * Y, k);
                double termino = coeficiente * terminoA * terminoB;

                resultadoFinal += termino;

                string paso = $"K = {k}: C({N},{k}) * (a·x)^{N - k} * (b·y)^{k} = {coeficiente} * {terminoA} * {terminoB} = {termino}";
                Pasos.Add(paso);
            }

            Resultado = resultadoFinal.ToString();
        }


        private long ObtenerCoeficiente(int n, int k)
        {
            long res = 1;
            for (int i = 1; i <= k; i++)
            {
                res = res * (n - i + 1) / i;
            }
            return res;
        }
    }
}
