using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip coin_sound;
    public AudioClip joint_sound;
    private AudioSource Source;

    private void Start()
    {
        Source = Camera.main.GetComponent<AudioSource>();
    }
    
   public void PlayAudio()
   {
        Source.PlayOneShot(coin_sound, 0.7f);
        Debug.Log("Sound Play");
   }

   public void JointAudio()
   {
       Source.PlayOneShot(joint_sound, 0.7f);

   } 
}
