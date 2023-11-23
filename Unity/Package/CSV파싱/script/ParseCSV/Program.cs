using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ParseCSV
{
    class Program {
        static void Main(string[] args){
            var path = "../../src/Player.csv";
            var players = File.ReadAllLines(path)
                .Skip(1)
                .Where(row => row.Length > 0)
                .Select(row => Player.ParseRow(row))
                .ToList();
            
            foreach(var P in Players){
                Console.WriteLine($"{P.PlayerName} {P.Country}");
            }

            Console.ReadLine();   
        }
        public class Player 
        {
            public int      Id {get; set;}
            public string   PlayerName {get; set;}
            public string   PlayerDOB {get; set;}
            public string   PlayerBattingHand {get; set;}
            public string   BowlingSkill {get; set;}
            public string   Country {get; set;}
            public string   IsUmpire {get; set;}

            internal static Player ParseRow(string row){
                var columns = row.Split(',');
                return new Player() {
                    Id  = int.Parse(columns[0]) ,
                    PlayerName = columns[1] , 
                    PlayerDOB = columns[2] , 
                    PlayerBattingHand = columns[3] , 
                    BowlingSkill = columns[4] , 
                    Country = columns[5] , 
                    IsUmpire = columns[6]
                };
            }
        }
    }
}