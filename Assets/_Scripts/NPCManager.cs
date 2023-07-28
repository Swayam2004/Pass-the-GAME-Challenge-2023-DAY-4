using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    public GameObject[] spawnLocations;
    public GameObject[] destinationLocations;

    public GameObject prefabNPC;
    public GameObject prefabBusSign;
    public GameObject speech;

    public TextMeshProUGUI personCountText;


    //NPCs the bus is taking right now
    private List<NPC> currentNPC;

    //NPCs that are available to pick up
    private List<NPC> availableNPC;

    private Dictionary<Vector3, float> currDestinations;

    public GameObject Arrow;


    public int maxNPC;
    public int timerNPC;
    public int maxPassengers;

    [Range(0f, 30f)]
    public int timerVariation;

    private float currentTime;


    void Start()
    {

        currentTime = timerNPC;

        currentNPC = new List<NPC>();
        availableNPC = new List<NPC>();
        currDestinations = new Dictionary<Vector3, float>();

        personCountText.text = "x0";
    }


    void Update()
    {
        UpdateArrow();
        currentTime -= 5 * Time.deltaTime;

        if (currentTime <= 0 && availableNPC.Count < maxNPC)
        {
            //SPAWN NEW NPC hihihihihhihihihi :D

            GameObject newNPC = Instantiate(prefabNPC, GetRandomSpawnLocation());

            newNPC.GetComponent<NPC>().reward = 400;

            newNPC.GetComponent<NPC>().destination = GetRandomDestinationLocation();

            newNPC.GetComponent<NPC>().nm = this;

            newNPC.GetComponent<NPC>().speech = speech;

            availableNPC.Add(newNPC.GetComponent<NPC>());

            currentTime = timerNPC + Random.Range(-timerVariation, timerVariation);

        }

    }

    public void AddToPassenger(NPC n)
    {

        if (currentNPC.Count > maxPassengers)
            return;

        //BUS STOP SIGN INSTANTIATE

        

        currentNPC.Add(n);

        Vector3 loc = GetFreeDestination();

        Instantiate(prefabBusSign, loc, Quaternion.identity);

        currDestinations.Add(loc, n.reward);

        UpdateArrow();

        personCountText.text = "x" + currentNPC.Count;

    }

    Transform GetRandomSpawnLocation()
    {

        int randomIndex = Random.Range(0, spawnLocations.Length);

        return spawnLocations[randomIndex].transform;

    }

    Vector3 GetRandomDestinationLocation()
    {

        int randomIndex = Random.Range(0, destinationLocations.Length);

        return destinationLocations[randomIndex].transform.position;

    }

    Vector3 GetFreeDestination()
    {

        Vector3 loc = GetRandomDestinationLocation();

        if (currDestinations.ContainsKey(loc))
            loc = GetFreeDestination();

        return loc;

    }

    public void UpdateArrow()
    {
        Vector3 closestrDestinationWithPassengers = FindClosestDestinationWithPassengers();
        if(closestrDestinationWithPassengers == Vector3.zero)
        {
            Arrow.SetActive(false);
        }
        else
        {
            Arrow.SetActive(true);
        }
        Arrow.transform.LookAt(closestrDestinationWithPassengers);
    }
    public Vector3 FindClosestDestinationWithPassengers()
    {
        if (currDestinations.Count <= 0)
            return Vector3.zero;

        List<Vector3> keyList = new List<Vector3>(this.currDestinations.Keys);

        return keyList[0];

    }
    public void RemovePassenger(Vector3 pos)
    {
        if (currDestinations.ContainsKey(pos))
        {
            int money = ((int)currDestinations[pos]);

            currentNPC.Remove(currentNPC[0]);

            GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game>().AddScore(money);

            currDestinations.Remove(pos);

            personCountText.text = "x" + currentNPC.Count;
        }
    }
}
