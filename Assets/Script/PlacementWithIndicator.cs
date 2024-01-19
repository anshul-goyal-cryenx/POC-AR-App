using System.Collections;
using UnityEngine;

public class PlacementWithIndicator : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject placementObject;
    [SerializeField] private GameObject placementIndicatorPrefab;

    private GameObject placementIndicator;
    private bool objectInstantiated = false;

    void Start()
    {
        // Instantiate the placement indicator
        placementIndicator = Instantiate(placementIndicatorPrefab);
        placementIndicator.SetActive(false); // Initially hide the indicator
    }

    void Update()
    {
        // Update the position of the placement indicator based on the camera ray
        UpdatePlacementIndicator();

        // Check for mouse click
        if (Input.GetMouseButtonDown(0) && !objectInstantiated)
        {
            // Instantiate the object at the position of the placement indicator
            InstantiateObjectAtIndicator();
        }
    }

    void UpdatePlacementIndicator()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (placementIndicator != null) // Check if the object is not null
        {
            if (Physics.Raycast(ray, out hit))
            {
                // Show the placement indicator and update its position
                placementIndicator.SetActive(true);
                placementIndicator.transform.position = hit.point;
            }
            else
            {
                // Hide the placement indicator if the ray does not hit anything
                placementIndicator.SetActive(false);
            }
        }
    }

    void InstantiateObjectAtIndicator()
    {
        // Check if the placement indicator is active
        if (placementIndicator != null && placementIndicator.activeSelf)
        {
            // Instantiate the object at the position of the placement indicator
            Instantiate(placementObject, placementIndicator.transform.position, Quaternion.identity);

            // Set the flag to true to indicate that the object has been instantiated
            objectInstantiated = true;

            // Destroy the placement indicator
            Destroy(placementIndicator);
        }
    }
}
