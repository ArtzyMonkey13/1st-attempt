using UnityEngine;

public class BounceOffPlayer : MonoBehaviour
{
    public float bounceForce = 10f; // The force applied to the object when it bounces off
    public float rollDuration = 1f; // How long the object rolls after bouncing

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the object
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object colliding with this object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Calculate the direction away from the player
            Vector3 direction = (transform.position - other.transform.position).normalized;

            // Apply a force to the object to make it bounce away from the player
            rb.AddForce(direction * bounceForce, ForceMode.Impulse);

            // Optionally, add a rolling effect after the bounce (using AddTorque)
            rb.AddTorque(Random.insideUnitSphere * rollDuration, ForceMode.Impulse);

            // Print to console for debugging
            Debug.Log("Bounced off the player!");
        }
    }
}
