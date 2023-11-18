using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class ROOM : MonoBehaviour
{
    public GameObject Wall;

    private float x_old = 0;
    private float y_old = 0;
    private float z_old = 0;
    private float x_new = 0;
    private float y_new = 0;
    private float z_new = 0;

    private short cont = 0;
    
    private Rigidbody rigidbody;
    private float time = 0;

    public short flag;

    public short kinematicEndTime1;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //rigidbody.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        time = Timmer.timer1;

        if (time >= 20 && time <= 60)
        {
            float diference_x = x_new - x_old;
            float diference_y = y_new - y_old;
            float diference_z = z_new - z_old;

            x_old = x_new;
            y_old = y_new;
            z_old = z_new;
        
            x_new = Wall.transform.position.x;
            y_new = Wall.transform.position.y;
            z_new = Wall.transform.position.z;
            
            if (time >= kinematicEndTime1 && time <= kinematicEndTime1+1)
            {
                rigidbody.isKinematic = false;
            }

            if (cont > 1)
            {
                transform.position = new Vector3(transform.position.x + diference_x, transform.position.y + diference_y,
                    transform.position.z + diference_z);
            }

            if (time >= kinematicEndTime1 && time <= kinematicEndTime1+1 && flag == 2)
            {
                DesactivarRestriccionesDePosicion();
                DesactivarRestriccionesDeRotacion();
            }

            cont++;
        }
        

    }
    
    void DesactivarRestriccionesDePosicion()
    {
        // Obtener las restricciones actuales
        RigidbodyConstraints constraints = rigidbody.constraints;

        // Desactivar restricciones de posición
        constraints &= ~RigidbodyConstraints.FreezePositionX;
        constraints &= ~RigidbodyConstraints.FreezePositionY;
        constraints &= ~RigidbodyConstraints.FreezePositionZ;

        // Aplicar las nuevas restricciones al Rigidbody
        rigidbody.constraints = constraints;
    }

    void DesactivarRestriccionesDeRotacion()
    {
        // Obtener las restricciones actuales
        RigidbodyConstraints constraints = rigidbody.constraints;

        // Desactivar restricciones de rotación
        constraints &= ~RigidbodyConstraints.FreezeRotationX;
        constraints &= ~RigidbodyConstraints.FreezeRotationY;
        constraints &= ~RigidbodyConstraints.FreezeRotationZ;

        // Aplicar las nuevas restricciones al Rigidbody
        rigidbody.constraints = constraints;
    }
}
