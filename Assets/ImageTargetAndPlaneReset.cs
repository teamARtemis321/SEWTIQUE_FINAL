using UnityEngine;

public class ImageTargetAndPlaneReset : MonoBehaviour
{
    public GameObject imageTarget; // Assign your ImageTarget GameObject here
    public GameObject planeObject; // Assign your Plane GameObject here

    private Vector3 initialImageTargetPosition;
    private Quaternion initialImageTargetRotation;
    private Vector3 initialPlanePosition;
    private Quaternion initialPlaneRotation;

    void Start()
    {
        // Store initial positions and rotations
        initialImageTargetPosition = imageTarget.transform.position;
        initialImageTargetRotation = imageTarget.transform.rotation;
        initialPlanePosition = planeObject.transform.position;
        initialPlaneRotation = planeObject.transform.rotation;
    }

    // Function to be called when the button is clicked
    public void ResetToInitialStates()
    {
        // Reset ImageTarget position and rotation
        imageTarget.transform.position = initialImageTargetPosition;
        imageTarget.transform.rotation = initialImageTargetRotation;

        // Reset Plane position and rotation
        planeObject.transform.position = initialPlanePosition;
        planeObject.transform.rotation = initialPlaneRotation;

        // Optional: Clear all children of the Plane
        foreach (Transform child in planeObject.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
