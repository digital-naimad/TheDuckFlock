/// <summary>
/// Interface using by ObjectPooler and implementing in Enemy controller class
/// </summary>
namespace TheDuckFlock
{
    public interface IPooledObject
    {
        void OnSpawn();
    }
}