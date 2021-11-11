
namespace Common
{
    public interface IAuditEntity
    {
        string CreatedBy { get; set; }
        System.DateTime CreatedOn { get; set; }
        string UpdatedBy { get; set; }
        System.DateTime? UpdatedOn { get; set; }
        bool Enabled { get; set; }
    }
}
