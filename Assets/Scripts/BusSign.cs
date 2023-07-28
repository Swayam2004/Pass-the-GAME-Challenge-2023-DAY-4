using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusSign : MonoBehaviour
{

    private GameObject player;
    NPCManager npcManager;
    public GameObject npc;

    bool used;

    private void Start()
    {
        npcManager = FindObjectOfType<NPCManager>();
        player = GameObject.FindGameObjectWithTag("Player");

        used = false;
    }

    private void Update()
    {
        if (used)
            return;

        if(Vector3.Distance(this.transform.position, player.transform.position) < 2)
        {

            if (player.GetComponent<MovementController>().GetCurrentSpeed01() <= 0.1f)
            {
                used = true;
                StartCoroutine(Endstation());
            }
            
        }
    }

    IEnumerator Endstation()
    {

        npc = Instantiate(FindObjectOfType<NPCManager>().prefabNPC, this.transform.position, Quaternion.identity);
        npc.GetComponent<NPC>().isDummy = true;

        //Give Player Money, Remove Things
        npcManager.RemovePassenger(this.transform.position);
        

        yield return new WaitForSeconds(1f);

        Destroy(npc);
        Destroy(this.gameObject);


    }

}
