namespace Ecommerce.Data.Entities.Interfaces;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public void SoftDelete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.Now;
    }
    public void UndoDelete()
    {
        IsDeleted = false;
        DeletedAt = null;
    }

}
