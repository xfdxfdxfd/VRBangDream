using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;

public class RecordPosY : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode key;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckKboardInputs();
    }

    void CheckKboardInputs()
    {
        Keyboard kboard = Keyboard.current;

        if (kboard.anyKey.wasPressedThisFrame)
        {
            foreach (KeyControl k in kboard.allKeys)
            {
                if (k.wasPressedThisFrame)
                {
                    //Debug.Log((int)k.keyCode + (key.ToString()) + (k.keyCode.ToString() == key.ToString()));
                    if (k.keyCode.ToString() == key.ToString())
                    {
                        Debug.Log(transform.localPosition.y);
                    }
                    break;
                }
            }
        }
    }
}
