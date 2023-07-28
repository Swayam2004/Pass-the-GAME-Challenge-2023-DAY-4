using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RadioManager : MonoBehaviour
{
    public AudioClip[] clips;

    public List<AudioClip> alreadyUsed;
    public AudioSource source;

    public AudioClip transition;

    public float transitionTime;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        alreadyUsed = clips.OrderBy(x => Random.value).ToList();
        StartCoroutine(PlayScheduele(source));

    }
    private IEnumerator PlayScheduele(AudioSource source)
    {

        yield return StartCoroutine(PlaySimple(source, transition));
        while (true)
        {
            yield return PlaySimple(source, ChooseNewClip());
            yield return new WaitForSeconds(transitionTime);
            yield return StartCoroutine(PlaySimple(source, transition));

        }
    }
    AudioClip ChooseNewClip()
    {
        if (alreadyUsed.Count == 0)
        {
            alreadyUsed = clips.OrderBy(x => Random.value).ToList(); 
        }
        AudioClip clip = alreadyUsed[0];
        alreadyUsed.RemoveAt(0); 
        return clip;
    }
    private IEnumerator PlaySimple(AudioSource source, AudioClip clip)
    {

        source.clip = clip;
        source.Play();
        var waitForClipRemainingTime = new WaitForSeconds(clip.length);
        yield return waitForClipRemainingTime;


    }



}
