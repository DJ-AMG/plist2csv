using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace playlist2csv
{

    /// <summary>
    /// Utility class to read an Apple DTD PLIST XML file, as produced by Pioneer's DJM-REC app into an in memory 
    /// representation of the play list. 
    /// </summary>
    /// 
    internal class XmlReaderPlistReader
    {
        public static PlayList ReadPlaylist(string file_path)
        {           
            XmlReaderSettings xmrs = new XmlReaderSettings();
            xmrs.DtdProcessing = DtdProcessing.Parse;

            XmlReader xmr = null;

            List<string> playlist_Artist = null;
            List<string> playlist_Title = null;
            List<int> playlist_TimeStamp = null;

            double sample_rate = 0.0;

            try
            {
                xmr = XmlReader.Create(file_path, xmrs);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (xmr == null)
            {
                return null;
            }

            xmr.MoveToContent();

            try
            {
                xmr.ReadStartElement("plist");
                xmr.MoveToElement();
                xmr.ReadStartElement("dict");
                xmr.MoveToElement();

                bool hasMoreContent = false;
                do
                {
                    hasMoreContent = xmr.ReadToNextSibling("key");
                    if (hasMoreContent)
                    {                 
                        string key = xmr.ReadElementContentAsString("key", "");

                        if (key == "playlist_Artist")
                        {
                            playlist_Artist = readArrayElementsAsString(xmr);
                        }
                        else  if (key == "playlist_TimeStamp")
                        {
                            playlist_TimeStamp = readArrayElementsAsInt(xmr);
                        }
                        else if (key == "playlist_Title")
                        {
                            playlist_Title = readArrayElementsAsString(xmr);
                        }
                        else if (key == "plist_SampleRate")
                        {
                            xmr.MoveToElement();
                            xmr.MoveToContent();
                            sample_rate = xmr.ReadElementContentAsDouble();
                        }
                    }
                }
                while (hasMoreContent);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (playlist_Artist == null)
            {
                Console.WriteLine("No artist list specified");
                return null;
            }

            if (playlist_Title == null)
            {
                Console.WriteLine("No title list specified");
                return null;
            }

            if (playlist_Title.Count != playlist_Artist.Count)
            {
                Console.WriteLine("Title and Artist lists have different sizes");
                return null;
            }

            if (playlist_TimeStamp != null && playlist_TimeStamp.Count != playlist_Title.Count)
            {
                Console.WriteLine("TimeStamp and Artist lists have different sizes");
                return null;
            }

            List<Track> tracks = new List<Track>();

            int count = playlist_Title.Count;

            for (int index = 0; index < count; index++)
            {

                int time_stamp = 0;

                if (playlist_TimeStamp != null)
                {
                    time_stamp = playlist_TimeStamp[index];
                }

                tracks.Add(new Track(playlist_Artist[index], playlist_Title[index], time_stamp));
            }

            return new PlayList(tracks, sample_rate);
        }

        private static List<string> readArrayElementsAsString(XmlReader xmr)
        {
            const string content_type = "string";
            List<string> list = new List<string>();

            xmr.MoveToElement();
            xmr.ReadStartElement();
   
            bool hasMoreContent = false;
            do
            {
                hasMoreContent = xmr.ReadToNextSibling(content_type);
                if (hasMoreContent)
                {
                    string content = xmr.ReadElementContentAsString(content_type, "");
                    list.Add(content);
                }
            }
            while (hasMoreContent);

            return list;
        }

        private static List<int> readArrayElementsAsInt(XmlReader xmr)
        {
            const string content_type = "integer";
            List<int> list = new List<int>();

            xmr.MoveToElement();
            xmr.ReadStartElement();

            bool hasMoreContent = false;
            do
            {
                hasMoreContent = xmr.ReadToNextSibling(content_type);
                if (hasMoreContent)
                {
                    int time_stamp = xmr.ReadElementContentAsInt(content_type, "");                
                    list.Add(time_stamp);
                }
            }
            while (hasMoreContent);

            return list;
        }
    }
}