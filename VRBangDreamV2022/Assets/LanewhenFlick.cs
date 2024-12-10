using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;

public class LanewhenFlick : MonoBehaviour
{
    public KeyCode key;
    public GameObject backpanel;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckKboardInputs();
    }
    void MyFunct()
    {
        backpanel.SetActive(false);
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
                        //button.onClick.Invoke();
                        backpanel.SetActive(true);
                        Invoke(nameof(MyFunct), .07f);
                    break;
                }
            }
        }
        }
    }
