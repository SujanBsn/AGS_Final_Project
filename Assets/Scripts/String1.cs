using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class String1 : MonoBehaviour
{
    public GameObject startPos, endPos, bridgePos, mover, open;//the objects within each string
    public Vector2 startPosValue, endPosValue, bridgePosValue;

    StringController StringController;
    PlayNote PlayNote;

    static double[] nutToFret = new double[20];

    bool pressed = false;  //to check if the mover is pressed

    private void Start()
    {
        startPosValue = startPos.transform.position;
        endPosValue = endPos.transform.position;
        bridgePosValue = bridgePos.transform.position;

        StringController = new StringController();
        PlayNote = GameObject.Find("BaseSource").GetComponent<PlayNote>(); //Because this script is a component of any object

        StringController.Enable();
        CalculateFretPosition();
    }


    /// <summary>
    /// Calculate and store the position of each fret from the nut and the bridge
    /// </summary>
    public void CalculateFretPosition()
    {
        float scaleLength = startPosValue.x - bridgePosValue.x;  //the distance from the nut to bridge
        float distance = 0, location, scalingFactor;

        //bridgeToFret[n-1] = scaleLength � nutToFret[n-1]
        //nutToFret[n] = (bridgeToFret[n-1] / 17.817) + nutToFret[n-1]
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
    public void Slide()
    {
        if (pressed)
        {
            float slope=CalculateSlope();

            Vector2 mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //To make sure the mover stays on the string, we use :: y-y1 = m(x-x1)
            mouseLocation.y = startPosValue.y + slope * (mouseLocation.x - startPosValue.x);
            mover.transform.position = Vector3.MoveTowards(mover.transform.position, mouseLocation, 1f);
        }
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
    /// Sets the fret number of the mover
    /// </summary>
    public void SetFretNum()
    {
        Vector3 moverPosition = mover.transform.position;
        int fretNum = 0;

        for (int i = 0; i <= 19; i++)
        {
            if (moverPosition.x < nutToFret[i])
            {
                fretNum = i;
            }
        }
       
        if( fretNum <= 18 )
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

        PlayNote.SetNote(6, playFreq);
    }

    void Update()
    {
        if (!pressed)
        {
            StringController.String.MouseSlide.Disable();
        }

        SetFretNum();
        CheckPosition();
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

    private void OnMouseDown()
    {
        StringController.String.MouseSlide.Enable();
        StringController.String.MouseClick.started += _ => pressed = true;
        StringController.String.MouseSlide.performed += _ => Slide();
        StringController.String.MouseClick.canceled += _ => pressed = false;
    }
}
