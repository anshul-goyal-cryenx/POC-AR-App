using UnityEngine;

public class ChangeMaterialOnceOnClick : MonoBehaviour
{
    public Material newMaterial; // Drag your new material here
    private bool hasChangedMaterial = false;

    void Update()
    {
        if (!hasChangedMaterial && Input.GetMouseButtonDown(0))
        {
            ChangeMaterial();
        }
    }

    void ChangeMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = newMaterial;
            hasChangedMaterial = true;
        }
        else
        {
            Debug.LogError("Renderer component not found on the object.");
        }
    }
}
