using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timmer : MonoBehaviour
{
    float timer1 = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer1 -= Time.deltaTime;
        if(timer1 < 0 )
        {
            SceneManager.LoadScene("Score");
        }
    }
}
