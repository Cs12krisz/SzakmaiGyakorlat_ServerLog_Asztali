





namespace LogManager
{
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

        }

        private static void Feladat6()
        {
            throw new NotImplementedException();
        }

        private static void Feladat5()
        {
            Console.WriteLine("5. Feladat:");
            LogokSzurese(["Szűrt események (ERROR és WARNING):"], [["ERROR", "WARNING"]]);
        }

        public static void LogokSzurese(string[] bejegyzesek, List<List<string>> szuresFelteltelek)
        {
            for (int bejIndex = 0; bejIndex < bejegyzesek.Length; bejIndex++)
            {
                Console.WriteLine($"\t{bejegyzesek[bejIndex]}");
                List<Log> szurtLogok = new List<Log>();
                foreach (var log in logok)
                {
                    int i = 0;
                    while (i < szuresFelteltelek[bejIndex].Count && szuresFelteltelek[bejIndex][i] != log.Szint)
                    {
                        i++;
                    }

                    if (i < szuresFelteltelek[bejIndex].Count)
                    {
                        szurtLogok.Add(log);
                    }
                }

                foreach (var item in szurtLogok)
                {
                    Console.WriteLine($"\t{item.Ido} - {item.Szint} - {item.Uzenet}");
                }
            }

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
