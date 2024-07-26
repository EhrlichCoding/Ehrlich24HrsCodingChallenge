using CsvHelper;
using sales.core.Entities;
using sales.core.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sales.core.Helpers
{
    public class FileHelper<T> where T:class
    {
        public static IEnumerable<T> ExtractFile(Stream file)
        {
            var reader = new StreamReader(file);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<T>();
            return records;
        }
    }
}
