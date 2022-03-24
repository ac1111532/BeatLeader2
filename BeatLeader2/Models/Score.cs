using System;
using System.Collections.Generic;

namespace BeatLeader2.Models
{
    public class Score
    {
        public int ScoreID { get; set; }
        public int BeatmapID { get; set; }
        public int PlayerID { get; set; }
        public int Multiplier { get; set; }
        public string ?Rank { get; set; }
        public decimal Percentage { get; set; }
        public int score { get; set; }
        public bool FullCombo { get; set; }

        public ICollection<Beatmap> ?beatmap { get; set; }


    }
}