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
    void Start()
    {
        
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
            float x = float.Parse(points[i * 3]) / 110;
            float y = float.Parse(points[i * 3 + 1]) / 110;
            float z = float.Parse(points[i * 3 + 2]) / 650;

            //UDP 1
            //float x1 = float.Parse(points1[i * 3]) / 110;
            //float y1 = float.Parse(points1[i * 3 + 1]) / 110;
            //float z1 = float.Parse(points1[i * 3 + 2]) / 650;
            body[i].transform.localPosition = new Vector3(x, 0, body[i].transform.localPosition.z);
        }
    }
}
