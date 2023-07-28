using UnityEngine;

public class WindZone : MonoBehaviour
{
    MovementController player;

    public Transform direction;
    public float maxForce = 5f;
    public float minForce = 1f;

    public float maxDistance = 10f;

    private bool _canPlaySound;

    private void FixedUpdate()
    {
        if (player)
        {
            player.AddExternalForce(direction.forward * Mathf.Lerp(maxForce, minForce, Mathf.Clamp01(Vector3.Distance(transform.position, player.transform.position) / maxDistance)));

            if (_canPlaySound)
            {
                SoundManager.Instance.PlayStormWhooshSound(transform.position, 2f);
                _canPlaySound = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        MovementController mc = other.GetComponent<MovementController>();
        if (mc)
        {
            player = mc;
            _canPlaySound = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        MovementController mc = other.GetComponent<MovementController>();
        if (mc)
        {
            player = null;
            _canPlaySound = false;
        }
    }
}
