using Newtonsoft.Json;
using SPPF_API.Models.COTIOT;

namespace SPPF_API.Helper
{

    public class RecordHelper<T> where T : class
    {
        public void WriteRecordsToFile(string path, string line, T record)
        {
            //string line = GetLine(record);
            string docPath = Path.Combine(@"C:\project\data\", path, DateTime.Now.ToString("yyyyMMdd"), line);
            string json = JsonConvert.SerializeObject(record);

            // Create directory if it doesn't exist
            if (!Directory.Exists(docPath))
            {
                Directory.CreateDirectory(docPath);
            }

            // Write JSON data to file
            string filePath = Path.Combine(docPath, $"{path}_{line}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt");
            using (StreamWriter outputFile = new StreamWriter(filePath, true))
            {
                outputFile.WriteLine(json);
            }
        }

        public void WriteRecordsToFile(string path, string line,List<T> records)
        {
            if (records.Count == 0)
            {
                return;
            }

            //string line =GetLine(records[0]);
            string docPath = Path.Combine(@"C:\project\data\", path, DateTime.Now.ToString("yyyyMMdd"), line);

            if (!Directory.Exists(docPath))
            {
                Directory.CreateDirectory(docPath);
            }

            string json = JsonConvert.SerializeObject(records);

            string filePath = Path.Combine(docPath, $"{path}_{line}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt");

            using (StreamWriter outputFile = new StreamWriter(filePath, true))
            {
                outputFile.WriteLine(json);
            }
        }

        private string GetLine(T record)
        {
            // Implement logic to extract line property from record
            // For example:
             //return ((FatekRecord)record).Line;
            return null;
        }
    }
    /*   public class RecordHelper
       {
          public RecordHelper()
           {

           }
           public void WriteFatekRecordToFile(string path,FatekRecord fatekRecord)
           {
               //@"C:\project\data\fatek"
               string line = fatekRecord.Line;
               string docPath = Path.Combine(@"C:\project\data\"+path, DateTime.Now.ToString("yyyyMMdd"), line);
               string json = JsonConvert.SerializeObject(fatekRecord);

               // Create directory if it doesn't exist
               if (!Directory.Exists(docPath))
               {
                   Directory.CreateDirectory(docPath);
               }

               // Write JSON data to file
               string filePath = Path.Combine(docPath, $"{path}_{line}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt");
               using (StreamWriter outputFile = new StreamWriter(filePath, true))
               {
                   outputFile.WriteLine(json);
               }
           }
           public void WriteFatekRecordToFile(string path, List<FatekRecord> fatekRecords)
           {
               string line = fatekRecords[0].Line;
               string docPath = @$"C:\project\data\{path}\{DateTime.Now.ToString("yyyyMMdd")}\{line}\";

               if (!Directory.Exists(docPath))
               {
                   Directory.CreateDirectory(docPath);
               }

               string json = JsonConvert.SerializeObject(fatekRecords);

               string filePath = Path.Combine(docPath, $"{path}_{line}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.txt");

               using (StreamWriter outputFile = new StreamWriter(filePath, true))
               {
                   outputFile.WriteLine(json);
               }
           }
       }*/
}
