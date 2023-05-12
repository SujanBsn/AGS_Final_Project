using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNote : MonoBehaviour
{
    public AudioSource[] BaseSource =new AudioSource[6];
    
    void SetNote(int stringNum,float frequency)
    {
        BaseSource[stringNum].GetComponent<AudioSource>().pitch = frequency;
    }

    public void strum()
    {
        for(int i = 0; i<6; i++)
        {
            BaseSource[5].Play();
        }
    }
}
