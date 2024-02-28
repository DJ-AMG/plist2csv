
using System;
using System.IO;

using playlist2csv;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.Error.WriteLine("Usage: plist2csv <input plist file> <output csv file> [optional]");
            return;
        }

        string input_plist_file = args[0];

        FileInfo input_fileInfo = new FileInfo(input_plist_file);
        if (!input_fileInfo.Exists)
        {
            Console.Error.WriteLine("Input file \"" + input_plist_file + "\" does not exist");
            return;
        }

        string output_csv_file;

        if (args.Length > 1) 
        {
            output_csv_file = args[1];
        }
        else
        {
            output_csv_file = input_fileInfo + ".csv";
        }

        FileInfo output_fileInfo = new FileInfo(output_csv_file);
        if (output_fileInfo.Exists)
        {
            output_csv_file = create_unique_output_file_name(output_csv_file);
            Console.Error.WriteLine("Output file alreadt exists, writing output to " + Path.GetFileName(output_csv_file));
        }

        PlayList play_list = XmlReaderPlistReader.ReadPlaylist(input_plist_file);

        if (play_list == null)
        {
            Console.Error.WriteLine("Failed to read playlist fome " + input_plist_file);
            return;
        }

        CsvMixCloudWriter.WriteCsv(output_csv_file, play_list);

        Console.WriteLine("Created Mixcloud playlist " + Path.GetFileName(output_csv_file));
    }

    static string create_unique_output_file_name(string output_file_name)
    {
        string unique_output_file_path;

        int count = 1;
        bool file_exists;

        string directory = Path.GetDirectoryName(output_file_name); 
        string base_name = Path.GetFileNameWithoutExtension(output_file_name); 
        string extension = Path.GetExtension(output_file_name);

        do
        {
            string unique_output_file_name = base_name + " (" + count.ToString() + ")"  + extension;

            unique_output_file_path = (directory == null) ? unique_output_file_name : directory + "\\" + unique_output_file_name;

            FileInfo fileInfo = new FileInfo(unique_output_file_path);
            file_exists = fileInfo.Exists;
        }
        while (file_exists);

        return unique_output_file_path;
    }

}





