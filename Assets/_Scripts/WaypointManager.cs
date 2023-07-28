using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    // Please add a Waypoint system if you know how to do it



    /* public Transform player; // Reference to the player or the object that needs to navigate between waypoints.

    private Waypoint[] waypoints;

    private void Start()
    {
        waypoints = FindObjectsOfType<Waypoint>();
    }

    private void Update()
    {
        foreach (Waypoint waypoint in waypoints)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(waypoint.transform.position);
            Vector3 directionToWaypoint = waypoint.transform.position - player.position;

            if (screenPos.z > 0 && directionToWaypoint.z > 0)
            {
                if (Vector3.Distance(player.position, waypoint.transform.position) <= waypoint.waypointReachedDistance)
                {
                    // Handle waypoint reached logic here (e.g., update to the next waypoint).
                    waypoint.gameObject.SetActive(false);
                }
                else
                {
                    // Waypoint is on the screen; display it normally.
                    waypoint.gameObject.SetActive(true);
                }
            }
            else
            {
                // Waypoint is not on the screen; project it to the edge of the screen.
                Vector3 screenCenter = new Vector3(Screen.width, Screen.height, 0) / 2f;
                Vector3 screenBounds = screenCenter * 0.9f;

                Vector3 projectedPos = screenPos - screenCenter;
                projectedPos = Vector3.ClampMagnitude(projectedPos, screenBounds.magnitude);
                projectedPos = projectedPos + screenCenter;

                // Convert the screen position back to world space.
                waypoint.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(projectedPos.x, projectedPos.y, screenPos.z));

                waypoint.gameObject.SetActive(true);
            }
        }
    } */
}
