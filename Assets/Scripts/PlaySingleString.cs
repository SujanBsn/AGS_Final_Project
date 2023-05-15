using UnityEngine;
using UnityEngine.InputSystem;

public class PlaySingleString : MonoBehaviour
{
    PlayNote PlayNote;

    private void Start()
    {
        PlayNote = GameObject.Find("BaseSource").GetComponent<PlayNote>();
    }

    /// <summary>
    /// Play selected string
    /// </summary>
    public void PlayString(int stringNum)
    {
        Debug.Log("hii");
        PlayNote.PlaySingleString(stringNum);
    }

    /// <summary>
    /// Play string1
    /// </summary>
    public void String1Play(InputAction.CallbackContext context)
    {
        if (context.started)
            PlayString(0);
    }

    /// <summary>
    /// Play string2
    /// </summary>
    public void String2Play(InputAction.CallbackContext context)
    {
        if(context.started)
            PlayString(1);
    }

    /// <summary>
    /// Play string3
    /// </summary>
    public void String3Play(InputAction.CallbackContext context)
    {
        if (context.started)
            PlayString(2);
    }

    /// <summary>
    /// Play string4 
    /// </summary>
    public void String4Play(InputAction.CallbackContext context)
    {
        if (context.started)
            PlayString(3);
    }

    /// <summary>
    /// Mute/Unmute string5
    /// </summary>
    public void String5play(InputAction.CallbackContext context)
    {
        if (context.started)
            PlayString(4);
    }

    /// <summary>
    /// Play string6
    /// </summary>
    public void String6Play(InputAction.CallbackContext context)
    {
        if (context.started)
            PlayString(5);
    }
}
