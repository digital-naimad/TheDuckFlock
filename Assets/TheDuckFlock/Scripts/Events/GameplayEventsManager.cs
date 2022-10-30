
namespace TheDuckFlock
{
    /// <summary>
    /// Implementation of Observer Pattern
    /// </summary>
    public class GameplayEventsManager : EventsManager<GameplayEvent, IGameplayEventsListener>
    {
        public static void SetupListeners(IGameplayEventsListener listeners)
        {
            RemoveListeners();

            CurrentListeners = listeners;

            // StartGame
            RegisterListener(GameplayEvent.StartGame, listeners.OnStartGame);

        }

        public static void RemoveListeners()
        {
            if (CurrentListeners == null)
            {
                return;
            }

            // StartGame
            UnregisterListener(GameplayEvent.StartGame, CurrentListeners.OnStartGame);

        }

    }
}