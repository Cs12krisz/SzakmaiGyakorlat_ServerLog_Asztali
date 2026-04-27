


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
        }

        private static void Feladat4()
        {
            Console.WriteLine("4. feladat: Eseményszintek előfordulása:");
            int InfoDb = logok.Count(l => l.Szint == "INFO");
        }

        private static void Feladat3()
        {
            Console.WriteLine($"3. feladat: Összes bejegyzés: ");
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
