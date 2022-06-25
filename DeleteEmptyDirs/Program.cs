class Program
{
    static void Main(string[] args)
    {
        SimpleLogger log = new SimpleLogger();
        processDirectory(@"d:\OneDrive",log);
    }

    private static void processDirectory(string startLocation, SimpleLogger log)
    {
        foreach (var directory in Directory.GetDirectories(startLocation))
        {
            processDirectory(directory,log);
            if (Directory.GetFiles(directory).Length == 0 &&
                Directory.GetDirectories(directory).Length == 0)
            {
                log.Info("Deleting empty dir " + directory);
                Directory.Delete(directory, false);
            }
        }
    }
}