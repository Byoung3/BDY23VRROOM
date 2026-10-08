using System.Collections;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    private Light targetLight;

    [Header("Flicker Settings")]
    [Tooltip("Minimum time the light stays in its current state.")]
    public float minDelay = 0.05f;
    [Tooltip("Maximum time the light stays in its current state.")]
    public float maxDelay = 0.2f;

    void Start()
    {
        // Get the light component attached to this GameObject
        targetLight = GetComponent<Light>();

        // Start the flickering loop
        StartCoroutine(FlickerRoutine());
    }

    IEnumerator FlickerRoutine()
    {
        while (true)
        {
            // Toggle the light component on/off
            targetLight.enabled = !targetLight.enabled;

            // Wait for a random amount of time before toggling again
            float randomTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(randomTime);
        }
    }
}
