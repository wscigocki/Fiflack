using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiflack.LocalDb.Models
{
    [Table("MatchScores")]
    public class MatchScoreDb
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Players")]
        public int PlayerId_1 { get; set; }

        [ForeignKey("Players")]
        public int PlayerId_2 { get; set; }

        public int GoalsOfPlayer_1 { get; set; }

        public int GoalsOfPlayer_2 { get; set; }

        public DateTime PlayedOn { get; set; }
    }
}