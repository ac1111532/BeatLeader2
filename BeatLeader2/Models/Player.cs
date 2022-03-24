using System;
using System.Collections.Generic;

namespace BeatLeader2.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string ?PlayerName { get; set; }
        public int AccountAge { get; set; }
        public string ?PlayerHMD { get; set; }
        public string ?PlayerPlatform { get; set; }
        public int Modcount { get; set; }
        public int LevelsBeaten { get; set; }
    }
}