using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Presets;
using UnityEngine;

public class BendString1 : MonoBehaviour
{
    StringController StringController;
    String1 String1;
    bool pressed = false;
    int pressedCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        String1 = gameObject.GetComponent<String1>();

        StringController = new StringController();
        StringController.Enable();
        StringController.SingleNote.StrumGuitar.started += _ => HammerOn();
    }
    void HammerOn()
    {
        if (pressed && pressedCount == 2)
        {
            float slope = String1.CalculateSlope();

            Vector2 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //To make sure the mover stays on the string, we use :: y-y1 = m(x-x1)
            mouseLocation.y = String1.startPosValue.y + slope * (mouseLocation.x - String1.startPosValue.x);
            String1.mover.transform.position = mouseLocation;

            pressedCount = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (!pressed)
        {
            StringController.SingleNote.Bend.Disable();
        }

        Activate();
        Debug.Log(pressedCount);
    }

    void PressedButton()
    {
        pressed = true;
        pressedCount += 1;
    }  



    /// <summary>
    /// Activate the hammer on button
    /// </summary>
    void Activate()
    {

        Vector2 tempPos = String1.mover.transform.position;

        StringController.SingleNote.Bend.Enable();
        StringController.SingleNote.Bend.started += _ => PressedButton();
        StringController.SingleNote.Bend.performed += _ => HammerOn();
        StringController.SingleNote.Bend.canceled += _ => pressed = false;
    }
}
