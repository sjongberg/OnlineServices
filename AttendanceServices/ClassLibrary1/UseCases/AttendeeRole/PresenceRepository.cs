namespace AttendanceServices.BusinessLayer.UseCases
{
    //Move to DataLayer 
    public interface IPresenceRepository
    {
        bool Insert(AttendeePresentEF presence);
    }
}