namespace RPG.Core
{
    public interface IAction
    {
        void Cancel();
        string GetName();
    }
}
