using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_sql_81clafra.Models
{
    public class Hunter
    {
        // Parameterless constructor for 'new' hunters before DB insert
        // Perplexity: https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#2
        public Hunter() { }

        // Generated with help from Visual Studio Code
        public Hunter(int id, string name, string experienceLevel)
        {
            Id = id;
            Name = name;
            ExperienceLevel = experienceLevel;
        }

        // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
        public int Id { get; set; }
        public string Name { get; set; }
        public string ExperienceLevel { get; set; }
    }
}