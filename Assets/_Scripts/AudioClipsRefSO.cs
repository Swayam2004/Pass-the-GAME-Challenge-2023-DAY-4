using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "AudioClipsRefSO", menuName = "Scriptable Objects/AudioClipsRefSO")]
public class AudioClipsRefSO : ScriptableObject
{
    public AudioClip TruckSound;
    public AudioClip BoostSound;
    public AudioClip StormWhooshSound;
    public AudioClip[] PoliceSirenSounds;
    public AudioClip[] HurtSounds;
    public AudioClip[] PickUpSounds;
}
