
namespace TheDuckFlock
{
    public interface IUIEventsListener<CustomParameterType>
    {
        public void OnCloseStartPopup(params CustomParameterType[] parameters);
        public void OnShowResultsPopup(params CustomParameterType[] parameters);
    }
}
