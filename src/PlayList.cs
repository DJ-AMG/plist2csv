using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist2csv
{
    internal class PlayList
    {
        private List<Track> tracks;
        private double samplerate;
        public PlayList (List<Track> tracks, double samplerate)
        {
            this.tracks = tracks;   
            this.samplerate = samplerate;
        }

        public List<Track> Tracks
        { 
            get 
            { 
                return tracks; 
            } 
        }      

        public double SampleRate
        { 
            get 
            {
                return samplerate; 
            } 
        }  
    }
}
