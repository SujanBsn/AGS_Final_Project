using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MuteString : MonoBehaviour
{
    PlayNote PlayNote;

    int[] setMute = new int[6];
    public GameObject[] stringObj = new GameObject[6];
    public GameObject[] stringMuteObj = new GameObject[6];

    private void Start()
    {
        for (int i = 0; i <= 5; i++)
        {
            setMute[i] = 0;
        }

        PlayNote = GameObject.Find("BaseSource").GetComponent<PlayNote>();
    }

    /// <summary>
    /// Mute/Unmute string1
    /// </summary>
    public void String1Mute(InputAction.CallbackContext context)
    {
        setMute[0]++;
        if (setMute[0] == 0)
        {
            stringObj[0].SetActive(false);
            stringMuteObj[0].SetActive(true);
            setMute[0]++;
        }
        else if (setMute[0] >= 1)
        {
            setMute[0] = 0;
            stringObj[0].SetActive(true);
            stringMuteObj[0].SetActive(false);

        }
    }

    /// <summary>
    /// Mute/Unmute string2
    /// </summary>
    public void String2Mute(InputAction.CallbackContext context)
    {
        if (setMute[1] == 0)
        {
            stringObj[1].SetActive(false);
            stringMuteObj[1].SetActive(true);
            setMute[1]++;
           
        }
        else if (setMute[1] >= 1)
        {
            setMute[1] = 0;
            stringObj[1].SetActive(true);
            stringMuteObj[1].SetActive(false);
        }
    }

    /// <summary>
    /// Mute/Unmute string3
    /// </summary>
    public void String3Mute(InputAction.CallbackContext context)
    {
        if (setMute[2] == 0)
        {
            stringObj[2].SetActive(false);
            stringMuteObj[2].SetActive(true);
            setMute[2]++;               
        }
        else if (setMute[2] >= 1)
        {
            setMute[2] = 0;
            stringObj[2].SetActive(true);
            stringMuteObj[2].SetActive(false);
        }
    }

    /// <summary>
    /// Mute/Unmute string4 
    /// </summary>
    public void String4Mute(InputAction.CallbackContext context)
    {
        if (setMute[3] == 0)
        {
            stringObj[3].SetActive(false);
            stringMuteObj[3].SetActive(true);
            setMute[3]++;
        }
        else if (setMute[3] >= 1)
        {
            setMute[3] = 0;
            stringObj[3].SetActive(true);
            stringMuteObj[3].SetActive(false);
        }
    }

    /// <summary>
    /// Mute/Unmute string5
    /// </summary>
    public void String5Mute(InputAction.CallbackContext context)
    {
        if (setMute[4] == 0)
        {
            stringObj[4].SetActive(false);
            stringMuteObj[4].SetActive(true);
            setMute[4]++;
        }
        else if (setMute[4] >= 1)
        {
            setMute[4] = 0;
            stringObj[4].SetActive(true);
            stringMuteObj[4].SetActive(false);
        }
    }

    /// <summary>
    /// Mute/Unmute string6
    /// </summary>
    public void String6Mute(InputAction.CallbackContext context)
    {
        if (setMute[5] == 0)
        {
            stringObj[5].SetActive(false);
            stringMuteObj[5].SetActive(true);
            setMute[5]++;
            PlayNote.stringSource[5].volume = 0;
        }
        else if (setMute[5] >= 1)
        {
            setMute[5] = 0;
            stringObj[5].SetActive(true);
            stringMuteObj[5].SetActive(false);
            PlayNote.stringSource[5].volume = 1;
        }
    }
}
