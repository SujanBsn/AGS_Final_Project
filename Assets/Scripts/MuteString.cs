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
    /// Mute selected string
    /// </summary>
    public void StringMute(int stringNum)
    {
        if (setMute[stringNum] == 0)
        {
            stringObj[stringNum].SetActive(false);
            stringMuteObj[stringNum].SetActive(true);
            setMute[stringNum]++;
            PlayNote.stringSource[stringNum].volume = 0;
        }
        else if (setMute[stringNum] >= 1)
        {
            setMute[stringNum] = 0;
            stringObj[stringNum].SetActive(true);
            stringMuteObj[stringNum].SetActive(false);
            PlayNote.stringSource[stringNum].volume = 1;
        }
    }

    /// <summary>
    /// Mute/Unmute string1
    /// </summary>
    public void String1Mute(InputAction.CallbackContext _)
    {
        StringMute(0);
    }

    /// <summary>
    /// Mute/Unmute string2
    /// </summary>
    public void String2Mute(InputAction.CallbackContext _)
    {
        StringMute(1);
    }

    /// <summary>
    /// Mute/Unmute string3
    /// </summary>
    public void String3Mute(InputAction.CallbackContext _)
    {
        StringMute(2);
    }

    /// <summary>
    /// Mute/Unmute string4 
    /// </summary>
    public void String4Mute(InputAction.CallbackContext _)
    {
        StringMute(3);
    }

    /// <summary>
    /// Mute/Unmute string5
    /// </summary>
    public void String5Mute(InputAction.CallbackContext _)
    {
        StringMute(4);
    }

    /// <summary>
    /// Mute/Unmute string6
    /// </summary>
    public void String6Mute(InputAction.CallbackContext _)
    {
        StringMute(5);
    }
}
