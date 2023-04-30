using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class String1 : MonoBehaviour
{
    [SerializeField]private GameObject startPos, endPos, mover,open;
    StringController StringController;
    Vector2 startPosValue,endPosValue;
    bool pressed = false;

    private void Awake()
    {
        StringController = new StringController();
        StringController.Enable();
    }


    /// <summary>
    /// Slides the mover in the direction of the mouse
    /// </summary>
    void Slide()
    {
        if (pressed)
        {
            float slope, directionX, directionY;
            _ = new Vector2();
            Vector2 location = mover.transform.position;

            Vector2 directionSlide = StringController.String1.MouseSlide.ReadValue<Vector2>();
            directionX = directionSlide.x > 0 ? 10 : -10;
            directionY = directionSlide.x > 0 ? -10 : 10;

            slope = CalculatePosition(startPos, endPos);

            location.x += directionX * Time.deltaTime;  
            location.y += directionY * slope * Time.deltaTime;
            mover.transform.position = location;
        }
    }


    /// <summary>
    /// Returns the slope of the string
    /// </summary>
    float CalculatePosition(GameObject start, GameObject end)
    {
        float deltaX,deltaY, slope;
        
        deltaX = endPosValue.x - startPosValue.x;
        deltaY = endPosValue.y - startPosValue.y;
        slope = deltaY / Mathf.Abs(deltaX);
        Debug.Log(slope);

        return slope;
    }


    void Start()
    {
        startPosValue = startPos.transform.position;
        endPosValue = endPos.transform.position;
    }

  
    void Update()
    {
        CheckPosition();
        Debug.Log(mover.transform.position);
    }

    /// <summary>
    /// Sets the mover within the fretboard
    /// </summary>
     void CheckPosition()
    {
        if (mover.transform.position.x >= startPosValue.x)
        {
            _ = new Vector2();
            Vector2 positionUpdater = mover.transform.position;
            mover.transform.position = startPosValue;
        }
        else if (mover.transform.position.x <= endPosValue.x)
        {
            _ = new Vector2();
            Vector2 positionUpdater = mover.transform.position;
            mover.transform.position = endPosValue;
        }
    }

    private void OnMouseDown()
    {
        StringController.String1.MouseClick.started += _ => pressed = true;
        StringController.String1.MouseSlide.performed += _ => Slide();
        StringController.String1.MouseClick.canceled += _ => pressed = false;
    }
}
