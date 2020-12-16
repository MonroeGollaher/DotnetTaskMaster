namespace DotnetTaskMaster.Models
{
    public class Task
    {
        public Profile Creator { get; set; }
        public string CreatorId { get; set; }
        public int ListId { get; set; }
        public int Id { get; set; }
        public string Body { get; set; }
        public bool IsCompleted { get; set; }
    }
}