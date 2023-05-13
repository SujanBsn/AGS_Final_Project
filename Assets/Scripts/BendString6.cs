using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BendString6 : MonoBehaviour
{
    String6 String6;
    PlayNote PlayNote;
    GameObject mover;
    Vector2 moverPos;

    float x_Coords, y_Coords, frequency = 1;

    int bendCounter = 0;
    bool onMover = false;
    private void Start()
    {
        String6 = GetComponent<String6>();
        PlayNote = GameObject.Find("BaseSource").GetComponent<PlayNote>();
        mover = String6.mover;

    }
    /// <summary>
    /// To determine the position of the Bend and change the frequency accordingly
    /// </summary>
    public void OnBendString(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (bendCounter == 0)
            {
                moverPos = mover.transform.position;
                x_Coords = moverPos.x;
                y_Coords = moverPos.y;
            }

            if (onMover)
                bendCounter++;

            if (bendCounter == 1)
            {
                YSlide();
                PlayNote.SetNote(5, frequency);
                PlayNote.PlaySingleString(5);
            }
            if (bendCounter >= 2)
            {
                moverPos.x = x_Coords;
                mover.transform.position = moverPos;
                bendCounter = 0;
            }
        }
    }

    /// <summary>
    /// To slide in the y-axis keeping x constant;for bend ups and downs
    /// </summary>
    public void YSlide()
    {
        Vector2 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseLocation.x = x_Coords;
        mouseLocation.y = math.clamp(mouseLocation.y, y_Coords - .2f, y_Coords + .3f);
        mover.transform.position = mouseLocation;


    }

    private void Update()
    {
        if (bendCounter == 1)
        {
            YSlide();
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
    /// To detect when we exit the mover
    /// </summary>
    private void OnMouseExit()
    {
        onMover = false;
    }
}
