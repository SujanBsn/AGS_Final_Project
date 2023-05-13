using UnityEngine;
using UnityEngine.InputSystem;

public class HammerOn : MonoBehaviour
{
    PlayerInput PlayerInput;
    String1 String1;
    StringController StringController;

    bool selectForHammer = false;

    public void OnHammerNote(InputAction.CallbackContext context)
    {
        if(context.started) 
        {
           
        }
    }

    private void OnMouseEnter()
    {
        selectForHammer = true;
    }

    private void Update()
    {

    }
}
