using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class BendString : MonoBehaviour
{
    String String;
    PlayNote PlayNote;
    GameObject mover;
    Vector2 moverPos, currentPos, lastPos;//For sliding in the y direction

    float x_Coords, y_Coords, frequency = 1, playFreq = 1;

    int bendCounter = 0;
    bool onMover = false;

    private void Start()
    {
        String = GetComponent<String>();
        PlayNote = GameObject.Find("BaseSource").GetComponent<PlayNote>();
        mover = String.mover;
        lastPos = mover.transform.position;
    }
    /// <summary>
    /// To determine the position of the Bend and change the frequency accordingly
    /// </summary>
    public void OnBendString(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (onMover)
                bendCounter++;

            if (bendCounter == 0)
            {
                frequency = PlayNote.stringSource[5].pitch;
                moverPos = mover.transform.position;
                x_Coords = moverPos.x;
                y_Coords = moverPos.y;
            }

            if (bendCounter == 1)
            {
                YSlide();
                PlayNote.PlaySingleString(String.stringNum);
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
        Vector2 moverLocation = String.mover.transform.position;
        playFreq = frequency * (1 + math.abs(moverLocation.y - y_Coords) / (.6f));
        PlayNote.SetNote(String.stringNum, playFreq);
        playFreq = 1;
    }


    private void Update()
    {
        if (bendCounter == 1)//everything is placed inside condition to distinguish from non-bend y movement
        {
            YSlide();

            currentPos = String.mover.transform.position;

            if (currentPos.y != lastPos.y)//To make sure x_changed frequency is registered from String.cs
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
