using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public GameObject CameraTrucking;
    public float x_old = 0;
    public float y_old = 0;
    public float z_old = 0;
    private float x_new = 0;
    private float y_new = 0;
    private float z_new = 0;
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        float x = CameraTrucking.transform.position.x;
        float y = CameraTrucking.transform.position.y;
        float z = CameraTrucking.transform.position.z;
        x_old = resetOld(x_old, x);
        y_old = resetOld(y_old, y);
        z_old = resetOld(z_old, z);
        
        float x_rest = x - x_old;
        float y_rest = y - y_old;     
        float z_rest = z - z_old;

        if (x_rest >= 0.09)
        {
            x_new = x_new + 0.01f;
        }
        else
        {
            if (y_rest >= 0.09)
            {
                y_new = y_new + 0.01f;
            }
            else
            {
                if (z_rest >= 0.09)
                {
                    z_new = z_new + 0.01f;
                }
                else
                {
                    x_new = x_new+x_rest;
                    y_new = y_new+y_rest;
                    z_new = z_new+z_rest;
                }
            }
        }
        
        transform.position = new Vector3(x_new,y_new,z_new);
        x_old = x;
        y_old = y;
        z_old = z;
        
    }

    float resetOld(float oldPoint, float point)
    {
        return oldPoint == 0 ? point : oldPoint;
    }
}
