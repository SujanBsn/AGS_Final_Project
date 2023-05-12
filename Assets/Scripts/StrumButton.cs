using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StrumButton : MonoBehaviour
{
    PlayNote playNote;
    public void OnStrum()
    {
        playNote = GetComponent<PlayNote>();
        playNote.strum();
    }

}
