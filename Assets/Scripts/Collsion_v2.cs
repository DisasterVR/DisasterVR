using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collsion_v2 : MonoBehaviour
{
    private bool hasCollided = false;
    private GameObject childObject;

    public Material active_NotSecure;
    public Material active_Secure; 
    public Material inactive;

    public bool secure;

    void Start()
    {
        childObject = transform.GetChild(0).gameObject;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !hasCollided)
        {
            if (secure == true)
            {
                ApplyMaterial(childObject, active_Secure);
            }
            else
            {
                ApplyMaterial(childObject, active_NotSecure);
            }
            hasCollided = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && hasCollided)
        {
            ApplyMaterial(childObject, inactive);
            hasCollided = false;
        }
    }

    private void ApplyMaterial(GameObject obj, Material material)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();
        if (objRenderer != null)
        {
            objRenderer.material = material;
        }
    }
}
