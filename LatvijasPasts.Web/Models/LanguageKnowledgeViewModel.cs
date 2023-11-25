using LatvijasPasts.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace LatvijasPasts.Web.Models
{
    public class LanguageKnowledgeViewModel
    {
        public int Id { get; set; }
        public string? Language { get; set; }
        public KnowledgeLevel LanguageLevel { get; set; }

        public int CurriculumVitaeId { get; set; }
    }
}
