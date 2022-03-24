#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeatLeader2.Models;

    public class BeatLeader2ContextDb : DbContext
    {
        public BeatLeader2ContextDb (DbContextOptions<BeatLeader2ContextDb> options)
            : base(options)
        {
        }

        public DbSet<BeatLeader2.Models.Song> Song { get; set; }

        public DbSet<BeatLeader2.Models.Score> Score { get; set; }

        public DbSet<BeatLeader2.Models.Beatmap> Beatmap { get; set; }

        public DbSet<BeatLeader2.Models.Player> Player { get; set; }
    }
