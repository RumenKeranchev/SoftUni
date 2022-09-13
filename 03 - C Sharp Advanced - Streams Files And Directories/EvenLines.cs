using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace ZipAndExtract
{
    public class ZipAndExtract
    {
        static void Main(string[] args)
        {
        }
    }

    #region 6
    ////06. Zip and Extracts
    //static void Main(string[] args)
    //{
    //    string inputFilePath = @"..\..\..\copyMe.png";
    //    string zipArchiveFilePath = @"..\..\..\archive.zip";
    //    string ouputFilePath = @"..\..\..\";

    //    ZipFileToArchive(inputFilePath, zipArchiveFilePath);
    //    ExtractFileFromArchive(zipArchiveFilePath, "extracted.png", ouputFilePath);
    //}

    //public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
    //{
    //    using (ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Update))
    //    {
    //        archive.CreateEntryFromFile(inputFilePath, Path.GetFileName(inputFilePath));
    //    }
    //}

    //public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
    //{
    //    using (ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Update))
    //    {
    //        archive.Entries.FirstOrDefault().ExtractToFile(Path.Combine(outputFilePath, fileName));
    //    }
    //} 
    #endregion

    #region 5
    //// 05. Copy Directory Contents
    //static void Main(string[] args)
    //{
    //    string inputFolderPath = @"..\..\..\Test";
    //    string ouputFolderPath = @"..\..\..\TestCopy";

    //    CopyAllFiles(inputFolderPath, ouputFolderPath);
    //}

    //public static void CopyAllFiles(string inputPath, string outputPath)
    //{
    //    if (Directory.Exists(outputPath))
    //    {
    //        Directory.Delete(outputPath);
    //    }

    //    Directory.CreateDirectory(outputPath);

    //    var files = Directory.GetFiles(inputPath);

    //    foreach (var file in files)
    //    {
    //        File.Copy(file, Path.Combine(outputPath, Path.GetFileName(file)));
    //    }
    //} 
    #endregion

    #region 4
    ////04. Directory Traversal
    //static void Main(string[] args)
    //{
    //    string inputFolderPath = @"..\..\..\";

    //    var dirs = TraverseDirectory(inputFolderPath);
    //    WriteReportToDesktop(dirs, "reoprt.txt");
    //}
    //public static string TraverseDirectory(string inputFolderPath)
    //{
    //    var sb = new StringBuilder();
    //    var dirInfo = new DirectoryInfo(inputFolderPath);
    //    var files = dirInfo.GetFiles().GroupBy(f => f.Extension).ToList().OrderByDescending(f => f.Count()).ThenBy(f => f.Key);

    //    foreach (var extension in files)
    //    {
    //        sb.AppendLine(extension.Key);

    //        foreach (var file in extension.OrderBy(f => f.Length))
    //        {
    //            sb.AppendLine($"--{file.Name} - {file.Length / 1024f:f2}kb");
    //        }
    //    }

    //    return sb.ToString();
    //}

    //public static void WriteReportToDesktop(string textContent, string reportFileName)
    //{
    //    File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), reportFileName), textContent);
    //} 
    #endregion

    #region 3
    ////03. Copy Binary File
    //static void Main(string[] args)
    //{
    //    string inputFilePath = @"..\..\..\copyMe.png";
    //    string outputFilePath = @"..\..\..\copyMe-copy.png";

    //    CopyFile(inputFilePath, outputFilePath);
    //}

    //public static void CopyFile(string inputFilePath, string outputFilePath)
    //{
    //    using var reader = new FileStream(inputFilePath, FileMode.Open);
    //    using var writer = new FileStream(outputFilePath, FileMode.Create);

    //    var buffer = new byte[1024];

    //    while (true)
    //    {
    //        var bytes = reader.Read(buffer);

    //        if (bytes == 0)
    //        {
    //            break;
    //        }

    //        writer.Write(buffer, 0, bytes);
    //    }
    //} 
    #endregion

    #region 2

    // // 02. Line Numbers
    //static void Main(string[] args)
    //{
    //    string inputFilePath = @"..\..\..\text.txt";
    //    string outputFilePath = @"..\..\..\output.txt";

    //    ProcessLines(inputFilePath, outputFilePath);
    //}

    //public static void ProcessLines(string inputFilePath, string outputFilePath)
    //{
    //    var file = File.ReadAllLines(inputFilePath);
    //    var lineCounter = 1;

    //    foreach (var line in file)
    //    {
    //        var letterCounter = 0;
    //        var puncCounter = 0;
    //        foreach (var chara in line)
    //        {
    //            if (char.IsLetterOrDigit(chara))
    //            {
    //                letterCounter++;
    //            }
    //            else if(!char.IsWhiteSpace(chara))
    //            {
    //                puncCounter++;
    //            }
    //        }

    //        var resLine = $"Line {lineCounter}: {line} ({letterCounter})({puncCounter})\r\n";

    //        File.AppendAllText(outputFilePath, resLine);
    //    }
    //} 
    #endregion

    #region 1
    // // 01 Even lines
    //    static void Main(string[] args)
    //    {
    //        string inputFilePath = @"..\..\..\text.txt";

    //        Console.WriteLine(ProcessLines(inputFilePath));
    //    }

    //    public static string ProcessLines(string inputFilePath)
    //    {
    //        int counter = 0;
    //        var resString = "";
    //        using (var reader = new StreamReader(inputFilePath))
    //        {
    //            var line = reader.ReadLine();

    //            while (line != null)
    //            {
    //                if (counter % 2 == 0)
    //                {
    //                    resString += string.Join(" ", line
    //                        .Replace("-", "@")
    //                        .Replace(",", "@")
    //                        .Replace(".", "@")
    //                        .Replace("!", "@")
    //                        .Replace("?", "@")
    //                        .Split()
    //                        .Reverse());
    //                }
    //                counter++;
    //                line = reader.ReadLine();
    //            }
    //        }

    //        return resString;
    //    }
    //} 
    #endregion
}
