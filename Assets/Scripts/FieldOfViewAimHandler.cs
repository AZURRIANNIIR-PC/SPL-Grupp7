using UnityEngine;

public class FieldOfViewAimHandler : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private float amplitude = 1f; // Amplitude of the vertical movement
    [SerializeField] private float frequency = 1f; // Frequency of the vertical movement
    private float timeElapsed;
    [SerializeField] private float rotationAmplitude = 15f; // Amplitude of the rotation
    [SerializeField] private float rotationSpeed = 1f; // Speed of the rotation

    private void Update()
    {
        // Calculate vertical movement based on sine function
        float yOffset = Mathf.Sin(timeElapsed * frequency) * amplitude;

        // Set the field of view's origin to the enemy's position with the vertical offset applied
        Vector3 originWithOffset = transform.position + new Vector3(0f, yOffset, 0f);
        fieldOfView.SetOrigin(originWithOffset);

        // Increment time elapsed
        //timeElapsed += Time.deltaTime;
        // Calculate the rotation angle based on sine function
        float rotationAngle = Mathf.Sin(Time.time * rotationSpeed) * rotationAmplitude;

        // Set the rotation angle in the FieldOfView component
        fieldOfView.setRotationAngle(rotationAngle);
    }
}



