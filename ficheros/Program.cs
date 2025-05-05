using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/*
crear diccionario
hacer split
añadir al diccionario
*/
internal class Program
{

    public static void RellenarDiccionario(Dictionary<string, string> miDiccionario)
    {
        string palabra = "";
        string definicion = "";
        
        //miDiccionario = new Dictionary<string, string>();

        
            Console.WriteLine("Dime la palabra que quieres añadir: ");
            palabra = Console.ReadLine() ?? "0";

            Console.WriteLine("Ahora dime su significado");
            definicion = Console.ReadLine() ?? "0";

            miDiccionario.Add(palabra, definicion);        
        
        /*
        
        Console.WriteLine("Este es el contenido de tu diccionario");

        foreach (var item in miDiccionario)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }  
        */     
    
    }

    public static void RellenarFichero(string ruta, Dictionary<string, string> miDiccionario)
    {

        using StreamWriter fichero = new (ruta, true);
        {
            foreach (var registro in miDiccionario)
            {
                fichero.WriteLine($"{registro.Key}: {registro.Value}");  
            }
            //writer.WriteLine($"{miDiccionario.Keys}: {miDiccionario.Values}"); con esto obtenia el tipo de objeto no su contenido. Tengo que recorrer su contenido y así obtenerlo.
        }
          
    }


    public static void LeerFichero(string ruta)
    {
        using StreamReader sr = new StreamReader(ruta);

        while(!sr.EndOfStream)
        {
            string contenido = sr.ReadLine() ?? "0"; // leemos lo que hay dentro de sr.
            string[] clave = contenido.Split(":"); // tener en cuenta que al ser un array accedemos a posiciones

            string palabra = clave[0];
            string descripcion = clave[1];
            Console.WriteLine("Esto es la palabra: " + palabra);

            Console.WriteLine("Esto es la descripcion: " + descripcion);
            
            //Console.WriteLine(sr.ReadLine()); por si no creo la variable contenido puedo nombrarla directamente en en el console.
        }

        sr.Close();

    }
    private static void Main(string[] args)
    {
        string respuesta = "";
        string ruta = @"Texto.txt";
        int contador = 1;
        Dictionary<string, string> miDiccionario = new Dictionary<string, string>();
        
        do
        {
            Console.WriteLine("¿Quieres añadir alguna palabra al diccionario?");
            respuesta = Console.ReadLine() ?? "0";
            if(respuesta == "si")
            {
                RellenarDiccionario(miDiccionario);
                
            }
            contador ++;
        } while (respuesta == "si" && contador < 20);
        
        RellenarFichero(ruta, miDiccionario);
        LeerFichero(ruta);
        
        /*

        string ruta = @"C:\Users\alumno\Desktop\Texto.txt";
        //string ruta = @"Texto.txt";

        //FileStream fichero = new FileStream(ruta, FileMode.Open, FileAccess.Read);
        //using FileStream fichero = new FileStream(ruta, FileMode.Open, FileAccess.Read);
        using StreamReader sr = new StreamReader(ruta);

        */
       // LeerFichero(ruta);

    }
}
