using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fiflack.LocalDb.Models
{
    [Table("CompetitionMatches")]
    public class CompetitionMatchDb
    {
        [Key]
        public int Id { get; set; }

        public CompetitionDb Competition { get; set; }


        public MatchScoreDb Match { get; set; }
    }
}