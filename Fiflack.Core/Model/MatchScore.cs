using System;

namespace Fiflack.Core.Model
{
    public class MatchScore
    {
        public int Id { get; set; }

        public int PlayerId_1 { get; set; }

        public int PlayerId_2 { get; set; }

        public int GoalsOfPlayer_1 { get; set; }

        public int GoalsOfPlayer_2 { get; set; }

        public DateTime PlayedOn { get; set; }
    }
}