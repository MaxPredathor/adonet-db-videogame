using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool programRunning = true;
            while (programRunning)
            {
                Console.WriteLine("Selezionare una delle seguenti operazioni: \n1 - Inserire un nuovo videogioco \n2 - Ricercare un videogioco per ID \n3 - Ricercare un videogico per nome \n4 - Cancellare un videogioco \n5 - Chiudere il programma");
                int userInput;
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            Console.WriteLine("Hai scelto di inserire un nuovo videogioco.");
                            Console.WriteLine("-------------------------------------------");
                            bool created = false;
                            while (!created)
                            {
                                Console.WriteLine("Inserisci il nome del videogioco.");
                                string name = "default";
                                string dataRilascio = "default";
                                DateTime data = DateTime.Now;
                                string overview = "default";
                                try
                                {                               
                                name = Console.ReadLine();
                                    if (string.IsNullOrEmpty(name))
                                        throw new Exception("Nome non valido.");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Errore: " + e.Message);
                                }

                                Console.WriteLine("Inserisci la data di rilascio del videogioco (dd/MM/yyyy):");
                                dataRilascio = Console.ReadLine();                               

                                try
                                {
                                    data = DateTime.ParseExact(dataRilascio, "dd/MM/yyyy", null);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato data non valido. Assicurati di inserire la data nel formato corretto (dd/MM/yyyy).");
                                }

                                Console.WriteLine("Inserisci l'overview del videiogioco.");
                                try
                                {
                                    overview = Console.ReadLine();
                                    if (string.IsNullOrEmpty(overview))
                                        throw new Exception("Overview non valida.");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Errore: " + e.Message);
                                }
                                Random rnd = new Random();
                                int numeroCasuale = rnd.Next(1, 8);
                                Videogioco game = new Videogioco(name, data, overview, DateTime.Now, DateTime.Now, numeroCasuale);
                                VideogameManager.InserisciVideogame(game);
                                created = true;
                            }

                            break;
                        case 2:
                            Console.WriteLine("Hai scelto di ricercare un videogioco per ID.");
                            bool searched = false;
                            string input = "default";
                            int id = 0;
                            while (!searched)
                            {
                                Console.WriteLine("Inserisci l'id del videogioco da cercare");
                                input = Console.ReadLine();

                                try
                                {
                                    id = int.Parse(input);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato del numero non valido. Assicurati di inserire un numero intero.");
                                }

                                VideogameManager.CercaVideogiocoPerId(id);
                                searched = true;
                            }
                            break;
                        case 3:
                            Console.WriteLine("Hai scelto di ricercare videogiochi per nome.");
                            bool searched2 = false;
                            string input3 = "default";
                            while (!searched2)
                            {
                                Console.WriteLine("Inserisci il nome del videogioco da cercare");
                                try
                                {
                                    input3 = Console.ReadLine();
                                    if (string.IsNullOrEmpty(input3))
                                        throw new Exception("Nome non valido.");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Errore: " + e.Message);
                                }

                                VideogameManager.CercaVideogiocoPerNome(input3);
                                searched2 = true;
                            }
                            break;
                        case 4:
                            Console.WriteLine("Hai scelto di cancellare un videogioco.");
                            bool deleted = false;
                            string input2 = "default";
                            int id2 = 0;
                            while (!deleted)
                            {
                                Console.WriteLine("Inserisci l'id del videogioco da cancellare");
                                input = Console.ReadLine();

                                try
                                {
                                    id2 = int.Parse(input2);
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato del numero non valido. Assicurati di inserire un numero intero.");
                                }

                                VideogameManager.CancellaVideogioco(id2);
                                deleted = true;
                            }
                                break;
                        case 5:
                            Console.WriteLine("Chiusura del programma...");
                            programRunning = false;
                            break;
                        default:
                            Console.WriteLine("\nNumero non valido. inserire un numero da 1 a 5.\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nInput non valido. Inserire un numero.\n");
                }
            }
        }
    }
}
