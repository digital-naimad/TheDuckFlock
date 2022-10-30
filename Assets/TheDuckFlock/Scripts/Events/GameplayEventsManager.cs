
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

            RegisterListener(GameplayEvent.StartGame, listeners.OnStartGame);

            RegisterListener(GameplayEvent.DucksMotherLost, listeners.OnDucksMotherLost);

            RegisterListener(GameplayEvent.EggLost, listeners.OnEggLost);
            RegisterListener(GameplayEvent.EggHatched, listeners.OnEggHatched);

        }

        public static void RemoveListeners()
        {
            if (CurrentListeners == null)
            {
                return;
            }

            UnregisterListener(GameplayEvent.StartGame, CurrentListeners.OnStartGame);

            UnregisterListener(GameplayEvent.DucksMotherLost, CurrentListeners.OnDucksMotherLost);

            UnregisterListener(GameplayEvent.EggLost, CurrentListeners.OnEggLost);
            UnregisterListener(GameplayEvent.EggHatched, CurrentListeners.OnEggHatched);

        }

    }
}