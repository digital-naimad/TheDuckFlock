namespace TheDuckFlock
{
    /// <summary>
    /// Implementation of Observer Pattern
    /// </summary>
    public class UIEventsManager : EventsManager<UIEvent, IUIEventsListener<int>, int>
    {
        public static void SetupListeners(IUIEventsListener<int> listeners)
        {
            RemoveListeners();

            CurrentListeners = listeners;

            RegisterListener(UIEvent.CloseStartPopup, listeners.OnCloseStartPopup);
            RegisterListener(UIEvent.ShowResultsPopup, listeners.OnShowResultsPopup);

        }

        public static void RemoveListeners()
        {
            if (CurrentListeners == null)
            {
                return;
            }

            UnregisterListener(UIEvent.CloseStartPopup, CurrentListeners.OnCloseStartPopup);
            UnregisterListener(UIEvent.ShowResultsPopup, CurrentListeners.OnShowResultsPopup);

        }

    }
}