using UnityEngine;
using UnityEngine.InputSystem;

public class HammerOn : MonoBehaviour
{
    String1 String1;

    bool selectForHammer = false;

    public void OnHammerNote(InputAction.CallbackContext context)
    {
        if(context.started) 
        {
            Debug.Log("Hammer");
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
