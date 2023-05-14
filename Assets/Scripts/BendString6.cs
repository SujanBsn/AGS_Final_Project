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
    Vector2 moverPos,currentPos,lastPos;

    float x_Coords, y_Coords, frequency = 1, playFreq = 1;

    int bendCounter = 0;
    bool onMover = false;
    private void Start()
    {
        String6 = GetComponent<String6>();
        PlayNote = GameObject.Find("BaseSource").GetComponent<PlayNote>();
        mover = String6.mover;
        lastPos = mover.transform.position;

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
                frequency = PlayNote.stringSource[5].pitch;
                moverPos = mover.transform.position;
                x_Coords = moverPos.x;
                y_Coords = moverPos.y;
            }

            if (onMover)
                bendCounter++;

            if (bendCounter == 1)
            {
                YSlide();
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
        float y_Min = y_Coords - .6f;
        float y_Max = y_Coords + .2f;

        Vector2 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseLocation.x = x_Coords;
        mouseLocation.y = math.clamp(mouseLocation.y, y_Min, y_Max);

        mover.transform.position = mouseLocation;
    }

    /// <summary>
    /// Set the frequency relative to the y position
    /// </summary>
    public void SetYFreq()
    {
        Vector2 moverLocation = String6.mover.transform.position;
        playFreq = frequency * (1 + math.abs(moverLocation.y - y_Coords) / (.6f));
        Debug.Log(moverLocation.y - y_Coords);
        PlayNote.SetNote(6, playFreq);
        playFreq = 1;
    }


    private void Update()
    {
        if (bendCounter == 1)
        {
            YSlide();

            currentPos = String6.mover.transform.position;
            if (currentPos.y != lastPos.y)
                SetYFreq();
            lastPos = currentPos;
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
