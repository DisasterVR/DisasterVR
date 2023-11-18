using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CameraSteamVR : MonoBehaviour
{
    // Referencia al script Player
    private Player player;

    void Start()
    {
        // Ahora puedes acceder a los valores del hmdTransforms[i].
        Transform hmdTransform = player.hmdTransform;

        if (hmdTransform != null)
        {
            // Accede a los valores que necesitas, por ejemplo:
            Vector3 position = hmdTransform.position;
            Debug.Log("Posición del HMD: " + position);
        }
        else
        {
            Debug.Log("El hmdTransform es nulo.");
        }
    }
}
