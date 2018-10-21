using System;

namespace Pedal_loopregistratie_Migrations_Startup
{
    // Project for init EF, cause compatibility issues with UWP
    class Program
    {
        // Commands for Package Manager Console

        // Add-Migration Initial -StartupProject Pedal_loopregistratie_Migrations_Startup -Project Pedal_loopregistratie_Model
        // Remove-Migration -StartupProject Pedal_loopregistratie_Migrations_Startup -Project Pedal_loopregistratie_Model
        // Update-Database -StartupProject Pedal_loopregistratie_Migrations_Startup -Project Pedal_loopregistratie_Model
        // Update-Database 0 -StartupProject Pedal_loopregistratie_Migrations_Startup -Project Pedal_loopregistratie_Model
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
