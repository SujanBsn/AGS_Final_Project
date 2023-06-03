using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Name
{
    E, F,
    Fs, G,
    Gs, A,
    As, B,
    Bs, C,
    D, Ds
}

public class NoteName : MonoBehaviour
{
    String String;
    int firstName;
    Name nameOfNote;
    public Text nameNote;


    private void Start()
    {
        String = gameObject.GetComponent<String>();
    }

    void GetFirstNote(int stringNum)
    {
        switch(stringNum)
        {
            case 0:
                firstName = 0;  //E
                break;
            case 1:
                firstName = 7;  //B
                break;
            case 2:
                firstName = 3;  //G
                break;
            case 3:
                firstName = 10; //D
                break;
            case 4:
                firstName = 5;  //A
                break;
            case 5:
                firstName = 0;  //E
                break;
        }
    }

    void SetNote()
    {
        int fretNum = String.fretNum;
        int noteNum = firstName + fretNum;
        if (noteNum > 11)
        {
            noteNum -= 12;
        }
        nameOfNote = (Name)noteNum;
        nameNote.text = "String " + (String.stringNum + 1) + ": " + nameOfNote.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        GetFirstNote(String.stringNum);
        SetNote();
    }
}
