using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public KeyCode key;
    public float posX;
    public float posY;
    public AudioSource audioSource;
    public GameObject effect;
    private bool started;

    public Text comboNum;
    //public float counter;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        //Invoke(nameof(MyFunct), audioSource.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (gameObject.activeSelf && started == false)
        {
            transform.localPosition = new Vector3(posX, posY, 0f);
            Invoke(nameof(MyFunct), audioSource.clip.length);
            started = true;
        }

        if (gameObject.activeSelf)
        {
            transform.localPosition -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
            CheckKboardInputs();
        }



    }

    void MyFunct()
    {
        transform.localPosition = new Vector3(posX, posY, 0f);
        started = false;
        comboNum.text = "0";
    }
    void MyFunct2()
    {
        effect.SetActive(false);
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
                        //Debug.Log(transform.localPosition.y);
                        if (transform.localPosition.y <= 0.18f && transform.localPosition.y >= -0.18f)
                        {
                            //gameObject.SetActive(false);
                            effect.SetActive(true);
                            transform.localPosition -= new Vector3(0f, 100f, 0f);
                            int comboNumber = int.Parse(comboNum.text) + 1;
                            comboNum.text = comboNumber.ToString();
                            Invoke(nameof(MyFunct2), .3f);
                        }
                    }
                    break;
                }
            }
        }
        if (transform.localPosition.y < -1f && transform.localPosition.y >= -10f)
        {
            transform.localPosition -= new Vector3(0f, 100f, 0f);
            comboNum.text = "0";
        }
    }
}
