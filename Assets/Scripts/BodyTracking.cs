using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive updReceive;
    public GameObject[] body;
    private List<string> _lines;
    private short cont = 0;
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
        
        if (cont <= 3)
        {
            for (int i = 0; i < 33; i++)
            {
                float x = float.Parse(points[i * 3]) / 95;
                float y = float.Parse(points[i * 3 + 1]) / 100;
                float z = float.Parse(points[i * 3 + 2]) / 650;
                body[i].transform.localPosition = new Vector3(x, y, z);
            }
            cont++;
        }
        else
        {
            for (int i = 0; i < 33; i++)
            {
                float x = float.Parse(points[i * 3]) / 500;
                float y = float.Parse(points[i * 3 + 1]) / 400;
                float z = float.Parse(points[i * 3 + 2]) / 800;
                body[i].transform.localPosition = new Vector3(body[i].transform.localPosition.x + x, body[i].transform.localPosition.y + y, body[i].transform.localPosition.z + z);
            }
        }
    }
}
