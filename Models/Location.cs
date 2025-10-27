namespace assignment_sql_81clafra.Models
{
    public class Location
    {
        // Parameterless constructor for 'new' locations before DB insert
        // Perplexity: https://www.perplexity.ai/search/can-you-help-me-with-this-erro-1Vj.QVQzSbOfN8bbixFCdg#2
        public Location() { }

        // Generated with help from Visual Studio Code
        public Location(int id, string name, string region)
        {
            Id = id;
            Name = name;
            Region = region;
        }

        // Generated with help from TabbyML/Qwen2.5-Coder-7B-Instruct
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
    }
}