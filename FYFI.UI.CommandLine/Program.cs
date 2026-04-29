using FYFI.Core;
using FYFI.Core.Enums;
using FYFI.Repository.InMemory.Migrations;
using FYFI.Repository.InMemory.Model;
using FYFI.UI.CommandLine.Service;

namespace FyFi.UI.CommandLine
{
    internal class Program
    {
        static FYFICommandLineService _fyfiCommandLineService { get; set; }
        static void Main(string[] args)
        {

            try
            {
                _fyfiCommandLineService.Handle();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }


    }

}
