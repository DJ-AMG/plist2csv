using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist2csv
{
    internal class Track
    {
        private string playlist_Artist;
        private string playlist_Title;
        private int playlist_TimeStamp;

        public Track(string playlist_Artist, string playlist_Title, int playlist_TimeStamp)
        {
            this.playlist_Artist = playlist_Artist;
            this.playlist_Title = playlist_Title;
            this.playlist_TimeStamp = playlist_TimeStamp;
        }

        public string Artist
        { 
            get 
            { 
                return this.playlist_Artist; 
            } 
        }           
        public string Title
        { 
            get 
            { 
                return this.playlist_Title; 
            } 
        } 

        public int TimeStamp
        {
            get 
            { 
                return this.playlist_TimeStamp;
            }
        }
    }



}
