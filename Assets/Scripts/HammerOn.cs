using UnityEngine;
using UnityEngine.InputSystem;

public class HammerOn : MonoBehaviour
{
    public GameObject stringMover;
    String String;
    PlayNote PlayNote;

    public static bool  onString = false;

    public void Start()
    {
        String = stringMover.GetComponent<String>();
        PlayNote = GameObject.Find("BaseSource").GetComponent<PlayNote>();
    }

    /// <summary>
    /// To determine the position of the HammerOn on the string
    /// </summary>
    public void OnHammerNote(InputAction.CallbackContext context)
    {
        if (context.started && onString) 
        {
            PlayHammerNote();
        }
    }

    /// <summary>
    /// Play the selected hammer note
    /// </summary>
    public void PlayHammerNote()
    {
        String.Slide();
        PlayNote.PlaySingleString(String.stringNum);
    }

    /// <summary>
    /// To detect when we enter the mover
    /// </summary>
    private void OnMouseEnter()
    {
        onString = true;
    }

    /// <summary>
    /// To detect when we exit the mover
    /// </summary>
    private void OnMouseExit()
    {
        onString = false;
    }
}
