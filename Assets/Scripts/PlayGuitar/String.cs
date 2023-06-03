using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class String : MonoBehaviour
{
    PlayNote PlayNote;

    public GameObject startPos, endPos, bridgePos, mover, open;//the objects within each string
    public Vector2 startPosValue, endPosValue, bridgePosValue, currentPos, lastPos; //To store the value of constantly used positions

    public static double[] nutToFret = new double[21];//To store the position of each fret

    bool onMover = false;  //to check if the mover is pressed
    int slideCounter = 0; //to check how many times the mover has been pressed for sliding
    public int stringNum, fretNum = 0;//The string to which this script is attached

    private void Start()
    {
        startPosValue = startPos.transform.position;
        endPosValue = endPos.transform.position;
        bridgePosValue = bridgePos.transform.position;
        lastPos = startPosValue;

        PlayNote = GameObject.Find("BaseSource").GetComponent<PlayNote>(); //Because this script is a component of any object
        
        CalculateFretPosition();
        GetStringNum();
    }



    /// <summary>
    /// Sets the beginning and ending of sliding on the string
    /// </summary>
    public void BeginSlide(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (onMover)
                slideCounter++;

            slideCounter = slideCounter > 1 ? 0 : slideCounter;
        }
    }

    /// <summary>
        /// Slides the mover in the direction of the mouse
        /// </summary>
    public void Slide()
    {
        float slope = CalculateSlope();

        Vector2 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //To make sure the mover stays on the string, we use :: y-y1 = m(x-x1)
        mouseLocation.y = startPosValue.y + slope * (mouseLocation.x - startPosValue.x);
        mover.transform.position = mouseLocation;
        CheckPosition();
    }

    /// <summary>
    /// Returns the slope of the string
    /// </summary>
    public float CalculateSlope()
    {
        float deltaX, deltaY, slope;

        deltaX = endPosValue.x - startPosValue.x;
        deltaY = endPosValue.y - startPosValue.y;
        slope = deltaY / deltaX;

        return slope;
    }

    /// <summary>
    /// Calculate and store the position of each fret from the nut and the bridge
    /// </summary>
    public void CalculateFretPosition()
    {
        nutToFret[0] = startPosValue.x;
        float scaleLength = startPosValue.x - bridgePosValue.x;  //the distance from the nut to bridge
        float distance = 0, location, scalingFactor;

        //bridgeToFret[n-1] = scaleLength � nutToFret[n-1]
        //nutToFret[n] = (bridgeToFret[n-1] / 17.817) + nutToFret[n-1]
        for (int fret = 1; fret <= 20; fret++)//fret is the number of frets
        {
            location = scaleLength - distance;
            scalingFactor = location / 17.817f;
            distance += scalingFactor;
            nutToFret[fret] = startPosValue.x - distance;
        }
    }

    /// <summary>
    /// Sets the fret number of the mover
    /// </summary>
    public void SetFretNum()
    {
        Vector3 moverPosition = mover.transform.position;
        for (int i = 0; i <= 20; i++)
        {
            if (moverPosition.x < nutToFret[i])
            {
                fretNum = i;
            }
        }
       
        if( fretNum <= 20 )
            SetFrequency(fretNum);
    }

    /// <summary>
    /// Sets the frequency of the mover
    /// </summary>
    public void SetFrequency(int fretNum)
    {
        Vector2 getPosOfFret = mover.transform.position;

        int upFret = fretNum + 1;
        int lowFret = fretNum;

        float upFretFreq = 1, lowFretFreq = 1, playFreq = 1;

        //F(n+1)=F(n)*2^(1/12)
        for (int i = 0; i <= lowFret; i++)
        {
            lowFretFreq *= math.pow(2f, 1f / 12f);
            upFretFreq *= math.pow(2f, 1f / 12f);
        }
        upFretFreq *= math.pow(2f, 1f / 12f);
        //playFreq is generated by linear interpolation of the frequency between the upper and lower fret from the selected position
        playFreq = lowFretFreq + (upFretFreq - lowFretFreq) * (getPosOfFret.x - (float)nutToFret[lowFret])
            / (float)(nutToFret[upFret] - (float)nutToFret[lowFret]);

        PlayNote.SetNote(stringNum, playFreq);
    }

    /// <summary>
    /// To get the string number this string is attached to
    /// </summary>
    public void GetStringNum()
    {
        string stringName;
        stringName = gameObject.name;

        switch (stringName)
        {
            case "String6Mover":
                stringNum = 5;
                break;
            case "String5Mover":
                stringNum = 4;
                break;
            case "String4Mover":
                stringNum = 3;
                break;
            case "String3Mover":
                stringNum = 2;
                break;
            case "String2Mover":
                stringNum = 1;
                break;
            case "String1Mover":
                stringNum = 0;
                break;
        }
    }

    void Update()
    {
        currentPos = mover.transform.position;
        if(currentPos.x!=lastPos.x)   //To let frequency change when we play bend note
            SetFretNum();
        lastPos = currentPos;

        if (slideCounter == 1)
        {
            Slide();
        }
    }

    /// <summary>
    /// Makes sure the mover within the fretboard
    /// </summary>
    public void CheckPosition()
    {
        Vector2 moverPos = mover.transform.position;
        
        moverPos = moverPos.x >= startPosValue.x ? startPosValue : moverPos;
        moverPos = moverPos.x <= endPosValue.x ? endPosValue : moverPos;

        mover.transform.position = moverPos;
    }

    /// <summary>
    /// To determine the position of the HammerOn on the string if the mover overlaps
    /// </summary>
    public void OnMoverHammerNote(InputAction.CallbackContext context)
    {
        if (context.started && onMover)
        {
            PlayNote.PlaySingleString(stringNum);
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
    private void OnMouseExit()
    {
        onMover = false;
    }
}