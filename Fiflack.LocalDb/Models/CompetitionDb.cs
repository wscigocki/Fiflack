using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fiflack.LocalDb.Models
{
    [Table("Competitions")]
    public class CompetitionDb
    {
        [Key]
        public int Id { get; set; }

        public int Index { get; set; }

        public DateTime DateTime { get; set; }

        public List<CompetitionMatchDb> Matches { get; set; }
    }
}