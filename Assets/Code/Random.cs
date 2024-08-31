using UnityEngine;

public class Random : MonoBehaviour
{
    void Start()
    {
        // Generate a random rotation angle between 0 and 360 degrees
        float randomZRotation = UnityEngine.Random.Range(0f, 360f);

        // Apply the random rotation to the object on the Z axis
        transform.rotation = Quaternion.Euler(0f, 0f, randomZRotation);
    }
}
