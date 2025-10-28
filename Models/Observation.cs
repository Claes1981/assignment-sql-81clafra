using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_sql_81clafra.Models
{
    public class Observation
    {
        // Parameterless constructor for 'new' hunters before DB insert
        // Perplexity: https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#2
        public Observation() { }

        // Generated with help from Visual Studio Code
        public Observation(int id, int monsterId, int locationId, int hunterId, string description, string dateSeen)
        {
            Id = id;
            MonsterId = monsterId;
            LocationId = locationId;
            HunterId = hunterId;
            Description = description;
            DateSeen = dateSeen;
        }

        // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
        public int Id { get; set; }
        public int MonsterId { get; set; }
        public int LocationId { get; set; }
        public int HunterId { get; set; }
        public string Description { get; set; }
        public string DateSeen { get; set; }
    }
}