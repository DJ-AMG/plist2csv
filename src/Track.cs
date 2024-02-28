using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playlist2csv
{
    /// <summary>
    /// Class representing a single track in the play list (set). 
    /// </summary>
    /// 
    internal class Track
    {
        /// <summary>
        /// The name of the artist that produced the track.
        /// </summary>
        private string playlist_Artist;

        /// <summary>
        /// The title of the track.
        /// </summary>
        private string playlist_Title;

        /// <summary>
        /// The number of samples previously taken at the point the track was introduced into the set.
        /// </summary>
        private int playlist_TimeStamp;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="playlist_Artist">The artist, e.g. 'Daxson'.</param>
        /// <param name="playlist_Title">The track title, e.g. 'Now or Never'.</param>
        /// <param name="playlist_TimeStamp">The time stampe, e.g. 120000 (2.5 seconds).</param>
        public Track(string playlist_Artist, string playlist_Title, int playlist_TimeStamp)
        {
            this.playlist_Artist = playlist_Artist;
            this.playlist_Title = playlist_Title;
            this.playlist_TimeStamp = playlist_TimeStamp;
        }

        /// <summary>
        /// Gets the artist who produced the track.
        /// </summary>
        public string Artist
        { 
            get 
            { 
                return this.playlist_Artist; 
            } 
        }           

        /// <summary>
        /// Gets the name of the track.
        /// </summary>
        public string Title
        { 
            get 
            { 
                return this.playlist_Title; 
            } 
        }

        /// <summary>
        /// Gets the number of samples previously taken at the point the track was introduced into the set. 
        /// </summary>
        public int TimeStamp
        {
            get 
            { 
                return this.playlist_TimeStamp;
            }
        }
    }
}
