namespace EPD.SpecApp.Client.ViewModels
{
    public interface ITabViewModel
    {
        void Activate();

        string Title { get; }
    }
}