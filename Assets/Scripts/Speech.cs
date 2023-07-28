using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speech : MonoBehaviour
{
    public List<string> sentences;
    private TextMeshPro text;

    private int currSentence;
    private Camera mainCam;

    private void Start()
    {

        mainCam = Camera.main;

    }

    public void Activate()
    {
        text = transform.GetChild(0).GetComponent<TextMeshPro>();
        text.text = "";
        currSentence = 0;

        NextSentence();
    }

    private void Update()
    {
        
        this.transform.LookAt(mainCam.transform.position);

    }

    void NextSentence()
    {
        if (currSentence > sentences.Count)
            return;

        string sentence = sentences[currSentence];

        StartCoroutine(Write(sentence));
    }

    IEnumerator Write(string s)
    {

        text.text = "";

        foreach(char a in s)
        {

            float textSpeed = 0.1f;

            if (a.ToString() == ".")
                textSpeed = 0.5f;

            text.text += a;

            yield return new WaitForSeconds(textSpeed);

        }

        yield return new WaitForSeconds(3f);

        currSentence++;

        NextSentence();

    }



}
