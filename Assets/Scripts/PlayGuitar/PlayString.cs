using UnityEngine;
using UnityEngine.InputSystem;

public class PlayString : MonoBehaviour
{
    PlayNote PlayNote;

    private void Start()
    {
        PlayNote = GameObject.Find("BaseSource").GetComponent<PlayNote>();
    }

    /// <summary>
    /// Play selected string
    /// </summary>
    public void SingleStringPlay(int stringNum)
    {
        PlayNote.PlaySingleString(stringNum);
    }

    /// <summary>
    /// Play string1
    /// </summary>
    public void String1Play(InputAction.CallbackContext context)
    {
        if (context.started)
            SingleStringPlay(0);
    }

    /// <summary>
    /// Play string2
    /// </summary>
    public void String2Play(InputAction.CallbackContext context)
    {
        if(context.started)
            SingleStringPlay(1);
    }

    /// <summary>
    /// Play string3
    /// </summary>
    public void String3Play(InputAction.CallbackContext context)
    {
        if (context.started)
            SingleStringPlay(2);
    }

    /// <summary>
    /// Play string4 
    /// </summary>
    public void String4Play(InputAction.CallbackContext context)
    {
        if (context.started)
            SingleStringPlay(3);
    }

    /// <summary>
    /// Mute/Unmute string5
    /// </summary>
    public void String5play(InputAction.CallbackContext context)
    {
        if (context.started)
            SingleStringPlay(4);
    }

    /// <summary>
    /// Play string6
    /// </summary>
    public void String6Play(InputAction.CallbackContext context)
    {
        if (context.started)
            SingleStringPlay(5);
    }
}
