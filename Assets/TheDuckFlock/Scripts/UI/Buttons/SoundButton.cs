using System.Collections;
using System.Collections.Generic;
using TheDuckFlock;
using UnityEngine;

public class SoundButton : CoreButton
{
    public void PropagateState()
    {
        SoundManager.Instance.SwitchSoundMute(!isOn);
    }
}
