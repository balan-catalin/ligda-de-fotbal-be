namespace LigaDeFotbal.BBL.Interfaces
{
    public interface ILdfContext
    {
        Task<int> SaveChangesAsync();
    }
}