using System.Text.Json.Serialization;

namespace Server.CSharp.Models
{
    public class ComplexPersonTest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsMarried { get; set; }
        [JsonPropertyName("Birth_Date")]
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public decimal Salary { get; set; }
        public List<string> Hobbies { get; set; }
        public Dictionary<string, string> ContactInfo { get; set; }
        public Tuple<string, int, bool> PersonalInfo { get; set; }
    }

}
