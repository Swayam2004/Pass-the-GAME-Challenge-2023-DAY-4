using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoliceSpawn : MonoBehaviour
{
    public Transform policeStationPos;
    public GameObject policeCar;

    public GameObject CornerList;
    public Transform[] streetCorners;

    public List<GameObject> cops;

    public Transform player;
    public float copSpawnTime;
    public float copBlockadeTime;

    public float optimalVectorLength;

    public float MaxSpawnDistance;
    public void Start()
    {
        LoadCorners();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnCycle());
       
    }
    void LoadCorners()
    {
        streetCorners = CornerList.GetComponentsInChildren<Transform>();
    }
    public IEnumerator SpawnCycle()
    {
        while (true)
        {
            SpawnCop();
            yield return new WaitForSeconds(copSpawnTime);
        }

    }
    public IEnumerator StreetBlockadeCycle()
    {
        while (true)
        {
            StartStreetBlockade();
            yield return new WaitForSeconds(copBlockadeTime);
        }
    }
    public void SpawnCop()
    {
        Debug.Log("ACAB");
        GameObject instance = Instantiate(policeCar, FindCornerInMinDistance());
        cops.Add(instance);

    }
    public void StartStreetBlockade()
    {
        Vector3 scanPoint = player.forward * optimalVectorLength;
        Vector3 nearestCorner = streetCorners.OrderBy(e => (scanPoint - e.transform.position).magnitude).ToList()[0].position;

        GameObject[] copsOrderdByDistance = cops.OrderBy(e => (nearestCorner - e.transform.position).magnitude).ToArray();

        GameObject copLocation = Instantiate(new GameObject(), nearestCorner, Quaternion.identity);
        Destroy(copLocation, 10f);

        copsOrderdByDistance[0].GetComponent<PoliceAi>().DriveToCorner(copLocation.transform);
        copsOrderdByDistance[1].GetComponent<PoliceAi>().DriveToCorner(copLocation.transform);
    }
    public Transform FindCornerInMinDistance()
    {
        float biggestDistance = 0;
        Transform selectedCorner = streetCorners[0];
        for (int i = 0; i < streetCorners.Count(); i++)
        {
            float distance = Vector2.Distance(streetCorners[i].position, player.position);
            if (i == 0)
            {
                biggestDistance = distance;
                selectedCorner = streetCorners[i];
                continue;
            }

            if(distance > biggestDistance && distance <= MaxSpawnDistance)
            {
                biggestDistance = distance;
                selectedCorner = streetCorners[i];

            }
            if(distance > biggestDistance && distance > MaxSpawnDistance)
            {
                continue;
            } 

        }
        return selectedCorner;

    }


}
