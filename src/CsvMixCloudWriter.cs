using System.Collections.Generic;
using System.IO;

namespace playlist2csv
{
    /// <summary>
    /// Super simple class to write a playlist to a comma seperated values file, whose contents can be 
    /// cut and paste into a Mixcloud shows “Tracklist & Timestamp” section.
    /// </summary>
    internal class CsvMixCloudWriter
    {
        /// <summary>
        /// Writes the playlist to the given output file
        /// </summary>
        /// <param name="output_file">The output file name.</param>
        /// <param name="play_list">The play list to write out to the CSV file.</param>
        internal static void WriteCsv(string output_file, PlayList play_list)
        {
            List<Track> tracks = play_list.Tracks;

            using (StreamWriter writer = new StreamWriter(output_file))
            {
                foreach (var track in tracks) 
                {                   
                    string formatted_artist = format_string(track.Artist);
                    string formatted_title = format_string(track.Title);
                    string time_stamp = convertIntTimeStampToString(track.TimeStamp, play_list.SampleRate);

                    string line = formatted_artist + "," + formatted_title + "," + time_stamp;
                    writer.WriteLine(line);
                    writer.Flush();
                }
            }
        }


        /// <summary>
        /// Method to format a string suitable for a Mixcloud entry in either 
        /// the 'Artist' or 'Track Name' columns
        /// </summary>
        /// <param name="input_string">The unformatted string.</param>
        /// <returns>The formatted string.</returns>
        private static string format_string(string input_string)
        {
            // Replace the Apple DTD PLIST XML '&amp;' text entry with a simple '&'
            string output_string = input_string.Replace("&amp;", "&");

            // No easy way to get a comma into the CSV file which Mixcloud can read. For now
            // convert the comma to an ampersand which reads well in most cases.
            output_string = output_string.Replace(",", " &");

            return output_string;
        }


        /// <summary>
        /// Converts an Apple DTD PLIST time stamp from an integer value to a time elapsed string 
        /// </summary>
        /// <param name="time_stamp">An integer value from the playlist_TimeStamp array section of the Apple DTD PLIST.</param>
        /// <param name="sample_rate">The sample rate specified in the same Apple DTD PLIST </param>
        /// <returns></returns>
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
