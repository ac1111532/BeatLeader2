using System;
using System.Collections.Generic;

namespace BeatLeader2.Models
{
    public class Beatmap
    {
        public int BeatmapID { get; set; }
        public int SongID { get; set; }
        public int Notes { get; set; }
        public int Walls { get; set; }
        public int Bombs { get; set; }
        public int Slash { get; set; }
        public int MapPlays { get; set; }

        public ICollection<Score>? Score { get; set; }
        public Song? song { get; set; }
    }
}