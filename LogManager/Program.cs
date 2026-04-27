






namespace LogManager
{

    public class Szurve
    {
        public string Bejegyzes { get; set; }
        public List<Log> SzurtLista { get; set; }
    }

    public class Program
    {
        public static List<Log> logok = new List<Log>();
        static void Main(string[] args)
        {
            Beolvas();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            Feladat7();

        }

        private static void Feladat7()
        {
            Console.Write("7. Feladat: ");
            string fajlnev = "errors.txt";
            var ErrorEsemenyek = logok.Where(l => l.Szint == "ERROR");
            StreamWriter streamWriter = new StreamWriter(fajlnev);
            foreach (var item in ErrorEsemenyek)
            {
                streamWriter.WriteLine($"{item.Ido} - {item.Szint} - {item.Uzenet}");
            }
            streamWriter.Close();
            Console.Write($"ERROR események mentve: {fajlnev}");

        }

        private static void Feladat6()
        {
            Console.WriteLine("6. Feladat:Legutóbbi ERROR előtti utolsó SUCCESS:");
            var legutobbiErrorIndex = logok.IndexOf(logok.LastOrDefault(l => l.Szint == "ERROR"));
            if (legutobbiErrorIndex != -1)
            {
                int i = legutobbiErrorIndex;
                while (i > -1 && logok[i].Szint != "SUCCESS")
                {
                    i--;
                }

                if (i > -1)
                {
                    Console.WriteLine($"\t{logok[i].Ido} - {logok[i].Szint} - {logok[i].Uzenet}");
                }
                else
                {
                    Console.WriteLine("\tnincs");
                }
            }
            else
            {
                Console.WriteLine("\tnincs");
            }
        }

        private static void Feladat5()
        {
            Console.WriteLine("5. Feladat:");
            var leszurtLogok = LogokSzurese(logok, ["ERROR", "WARNING"]);
            Console.WriteLine($"\tSzűrt események (ERROR és WARNING):");
            foreach (var log in leszurtLogok)
            {
               Console.WriteLine($"\t{log.Ido} - {log.Szint} - {log.Uzenet}");
            }
            
        }

        public static List<Log> LogokSzurese(List<Log> bejegyzesek, List<string> szuresFelteltelek)
        {
           List<Log> szurtLista = new List<Log>();
           foreach (var log in bejegyzesek)
           {
                int i = 0;
                while (i < szuresFelteltelek.Count && szuresFelteltelek[i] != log.Szint)
                {
                     i++;
                }

                if (i < szuresFelteltelek.Count)
                {
                     szurtLista.Add(log);
                }
           }   
            return szurtLista;

        }

        private static void Feladat4()
        {
            Console.WriteLine("4. Feladat: Eseményszintek előfordulása:");
            var kulonbozoEsemenyek = logok.GroupBy(
                    l => l.Szint,
                    l => l,
                    (szint, log) => new
                    {
                        Szint = szint,
                        Db = log.Count(),
                    }
                );
            foreach (var item in kulonbozoEsemenyek)
            {
                Console.WriteLine($"\t{item.Szint} : {item.Db}");
            }
        }

        private static void Feladat3()
        {
            Console.WriteLine($"3. Feladat: Összes bejegyzés: ");
            foreach (var log in logok)
            {
                Console.WriteLine($"\t{log.Ido:yyyy-MM-dd HH:mm:ss} - {log.Szint} - {log.Uzenet}");
            }
            Console.WriteLine($"\tEsemények száma: {logok.Count}");
        }

        public static void Beolvas()
        {
            StreamReader streamReader = new StreamReader("server.log");
            while (!streamReader.EndOfStream)
            {
                logok.Add(new Log(streamReader.ReadLine()));
            }
            streamReader.Close();
        }
    }
}
