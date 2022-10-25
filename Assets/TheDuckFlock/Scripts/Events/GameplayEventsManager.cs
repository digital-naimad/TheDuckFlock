
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

            // PLAYER TANK SPAWN
            //RegisterListener(GameplayEvent.PlayerTankSpawn, listeners.OnPlayerTankSpawn);

            // PLAYER TANK MOVE
           // RegisterListener(GameplayEvent.PlayerTankMove, listeners.OnPlayerTankMove);
        }

        private static void RemoveListeners()
        {
            if (CurrentListeners == null)
            {
                return;
            }

            // PLAYER TANK SPAWN
           // UnregisterListener(GameplayEvent.PlayerTankSpawn, CurrentListeners.OnPlayerTankSpawn);

            // PLAYER TANK MOVE
            //UnregisterListener(GameplayEvent.PlayerTankMove, CurrentListeners.OnPlayerTankMove);
        }

    }
}