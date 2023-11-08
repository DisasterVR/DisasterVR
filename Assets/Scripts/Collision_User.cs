using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_User : MonoBehaviour
{
    public GameObject Secure_Site;
    private GameObject instantiatedSecureSite;
    private bool hasCollided = false;

    public Material material1; // Primer material
    public Material material2; // Segundo material

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && !hasCollided)
        {
            instantiatedSecureSite = Instantiate(Secure_Site);
            ApplyMaterial(instantiatedSecureSite, material1);
            hasCollided = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player") && hasCollided)
        {
            ApplyMaterial(instantiatedSecureSite, material2);
            Destroy(instantiatedSecureSite); // Destruir el objeto instanciado al salir del colisionador
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



