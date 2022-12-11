
namespace TheDuckFlock
{
    public class MusicButton : CoreButton
    {
        public void PropagateState()
        {
            SoundManager.Instance.SwitchMusicMute(!isOn);
        }
       
    }
}
