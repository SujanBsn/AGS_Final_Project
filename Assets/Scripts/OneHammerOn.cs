using System.Collections;
using System.Collections.Generic;
using UnityEditor.Presets;
using UnityEngine;

public class OneHammerOn : MonoBehaviour
{
    [SerializeField] GameObject noteObject;
    StringController StringController;
    bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        StringController = new StringController();
        StringController.Enable();
        StringController.SingleNote.StrumGuitar.started += _ => HammerOn();
    }
    void HammerOn()
    {
        if (pressed)
        {
            Vector2 hammerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(noteObject, hammerPosition, noteObject.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        StringController.SingleNote.HammerOn.Enable();
        StringController.SingleNote.HammerOn.started += _ => pressed = true;
        StringController.SingleNote.HammerOn.performed += _ => HammerOn();
        StringController.SingleNote.HammerOn.canceled += _ => pressed = false;
    }
}
