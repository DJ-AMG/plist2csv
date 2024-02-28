using System.IO;

using System.Collections.Generic;


namespace playlist2csv
{
    internal class CsvMixCloudWriter
    {
        internal static void WriteCsv(string output_path, PlayList play_list)
        {
            List<Track> tracks = play_list.Tracks;

            using (var w = new StreamWriter(output_path))
            {
                foreach (var track in tracks) 
                {                   
                    string formatted_artist = format_string(track.Artist);
                    string formatted_title = format_string(track.Title);
                    string time_stamp = convertIntTimeStampToString(track.TimeStamp, play_list.SampleRate);

                    string line = formatted_artist + "," + formatted_title + "," + time_stamp;
                    w.WriteLine(line);
                    w.Flush();
                }
            }
        }

        private static string format_string(string input_string)
        {
            string output_string = input_string.Replace("&amp;", "&");
            output_string = output_string.Replace(",", " &");

            return output_string;
        }

        private static string convertIntTimeStampToString(int time_stamp, double sample_rate)
        {

            double total_time_in_secs = time_stamp / sample_rate;

            int raw_mins = (int)(total_time_in_secs / 60.0);
            int mins = raw_mins % 60;
            int hours = (int)(raw_mins / 60.0);
            double secs = total_time_in_secs - (raw_mins * 60);

            string time_stamp_as_string = hours.ToString("00") + ":" + mins.ToString("00") + ":" + secs.ToString("00");

            return time_stamp_as_string;
        }
    }
}
