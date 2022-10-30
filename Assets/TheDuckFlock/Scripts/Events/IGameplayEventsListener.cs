
namespace TheDuckFlock
{
    public interface IGameplayEventsListener
    {
        public void OnStartGame(params int[] parameters);

        public void OnDucksMotherLost(params int[] parameters);

        public void OnEggLost(params int[] parameters);
        public void OnEggHatched(params int[] parameters);

    }
}
