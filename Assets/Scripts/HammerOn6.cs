using UnityEngine;
using UnityEngine.InputSystem;

public class HammerOn6 : MonoBehaviour
{
    String6 String6;
    PlayNote PlayNote;

    bool  onMover = false;
    int hammerCounter = 0;

    public void Start()
    {
        String6 = GetComponent<String6>();
        PlayNote = GameObject.Find("BaseSource").GetComponent<PlayNote>();
    }

    /// <summary>
    /// To determine the position of the HammerOn
    /// </summary>
    public void OnHammerNote(InputAction.CallbackContext context)
    {
        if(context.started) 
        {
            if (onMover)
                hammerCounter++;
            
            if(hammerCounter == 1)
            {
                String6.Slide();
                PlayNote.PlaySingleString(5);
            }
            hammerCounter = hammerCounter > 1 ? 0 : hammerCounter;
        }
    }

    /// <summary>
    /// To detect when we enter the mover
    /// </summary>
    private void OnMouseEnter()
    {
        onMover = true;
    }

    /// <summary>
    /// To detect when we exit the mover after enabling the slider
    /// </summary>
    private void OnMouseExit()
    {
        onMover = false;
    }
}
