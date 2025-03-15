using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace CodeChallengeAPI.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Exchange { get; set; } = null!;

        public string Ticker { get; set; } = null!;

        //Regex isinRegex = new Regex(@"/^[A-Za-z]{2}/");
        [RegularExpression(@"^[^\d]{2}.*$", ErrorMessage = "The first two characters must be letters or non-numeric.")]
        public string Isin { get; set; } = null!;

        public string? Website { get; set; }
    }
}
