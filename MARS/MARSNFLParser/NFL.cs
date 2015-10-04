using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSNFLParser
{
    enum NFL_Teams
    {
        Ravens,
        Bengals,
        Steelers,
        Browns,

        Texans,
        Colts,
        Jaguars,
        Titans,

        Bills,
        Dolphins,
        Patriots,
        Jets,

        Broncos,
        Chiefs,
        Raiders,
        Chargers,

        Bears,
        Lions,
        Packers,
        Vikings,

        Falcons,
        Panthers,
        Saints,
        Buccaneers,

        Cowboys,
        Giants,
        Eagles,
        Redskins,

        Cardinals,
        Niners,
        Seahawks,
        Rams
    }
    class NFL
    {
        public WeeklyStats[] ravens_season;
        public WeeklyStats[] bengals_season;
        public WeeklyStats[] steelers_season;
        public WeeklyStats[] browns_season;

        public WeeklyStats[] texans_season;
        public WeeklyStats[] colts_season;
        public WeeklyStats[] jaguars_season;
        public WeeklyStats[] titans_season;

        public WeeklyStats[] bills_season;
        public WeeklyStats[] dolphins_season;
        public WeeklyStats[] patriots_season;
        public WeeklyStats[] jets_season;

        public WeeklyStats[] broncos_season;
        public WeeklyStats[] chiefs_season;
        public WeeklyStats[] raiders_season;
        public WeeklyStats[] chargers_season;

        public WeeklyStats[] bears_season;
        public WeeklyStats[] lions_season;
        public WeeklyStats[] packers_season;
        public WeeklyStats[] vikings_season;

        public WeeklyStats[] falcons_season;
        public WeeklyStats[] panthers_season;
        public WeeklyStats[] saints_season;
        public WeeklyStats[] buccaneers_season;

        public WeeklyStats[] cowboys_season;
        public WeeklyStats[] giants_season;
        public WeeklyStats[] eagles_season;
        public WeeklyStats[] redskins_season;

        public WeeklyStats[] cardinals_season;
        public WeeklyStats[] niners_season;
        public WeeklyStats[] seahawks_season;
        public WeeklyStats[] rams_season;


        public NFL()
        {
            this.ravens_season = new WeeklyStats[17];
            this.bengals_season = new WeeklyStats[17];
            this.steelers_season = new WeeklyStats[17];
            this.browns_season = new WeeklyStats[17];

            this.texans_season = new WeeklyStats[17];
            this.colts_season = new WeeklyStats[17];
            this.jaguars_season = new WeeklyStats[17];
            this.titans_season = new WeeklyStats[17];

            this.bills_season = new WeeklyStats[17];
            this.dolphins_season = new WeeklyStats[17];
            this.patriots_season = new WeeklyStats[17];
            this.jets_season = new WeeklyStats[17];

            this.broncos_season = new WeeklyStats[17];
            this.chiefs_season = new WeeklyStats[17];
            this.raiders_season = new WeeklyStats[17];
            this.chargers_season= new WeeklyStats[17];

            this.bears_season = new WeeklyStats[17];
            this.lions_season = new WeeklyStats[17];
            this.packers_season = new WeeklyStats[17];
            this.vikings_season = new WeeklyStats[17];

            this.falcons_season = new WeeklyStats[17];
            this.panthers_season= new WeeklyStats[17];
            this.saints_season = new WeeklyStats[17];
            this.buccaneers_season = new WeeklyStats[17];

            this.cowboys_season = new WeeklyStats[17];
            this.giants_season = new WeeklyStats[17];
            this.eagles_season = new WeeklyStats[17];
            this.redskins_season = new WeeklyStats[17];

            this.cardinals_season = new WeeklyStats[17];
            this.niners_season = new WeeklyStats[17];
            this.seahawks_season = new WeeklyStats[17];
            this.rams_season = new WeeklyStats[17];
        }
    }
}
