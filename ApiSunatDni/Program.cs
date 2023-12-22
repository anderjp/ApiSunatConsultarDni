using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Datos
        string token = "apis-token-1.aTSI1U7KEuT-6bbbCguH-4Y8TI6KS73N";

        // Solicitar al usuario ingresar el DNI
        Console.Write("Ingrese el número de DNI: ");
        string dni = Console.ReadLine();

        // Iniciar HttpClient
        using (HttpClient httpClient = new HttpClient())
        {
            // Configurar la URL y los encabezados
            string apiUrl = "https://api.apis.net.pe/v1/dni?numero=" + dni;
            httpClient.DefaultRequestHeaders.Add("Referer", "https://apis.net.pe/consulta-dni-api");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                // Realizar la llamada GET a la API
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                // Verificar si la solicitud fue exitosa (código de estado 200 OK)
                if (response.IsSuccessStatusCode)
                {
                    // Leer y mostrar la respuesta en formato JSON
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                }
                else
                {
                    // Manejar errores, por ejemplo, mostrar el código de estado
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
