using OnlineServices.Shared.DataAccessHelpers;
using OnlineServices.Shared.TranslationServices.TransfertObjects;

namespace OnlineServices.Shared.FacilityServices.TransfertObjects
{
    public class RoomTO : IEntity<int>
    {
        public int Id { get; set; }
        public MultiLanguageString Name { get; set; }
        public FloorTO Floor { get; set; }
    }
}
