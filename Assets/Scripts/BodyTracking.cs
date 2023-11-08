using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive updReceive;
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
            float x = float.Parse(points[i * 3]) / 100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 600;
            body[i].transform.localPosition = new Vector3(x, y, z);
        }
    }
}
