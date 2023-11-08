using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public Intermediary udpReceive;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;
        //data = data.Remove(0, 1);
        //data = data.Remove(data.Length-1, 1);

        //string[] info = data.Split(',');

        int position = 12;


        string[] srtListPartBody = data.Split("], [");
        
        string srtPartBodySeleted = srtListPartBody[position];

        if (position == 0)
        {
            srtPartBodySeleted = srtPartBodySeleted.Replace("[", "");
        }
        else if (position == 32)
        {
            srtPartBodySeleted = srtPartBodySeleted.Replace("]", "");
        }

        string[] xyxFrom12 = srtPartBodySeleted.Split(",");
        


        int x = int.Parse(xyxFrom12[1]) / 1000;
        int y = int.Parse(xyxFrom12[2]) / 1000;
        float z = float.Parse(xyxFrom12[3])*10;

        // (130, 150 , 555)

        //  [[31, -250, 1880, -0.20107083022594452], [32, -250, 1880, -0.20107083022594452], ...]
        gameObject.transform.localPosition = new Vector3(-x, -y, z);
    }
}
