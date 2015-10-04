using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSNFLParser
{
    class WeeklyStats
    {
        public int week { get; set; }
        public NFL_Teams opponent { get; set; }
        public int team_points { get; set; }
        public int opponents_points { get; set; }
        public bool at_home { get; set; }
        public bool won { get; set; }
        
        /* Passing */
        public int passing_completions { get; set; }
        public int passing_attempts { get; set; }
        public double passing_percentage { get; set; }
        public int passing_yards { get; set; }
        public double passing_yards_per_attempt { get; set; }
        public double passing_yards_per_completion { get; set; }
        public int passing_touchdowns { get; set; }
        public int passing_interceptions { get; set; }
        public double passing_qbr { get; set; }
        public int passing_sacks { get; set; }
        public int passing_sacks_yards_lost { get; set; }
        public int passing_first_down { get; set; }
        public int passing_fumbles { get; set; }
        public int passing_fumbles_lost { get; set; }

        /* Rushing */
        public int rushing_attempts { get; set; }
        public int rushing_yards { get; set; }
        public double rushing_average_yards { get; set; }
        public int rushing_touchdowns { get; set; }
        public int rushing_first_down { get; set; }

        /* Kicking */
        public int kicking_points { get; set; }
        public int kicking_field_goals_made { get; set; }
        public int kicking_field_goals_attempted { get; set; }
        public double kicking_field_goal_percentage { get; set; }
        public int kicking_field_goals_long { get; set; }
        public int kicking_field_goals_blocked { get; set; }
        public int kicking_extra_points_made { get; set; }
        public int kicking_extra_points_attempted { get; set; }
        public double kicking_extra_points_percentage { get; set; }
        public int kicking_extra_points_blocked { get; set; }

        /* Punting */
        public int num_punts { get; set; }
        public int punt_yards { get; set; }
        public double punt_average { get; set; }
        
        /* Kick Returns */
        public int num_kick_returns { get; set; }
        public int kick_return_yards { get; set; }
        public double kick_return_average { get; set; }
        public int kick_return_touchdowns { get; set; }
        public int kick_return_long { get; set; }

        /* Punt Returns */
        public int num_punt_returns { get; set; }
        public int punt_return_yards { get; set; }
        public double punt_return_average { get; set; }
        public int punt_return_touchdowns { get; set; }
        public int punt_return_long { get; set; }

        /* Defense */
        public int points_allowed { get; set; }
        public int tackles { get; set; }
        public int solo_tackles { get; set; }
        public int assisted_tackles { get; set; }
        public int sacks { get; set; }
        public int sack_yards { get; set; }
        public int interceptions { get; set; }
        public int interception_touchdowns { get; set; }
        public int forced_fumbles { get; set; }
        public int fumbles_recovered { get; set; }
        public int fumbles_touchdowns { get; set; }
        public int passes_defended { get; set; }
        public int stuffs { get; set; }
        public int stuffs_yards { get; set; }
        public int safties { get; set; }

        /* Downs */
        public int num_first_downs { get; set; }
        public int num_first_down_rushes { get; set; }
        public int num_first_down_passes { get; set; }
        public int third_down_conversions { get; set; }
        public int third_down_attempts { get; set; }
        public double third_down_percentage { get; set; }
        public int fourth_down_conversions { get; set; }
        public int fourth_down_attempts { get; set; }
        public double fourth_down_percentage { get; set; }

        /* Penalties */
        public int num_penalties { get; set; }
        public int first_down_penalties { get; set; }
        public int penalty_yards { get; set; }

        /* Turnovers */
        public int turnover_margin { get; set; }
        public int turnover_int_thrown { get; set; }
        public int turnover_fumbles_lost { get; set; }
        public int turnover_int_caught { get; set; }
        public int turnover_fum_rec { get; set; }

        public WeeklyStats()
        {
            // Do not use this version of the constructor. Use only the string input constructor
        }

        
    }
}
