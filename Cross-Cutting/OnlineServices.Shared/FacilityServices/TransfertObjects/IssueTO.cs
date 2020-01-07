using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.TranslationServices.TransfertObjects;

namespace OnlineServices.Shared.FacilityServices.TransfertObjects
{
    public class IssueTO : IEntity<int>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public MultiLanguageString Name { get; set; }
    }
}
