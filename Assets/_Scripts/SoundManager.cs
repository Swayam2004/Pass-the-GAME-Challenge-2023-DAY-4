using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private AudioClipsRefSO _audioClipsRefSO;

    private float _volume;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one SoundManager");
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _volume = 0.5f;
    }

    private void Start()
    {
        _audioClipsRefSO = Game.Instance.GetAudioClipsRefSO();

    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f, bool isGamePlayingRequired = false)
    {
        if (!isGamePlayingRequired)
        {
            AudioSource.PlayClipAtPoint(audioClip, position, _volume * volumeMultiplier);
        }
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volumeMultiplier = 1f, bool isGamePlayingRequired = false)
    {

        if (!isGamePlayingRequired)
        {
            PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volumeMultiplier, isGamePlayingRequired);
        }
    }

    public void PlayStormWhooshSound(Vector3 stormPosition, float volume)
    {
        PlaySound(_audioClipsRefSO.StormWhooshSound, stormPosition, volume);
    }

    public void PlayHurtSound(Vector3 hurtPosition, float volume)
    {
        PlaySound(_audioClipsRefSO.HurtSounds, hurtPosition, volume);
    }

    public void PlayBoostSound(Vector3 boostPosition, float volume)
    {
        PlaySound(_audioClipsRefSO.BoostSound, boostPosition, volume);
    }

    public void PlayPickUpSound(Vector3 pickUpPosition, float volume)
    {
        PlaySound(_audioClipsRefSO.PickUpSounds, pickUpPosition, volume);
    }

    public float GetVolume()
    {
        return _volume;
    }

}
