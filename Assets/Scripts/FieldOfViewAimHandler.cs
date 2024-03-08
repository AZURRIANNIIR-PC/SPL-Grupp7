using UnityEngine;

public class FieldOfViewAimHandler : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private Transform enemyTransform; // The transform of the enemy controlling the aim

    // Update is called once per frame
    void Update()
    {
        if (enemyTransform != null)
        {
            // Get the aim direction from the enemy's position to a target position (e.g., the player)
           // Vector3 aimDirection = /* Calculate the aim direction here */

            // Set the aim direction in the FieldOfView component
            //fieldOfView.setAimDirection(aimDirection);
        }
    }
}

