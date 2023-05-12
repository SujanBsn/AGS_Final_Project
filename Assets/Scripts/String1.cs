using Unity.Mathematics;
using UnityEngine;

public class String1 : MonoBehaviour
{
    [SerializeField] private GameObject startPos, endPos, bridgePos, mover, open;//the objects within each string
    
    StringController StringController;
    PlayNote PlayNote;

    Vector2 startPosValue, endPosValue, bridgePosValue;
    bool pressed = false;  //to check if the mover is pressed

    static double[] nutToFret = new double[20];

    private void Start()
    {
        startPosValue = startPos.transform.position;
        endPosValue = endPos.transform.position;
        bridgePosValue = bridgePos.transform.position;

        StringController = new StringController();
        PlayNote = GetComponent<PlayNote>();

        StringController.Enable();
        CalculateFretPosition();
    }


    /// <summary>
    /// Calculate and store the position of each fret from the nut and the bridge
    /// </summary>
    void CalculateFretPosition()
    {
        float scaleLength = startPosValue.x - bridgePosValue.x;  //the distance from the nut to bridge
        float distance = 0, location, scalingFactor;

        for (int fret = 0; fret <= 19; fret++)//fret is the number of frets
        {
            location = scaleLength - distance;
            scalingFactor = location / 17.817f;
            distance += scalingFactor;
            nutToFret[fret] = startPosValue.x-distance;
        }
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
            directionX = directionSlide.x > 0 ? 2 : -2;
            directionY = directionSlide.x > 0 ? -2 : 2;

            slope = CalculateSlope(startPos, endPos);

            location.x += directionX * .5f*.2f;  //*.5f*.1f is correction factor
            location.y += directionY * slope * .5f*.2f; //same correction factor has to be applied to y
            mover.transform.position = location;
        }
    }

    /// <summary>
    /// Returns the slope of the string
    /// </summary>
    float CalculateSlope(GameObject start, GameObject end)
    {
        float deltaX, deltaY, slope;

        deltaX = endPosValue.x - startPosValue.x;
        deltaY = endPosValue.y - startPosValue.y;
        slope = deltaY / Mathf.Abs(deltaX);

        return slope;
    }

    /// <summary>
    /// Sets the fret number of the mover
    /// </summary>
    void SetFretNum()
    {
        Vector3 getPos = new();
        int fretNum = 0;

        getPos = mover.transform.position;

        for (int i = 0; i <= 19; i++)
        {
            if (getPos.x < nutToFret[i])
            {
                fretNum = i+1;
            }
        }
        SetFrequency(fretNum);
        Debug.Log(fretNum);
    }

    /// <summary>
    /// Sets the frequency of the mover
    /// </summary>
    void SetFrequency(int fretNum)
    {
        int upFret = fretNum + 1;
        int lowFret = fretNum;

        float upFretFreq = 1, lowFretFreq = 1;

        for (int i = 0; i <= lowFret; i++)
        {
            lowFretFreq *= math.pow(2f, 1f / 12f);
            upFretFreq *= math.pow(2f, 1f / 12f);
        }
        upFretFreq *= math.pow(2f, 1f / 12f);
    }

    void Update()
    {
        if (!pressed)
        {
            StringController.String1.MouseSlide.Disable();
        }

        SetFretNum();

        CheckPosition();
    }

    /// <summary>
    /// Makes sure the mover within the fretboard
    /// </summary>
     void CheckPosition()
    {
        if (mover.transform.position.x >= startPosValue.x)
        {
            mover.transform.position = startPosValue;
        }
        else if (mover.transform.position.x <= endPosValue.x)
        {
            mover.transform.position = endPosValue;
        }
    }

    private void OnMouseDown()
    {
        StringController.String1.MouseSlide.Enable();
        StringController.String1.MouseClick.started += _ => pressed = true;
        StringController.String1.MouseSlide.performed += _ => Slide();
        StringController.String1.MouseClick.canceled += _ => pressed = false;
    }


}
