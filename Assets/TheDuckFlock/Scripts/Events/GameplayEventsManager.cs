
using UnityEngine;

namespace TheDuckFlock
{
    /// <summary>
    /// Implementation of Observer Pattern
    /// </summary>
    public class GameplayEventsManager : EventsManager<GameplayEvent, IGameplayEventsListener<Vector3>, Vector3>
    {
        public static void SetupListeners(IGameplayEventsListener<Vector3> listeners)
        {
            RemoveListeners();

            CurrentListeners = listeners;

            RegisterListener(GameplayEvent.StartGame, listeners.OnStartGame);

            RegisterListener(GameplayEvent.DucksMotherLost, listeners.OnDucksMotherLost);
            RegisterListener(GameplayEvent.DuckieLost, listeners.OnDuckieLost);

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
            UnregisterListener(GameplayEvent.DuckieLost, CurrentListeners.OnDuckieLost);

            UnregisterListener(GameplayEvent.EggLost, CurrentListeners.OnEggLost);
            UnregisterListener(GameplayEvent.EggHatched, CurrentListeners.OnEggHatched);

        }

    }
}