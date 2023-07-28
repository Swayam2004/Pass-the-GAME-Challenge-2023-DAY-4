using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public ParticleSystem lowHealthParticle;
    public float lowHealthThreshold = 30f;

    public Slider healthBar;

    public float flipForce = 1000f;

    private Rigidbody rb;
    private bool isFlipped = false;

    private MovementController movementController;

    public BustedScreen deathPanel;
    public Vector3 targetPanelPosition;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        movementController = GetComponent<MovementController>();
    }

    void Update()
    {
        if (currentHealth <= 0f && !isFlipped)
        {
            FlipObject();
        }
        else if (currentHealth <= lowHealthThreshold)
        {
            PlayLowHealthParticle();
        }
        else
        {
            lowHealthParticle.Stop();
        }
    }

    public void ModifyHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        healthBar.value = currentHealth / maxHealth;
    }

    private void PlayLowHealthParticle()
    {
        if (lowHealthParticle != null && !lowHealthParticle.isPlaying)
        {
            lowHealthParticle.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Police"))
        {
            ModifyHealth(-10f);
        }
    }

    private void FlipObject()
    {
        isFlipped = true;

        Quaternion targetRotation = Quaternion.Euler(180f, transform.rotation.eulerAngles.y, 0f);

        float flipDuration = 1.0f; 
        StartCoroutine(RotateObjectSmoothly(targetRotation, flipDuration));

        if (movementController != null)
        {
            movementController.enabled = false;
        }

        if (deathPanel != null)
        {
            deathPanel.targetPosition = targetPanelPosition;
            deathPanel.gameObject.SendMessage("SlideOnScreenSmoothly");
        }

    }

    private IEnumerator RotateObjectSmoothly(Quaternion targetRotation, float duration)
    {
        Quaternion initialRotation = transform.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
