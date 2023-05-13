using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNote : MonoBehaviour
{
    StringController StringController;
    public AudioSource[] stringSource =new AudioSource[6];//A source for each string
    
    /// <summary>
    /// Set the note of the selected string
    /// </summary>
    public void SetNote(int stringNum,float frequency)
    {
        stringSource[stringNum - 1].pitch = frequency;
    }

    /// <summary>
    /// Strum the guitar.Delays are because not all clips start simultaneously
    /// </summary>
    public void Strum()
    {
        stringSource[0].PlayDelayed(0f);   //High E
        stringSource[1].PlayDelayed(.14f); //B
        stringSource[2].PlayDelayed(.1f);  //G
        stringSource[3].PlayDelayed(.12f); //D
        stringSource[4].PlayDelayed(.2f);  //A
        stringSource[5].PlayDelayed(0f);   //Low E
    }

    void Start()
    {    
        StringController = new StringController();
        StringController.Enable();
        StringController.SingleNote.StrumGuitar.started += _ => Strum();
    }
}
