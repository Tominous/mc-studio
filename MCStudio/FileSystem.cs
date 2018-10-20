using System;
using System.Collections.Generic;
using System.IO;

namespace MCStudio
{
    public static class FileSystem
    {

        private static readonly string APP_DATA_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MC Studio");

        private static readonly string RECENTS = Path.Combine(APP_DATA_PATH, "recents.list");
        private static readonly string LOG = Path.Combine(APP_DATA_PATH, "logfile.log");

        private static void Init()
        {
            if (!Directory.Exists(APP_DATA_PATH))
                Directory.CreateDirectory(APP_DATA_PATH);
            if (!File.Exists(RECENTS))
                File.WriteAllText(RECENTS, "");
            if (!File.Exists(LOG))
                File.WriteAllText(LOG, "");
        }

        public static string[] GetRecents()
        {
            Init();
            List<string> rec = new List<string>();
            rec.AddRange(File.ReadAllLines(RECENTS));
            rec.RemoveAll(s => s.Length == 0);
            return rec.ToArray();
        }

        public static void SaveRecent(string path)
        {
            Init();
            File.AppendAllText(RECENTS, "\n" + path);
        }

        public static void WriteLog(string message)
        {
            Init();
            File.AppendAllText(LOG, string.Format("\n{0}: {1}", DateTime.Now.ToString(), message));
        }

        public static void WriteLog(Exception e)
        {
            Init();
            WriteLog(e.Message);
            File.AppendAllText(LOG, string.Format("\n\t{0}", e.StackTrace));
        }

    }
}
