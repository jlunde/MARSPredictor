using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSNFLParser
{
    class Parser
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Parser Started");

            NFL nfl_season = new NFL();
            import_season_stats(nfl_season);


            Console.Read();
        }

        static bool import_season_stats(NFL season)
        {
            int index = 0;

            var inputLines = File.ReadAllLines(@"C:\NFL_Data\2014\ravens.csv");
            foreach (string week in inputLines)
            {
                season.ravens_season[index] = new WeeklyStats();
                parse_weekly_stats(season.ravens_season[index], week);
                Console.WriteLine(season.ravens_season[index].turnover_margin);
                index++;
            }

            return true;
        }

        static bool parse_weekly_stats(WeeklyStats nfl_week, string input_line)
        {
            string[] split_line = input_line.Split(',');
            if (split_line.Length != 80)
            {
                Console.WriteLine("Num lines " + split_line.Length);
                Console.WriteLine("Error Reading File. Num inputs is not correct");
                return false;
            }

            if ("bye".Equals(split_line[1].ToLower()))
            {
                return false;
            }

            nfl_week.week = Convert.ToInt32(split_line[0]);
            //this.opponent = something...
            nfl_week.team_points = Convert.ToInt32(split_line[2]);
            nfl_week.opponents_points = Convert.ToInt32(split_line[3]);
            nfl_week.at_home = parseBool(split_line[4]);
            nfl_week.won = parseBool(split_line[5]);

            nfl_week.passing_completions = Convert.ToInt32(split_line[6]);
            nfl_week.passing_attempts = Convert.ToInt32(split_line[7]);
            nfl_week.passing_percentage = Convert.ToDouble(split_line[8]);
            nfl_week.passing_yards = Convert.ToInt32(split_line[9]);
            nfl_week.passing_yards_per_attempt = Convert.ToDouble(split_line[10]);
            nfl_week.passing_yards_per_completion = Convert.ToDouble(split_line[11]);
            nfl_week.passing_touchdowns = Convert.ToInt32(split_line[12]);
            nfl_week.passing_interceptions = Convert.ToInt32(split_line[13]);
            nfl_week.passing_qbr = Convert.ToDouble(split_line[14]);
            nfl_week.passing_sacks = Convert.ToInt32(split_line[15]);
            nfl_week.passing_sacks_yards_lost = Convert.ToInt32(split_line[16]);
            nfl_week.passing_first_down = Convert.ToInt32(split_line[17]);
            nfl_week.passing_fumbles = Convert.ToInt32(split_line[18]);
            nfl_week.passing_fumbles_lost = Convert.ToInt32(split_line[19]);

            nfl_week.rushing_attempts = Convert.ToInt32(split_line[20]);
            nfl_week.rushing_yards = Convert.ToInt32(split_line[21]);
            nfl_week.rushing_average_yards = Convert.ToDouble(split_line[22]);
            nfl_week.rushing_touchdowns = Convert.ToInt32(split_line[23]);
            nfl_week.rushing_first_down = Convert.ToInt32(split_line[24]);

            nfl_week.kicking_points = Convert.ToInt32(split_line[25]);
            nfl_week.kicking_field_goals_made = Convert.ToInt32(split_line[26]);
            nfl_week.kicking_field_goals_attempted = Convert.ToInt32(split_line[27]);
            nfl_week.kicking_field_goal_percentage = Convert.ToDouble(split_line[28]);
            nfl_week.kicking_field_goals_long = Convert.ToInt32(split_line[29]);
            nfl_week.kicking_field_goals_blocked = Convert.ToInt32(split_line[30]);
            nfl_week.kicking_extra_points_made = Convert.ToInt32(split_line[31]);
            nfl_week.kicking_extra_points_attempted = Convert.ToInt32(split_line[32]);
            nfl_week.kicking_extra_points_percentage = Convert.ToDouble(split_line[33]);
            nfl_week.kicking_extra_points_blocked = Convert.ToInt32(split_line[34]);

            nfl_week.num_punts = Convert.ToInt32(split_line[35]);
            nfl_week.punt_yards = Convert.ToInt32(split_line[36]);
            nfl_week.punt_average = Convert.ToDouble(split_line[37]);

            nfl_week.num_kick_returns = Convert.ToInt32(split_line[38]);
            nfl_week.kick_return_yards = Convert.ToInt32(split_line[39]);
            nfl_week.kick_return_average = Convert.ToDouble(split_line[40]);
            nfl_week.kick_return_touchdowns = Convert.ToInt32(split_line[41]);
            nfl_week.kick_return_long = Convert.ToInt32(split_line[42]);

            nfl_week.num_punt_returns = Convert.ToInt32(split_line[43]);
            nfl_week.punt_return_yards = Convert.ToInt32(split_line[44]);
            nfl_week.punt_return_average = Convert.ToDouble(split_line[45]);
            nfl_week.punt_return_touchdowns = Convert.ToInt32(split_line[46]);
            nfl_week.punt_return_long = Convert.ToInt32(split_line[47]);

            nfl_week.points_allowed = Convert.ToInt32(split_line[48]);
            nfl_week.tackles = Convert.ToInt32(split_line[49]);
            nfl_week.solo_tackles = Convert.ToInt32(split_line[50]);
            nfl_week.assisted_tackles = Convert.ToInt32(split_line[51]);
            nfl_week.sacks = Convert.ToInt32(split_line[52]);
            nfl_week.sack_yards = Convert.ToInt32(split_line[53]);
            nfl_week.interceptions = Convert.ToInt32(split_line[54]);
            nfl_week.interception_touchdowns = Convert.ToInt32(split_line[55]);
            nfl_week.forced_fumbles = Convert.ToInt32(split_line[56]);
            nfl_week.fumbles_recovered = Convert.ToInt32(split_line[57]);
            nfl_week.fumbles_touchdowns = Convert.ToInt32(split_line[58]);


            nfl_week.passes_defended = Convert.ToInt32(split_line[59]);
            nfl_week.stuffs = Convert.ToInt32(split_line[60]);
            nfl_week.stuffs_yards = Convert.ToInt32(split_line[61]);
            nfl_week.safties = Convert.ToInt32(split_line[62]);

            nfl_week.num_first_downs = Convert.ToInt32(split_line[63]);
            nfl_week.num_first_down_rushes = Convert.ToInt32(split_line[64]);
            nfl_week.num_first_down_passes = Convert.ToInt32(split_line[65]);
            nfl_week.third_down_conversions = Convert.ToInt32(split_line[66]);
            nfl_week.third_down_attempts = Convert.ToInt32(split_line[67]);
            nfl_week.third_down_percentage = Convert.ToDouble(split_line[68]);
            nfl_week.fourth_down_conversions = Convert.ToInt32(split_line[69]);
            nfl_week.fourth_down_attempts = Convert.ToInt32(split_line[70]);
            nfl_week.fourth_down_percentage = Convert.ToDouble(split_line[71]);

            nfl_week.num_penalties = Convert.ToInt32(split_line[72]);
            nfl_week.first_down_penalties = Convert.ToInt32(split_line[73]);
            nfl_week.penalty_yards = Convert.ToInt32(split_line[74]);

            nfl_week.turnover_margin = Convert.ToInt32(split_line[75]);
            nfl_week.turnover_int_thrown = Convert.ToInt32(split_line[76]);
            nfl_week.turnover_fumbles_lost = Convert.ToInt32(split_line[77]);
            nfl_week.turnover_int_caught = Convert.ToInt32(split_line[78]);
            nfl_week.turnover_fum_rec = Convert.ToInt32(split_line[79]);


            
            return true;
        }

        static bool parseBool(string input)
        {
            if ("1".Equals(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
