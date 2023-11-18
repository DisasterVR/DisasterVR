using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTracking1 : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive updReceive;
    //public UDPReceive1 updReceive1;
    public GameObject[] body;
    private List<string> _lines;
    public static bool isCollision;

    private float x_old = 0;
    private float y_old = 0;
    private float z_old = 0;

    private float x_new = 0;
    private float y_new = 0;
    private float z_new = 0;
    void Start()
    {
        x_old = transform.position.x;
        y_old = transform.position.y;
        z_old = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        string data = updReceive.data;
        print(data);
        data = data.Replace("[", "").Replace("]","");
        string[] points = data.Split(',');

        //UDP 1
        //string data1 = updReceive1.data;
        //print(data1);
        //data1 = data1.Replace("[", "").Replace("]", "");
        //string[] points1 = data1.Split(',');

        for (int i = 0; i < 33; i++)
        {
            float x = float.Parse(points[i * 3]) / 210; //110
            float y = float.Parse(points[i * 3 + 1]) / 110;
            float z = float.Parse(points[i * 3 + 2]) / 650;

            x_new = x;

            float differenceX = x_new - x_old;

            //UDP 1
            //float x1 = float.Parse(points1[i * 3]) / 110;
            //float y1 = float.Parse(points1[i * 3 + 1]) / 110;
            //float z1 = float.Parse(points1[i * 3 + 2]) / 650;
            body[i].transform.localPosition = new Vector3(x, 0, body[i].transform.localPosition.z);

            x_old = x_new;
        }
    }
}
