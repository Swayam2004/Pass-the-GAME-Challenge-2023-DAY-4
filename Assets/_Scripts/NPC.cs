using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    //Group of People that need to get to a destination

    public GameObject speech;
    public Vector3 destination;
    public float reward;

    public bool isDummy;

    public NPCManager nm;

    private GameObject currText;

    private GameObject player;

    private bool fastText;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {


        if (isDummy)
            return;


        if (Vector3.Distance(this.transform.position, player.transform.position) < 2)
        {

            if (player.GetComponent<MovementController>().GetCurrentSpeedNormalized() <= 0.1f)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    nm.AddToPassenger(this);

                    if (currText != null)
                        Destroy(currText);

                    Destroy(this.gameObject);
                }



                if (currText != null)
                {

                    return;

                }

                currText = Instantiate(speech, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

                string texti = "Hey, please take us with you! Press [E]";

                currText.GetComponent<Speech>().sentences.Add(texti);

                currText.GetComponent<Speech>().Activate();

            }
            else
            {


                if (Input.GetKeyDown(KeyCode.E))
                {

                    Destroy(currText);


                    currText = Instantiate(speech, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

                    string texti = "SLOW DOWN WTF?????????";

                    currText.GetComponent<Speech>().sentences.Add(texti);

                    currText.GetComponent<Speech>().Activate();
                }
                else
                {

                    if (currText != null)
                    {

                        return;

                    }

                    currText = Instantiate(speech, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

                    string texti = "Hey, please take us with you! Press [E]";

                    currText.GetComponent<Speech>().sentences.Add(texti);

                    currText.GetComponent<Speech>().Activate();

                }

            }


        }
        else
        {

            if (currText != null)
            {

                Destroy(currText);

            }

        }


    }


}
