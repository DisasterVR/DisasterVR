using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Room_Animator : MonoBehaviour
{
    private Animator animator;
    private float time;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();
        
        animator.StopPlayback();
    }

    void Update()
    {
        time = Timmer.timer1;
        if (time >= 20 && time <= 60)
        {
            animator.enabled = true;
            audioSource.mute = false;
        }
        else
        {
            animator.enabled = false;
            audioSource.mute = true;
        }

    }
}
