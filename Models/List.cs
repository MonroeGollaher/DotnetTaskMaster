namespace DotnetTaskMaster.Models
{
    public class List
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public string CreatorId { get; set; }
        public Profile Creator { get; set; }
    }
}