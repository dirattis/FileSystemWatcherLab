using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FileSystemWatchLab
{
    public class FileSystemWatcherExample
    {
        public static void Init()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(@"D:\Desenvolvimento\Lab\TesteWatch");
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Deleted += Watcher_Deleted;
            watcher.Renamed += Watcher_Renamed;
            watcher.Error += Watcher_Error;
            watcher.Filter = "*.csv";
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
            
        }

        private static void Watcher_Error(object sender, ErrorEventArgs e)
        {
            var ex = e.GetException();
            Console.WriteLine($"Ocorreu o seguinte erro: {ex.Message}");
            Console.WriteLine($"StackTrace: { ex.StackTrace}");
            Console.WriteLine(ex.InnerException != null ? $"InnerException: {ex.InnerException.Message}" : string.Empty);
        }

        //É chamado quando um arquivo/pasta é renomeado
        private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"Arquivo renomeado de {e.OldName} para {e.Name}");
        }

        //É chamado quando um arquivo/pasta é deletado
        private static void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Arquivo {e.Name} foi deletado");
        }

        //Chamado quando a pasta ou arquivo é colado no diretório
        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Arquivo {e.Name} foi alterado. ChangeType: {e.ChangeType}");
        }

        //É chamado quando um arquivo/pasta é criado
        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {

            Console.WriteLine($"Arquivo {e.Name} foi criado. Diretório: {e.FullPath}");

            if(Regex.IsMatch(e.FullPath,$@"{DateTime.Now.Year}\\{DateTime.Now.Month.ToString().PadLeft(2,'0')}\\{DateTime.Now.Day.ToString().PadLeft(2, '0')}\\\w+.csv$"))
                Console.WriteLine("Carregar Estoque");
        }
    
    }
}
