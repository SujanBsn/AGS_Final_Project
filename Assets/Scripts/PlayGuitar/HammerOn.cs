using UnityEngine;
using UnityEngine.InputSystem;

public class HammerOn : MonoBehaviour
{
    public GameObject stringMover;
    String StringVar;
    PlayNote PlayNote;

    public bool onString = false;

    public void Start()
    {
        StringVar = stringMover.GetComponent<String>();
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
        StringVar.Slide();
        PlayNote.PlaySingleString(StringVar.stringNum);
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
