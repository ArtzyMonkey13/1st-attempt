using UnityEngine;

public class RaycastScaleCycleChanger : MonoBehaviour
{
    public float scaleMultiplier = 3f; // Scale multiplier (3x size)
    public float raycastDistance = 5f; // Distance to cast the ray (adjust based on your scene)
    public string targetTag = "Player"; // Tag for the player (you can set this in the Inspector)
    
    private bool isInContact = false;
    private int cycleStage = 0; // Keeps track of the cycle (0 = Grow, 1 = Shrink, etc.)

    void Update()
    {
        // Cast a ray from the player forward
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward); // Starting point is player's position, and direction is forward
        
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Check if the raycast hit the player object
            if (hit.collider.CompareTag(targetTag))
            {
                // If the player has not interacted yet
                if (!isInContact)
                {
                    // Perform the appropriate action based on the cycle stage
                    HandleScaling();

                    // Set flag to indicate the player is in contact
                    isInContact = true;
                }
            }
        }
        else
        {
            // If the raycast doesn't hit the player, reset the contact state
            isInContact = false;
        }
    }

    // Handle the scaling logic based on the cycle stage
    void HandleScaling()
    {
        switch (cycleStage)
        {
            case 0: // First Growth (3x)
                transform.localScale *= scaleMultiplier;
                cycleStage = 1; // Next stage is Shrink
                Debug.Log("Object Grown: Scale = 3x");
                break;

            case 1: // Shrink (back to original size)
                transform.localScale = Vector3.one; // Reset to original size
                cycleStage = 2; // Next stage is Second Growth
                Debug.Log("Object Shrunk: Scale = 1x");
                break;

            case 2: // Second Growth (9x)
                transform.localScale *= scaleMultiplier * scaleMultiplier;
                cycleStage = 3; // Next stage is Shrink
                Debug.Log("Object Grown: Scale = 9x");
                break;

            case 3: // Shrink again (back to original size)
                transform.localScale = Vector3.one; // Reset to original size
                cycleStage = 4; // Next stage is Third Growth
                Debug.Log("Object Shrunk: Scale = 1x");
                break;

            case 4: // Third Growth (27x)
                transform.localScale *= scaleMultiplier * scaleMultiplier * scaleMultiplier;
                cycleStage = 5; // Next stage is Shrink
                Debug.Log("Object Grown: Scale = 27x");
                break;

            case 5: // Shrink again (back to original size)
                transform.localScale = Vector3.one; // Reset to original size
                cycleStage = 0; // Reset to Growth stage
                Debug.Log("Object Shrunk: Scale = 1x");
                break;
        }
    }
}
