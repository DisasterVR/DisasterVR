using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTracking2 : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive1 updReceive;
    public GameObject[] body;
    private List<string> _lines;
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

        for (int i = 0; i < 33; i++)
        {
            float x = float.Parse(points[i * 3]) / 210;
            //float y = float.Parse(points[i * 3 + 1]) / 110;
            //float z = float.Parse(points[i * 3 + 2]) / 50;
            body[i].transform.localPosition = new Vector3(body[i].transform.localPosition.x, body[i].transform.localPosition.y, x);
        }
    }
}
