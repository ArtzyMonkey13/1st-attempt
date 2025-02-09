using UnityEngine;

public class LiftRepel : MonoBehaviour
{
   public Transform player;      // Reference to the player object
    public float repelStrength = 10f; // Strength of the repelling force
    public float liftHeight = 2f;   // Height at which the capsule stays above the player when held
    private bool isLifted = false;  // Flag to check if "L" key is pressed

    private Vector3 initialOffset;  // The initial offset between the capsule and the player

    void Start()
    {
        // Initial offset between the capsule and the player
        initialOffset = transform.position - player.position;
    }

    void Update()
    {
        // Handle the repelling effect when "L" key is not pressed
        if (!isLifted)
        {
            RepelPlayer();
        }

        // Lift the capsule if "L" key is pressed
        if (Input.GetKeyDown(KeyCode.L))
        {
            isLifted = true;
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            isLifted = false;
        }

        // Keep the capsule on top of the player if it's lifted
        if (isLifted)
        {
            LiftCapsule();
        }
    }

    void RepelPlayer()
    {
        // Calculate the direction vector between the capsule and the player
        Vector3 direction = transform.position - player.position;

        // Apply a repelling force to move the capsule away from the player
        Vector3 repelForce = direction.normalized * repelStrength * Time.deltaTime;
        transform.position += repelForce;

        // Ensure the player is not being affected by the capsule's movement
        // Optionally, add checks to stop the player from moving unexpectedly (e.g., freeze movement)
    }

    void LiftCapsule()
    {
        // Keep the capsule positioned above the player
        Vector3 targetPosition = player.position + new Vector3(0, liftHeight, 0);
        transform.position = targetPosition;
    }
}
