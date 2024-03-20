//Adin Farid, adfa8505
//Linn Li, lili6794
//Nora Wennerberg, nowe9092

using UnityEngine;

public class FieldOfViewAimHandler : MonoBehaviour
{
    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private float amplitude = 1f; // Amplitude of the vertical movement
    [SerializeField] private float frequency = 1f; // Frequency of the vertical movement
    private float timeElapsed;
    [SerializeField] private float rotationAmplitude = 15f; // Amplitude of the rotation
    [SerializeField] private float rotationSpeed = 1f; // Speed of the rotation

    private void Start()
    {
        // Move the field of view up vertically
        fieldOfView.transform.position += Vector3.up * fieldOfView.verticalOffset;
    }

    private void Update()
    {
        // Calculate vertical movement based on sine function
       float yOffset = Mathf.Sin(timeElapsed * frequency) * amplitude;


        // Set the field of view's origin to the enemy's position with the vertical offset applied
        Vector3 originWithOffset = transform.position + new Vector3(0f, yOffset, 4f);
        fieldOfView.SetOrigin(originWithOffset);

        // Increment time elapsed
        timeElapsed += Time.deltaTime;
        // Calculate the rotation angle based on sine function
        float rotationAngle = Mathf.Sin(Time.time * rotationSpeed) * rotationAmplitude;

        // Set the rotation angle in the FieldOfView component
        fieldOfView.SetRotationAngle(rotationAngle);
    }
}



