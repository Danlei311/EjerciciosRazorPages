using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class Programa1_IMCModel : PageModel
    {
        [BindProperty]
        public string Peso { get; set; } = "";
        [BindProperty]
        public string Altura { get; set; } = "";
        public double IMC { get; set; } = 0;
        public void OnGet()
        {
        }
        public void OnPost() 
        {
            double pesoTotal = Convert.ToDouble(Peso);
            double alturaTotal = Convert.ToDouble(Altura);
            IMC = pesoTotal / (alturaTotal * alturaTotal);
            ModelState.Clear();
        }
    }
}
