using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTest : MonoBehaviour
{
    public Transform other;
    public GameObject floor_true;

    void Update()
    {
        if (other)
        {
            Vector3 up = transform.TransformDirection(Vector3.up);
            Vector3 toOther = (other.position - transform.position).normalized;

            Debug.Log(Vector3.Dot(up, toOther));

            if (Vector3.Dot(up, toOther) <= -0.82 && Vector3.Dot(up, toOther) >= -0.98)
            {
                //Instantiate(floor_true);
            }
            //if (Vector3.Dot(up, toOther) < 0)
            //{
            //    Debug.Log("The other transform is behind me!");
            //}
        }
    }
}
