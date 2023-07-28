using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _policeAudioSource;

    private void Start()
    {
        int randomPoliceClipIndex = Random.Range(0, Game.Instance.GetAudioClipsRefSO().PoliceSirenSounds.Length);
        _policeAudioSource.clip = Game.Instance.GetAudioClipsRefSO().PoliceSirenSounds[randomPoliceClipIndex];

        _policeAudioSource.Play();
    }
}
