using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayNote : MonoBehaviour
{
    public AudioSource[] stringSource = new AudioSource[6];//A source for each string
    /// <summary>
    /// Set the note of the selected string
    /// </summary>
    public void SetNote(int stringNumber,float frequency)
    {
        stringSource[stringNumber].pitch = frequency;
    }  

    /// <summary>
    /// Strum the guitar.Delays are because not all clips start simultaneously
    /// </summary>
    public void Strum(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            stringSource[0].PlayDelayed(0f);   //High E
            stringSource[1].PlayDelayed(.14f); //B
            stringSource[2].PlayDelayed(.1f);  //G
            stringSource[3].PlayDelayed(.12f); //D
            stringSource[4].PlayDelayed(.2f);  //A
            stringSource[5].PlayDelayed(0f);   //Low E
        }
    }

    public void PlaySingleString(int stringNum)
    {
        stringSource[stringNum].Play();
    }
}
