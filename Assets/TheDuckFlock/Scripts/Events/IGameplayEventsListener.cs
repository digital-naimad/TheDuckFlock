
namespace TheDuckFlock
{
    public interface IGameplayEventsListener<CustomParameterType>
    {
        public void OnStartGame(params CustomParameterType[] parameters);

        public void OnDucksMotherLost(params CustomParameterType[] parameters);

        public void OnDuckieLost(params CustomParameterType[] parameters);

        public void OnEggLost(params CustomParameterType[] parameters);

        public void OnEggHatched(params CustomParameterType[] parameters);

    }
}
