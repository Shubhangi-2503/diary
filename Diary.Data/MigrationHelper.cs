using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Data
{
    internal class MigrationHelper
    {
        public static void ApplySqlScripts(MigrationBuilder migrationBuilder)
        {
            // 1.Path of the folder containing your SQL scripts (relative to the project directory)
            var scriptsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SqlScripts");

            if (Directory.Exists(scriptsPath))
            {
                // 2. Get all the SQL files in that folder
                var files = Directory.GetFiles(scriptsPath, "*.sql");

                foreach (var file in files)
                {
                    // 3. Read and execute each file
                    var sql = File.ReadAllText(file);
                    migrationBuilder.Sql(sql);
                }
            }
        }
    }
}
