
namespace TheDuckFlock
{
    public interface IGameplayEventsListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        public void OnStartGame(params int[] parameters);

    }
}
