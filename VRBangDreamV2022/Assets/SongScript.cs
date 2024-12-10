using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public GameObject stageMenu;
    public Button button;
    private bool started;

    void Start()
    {
        Debug.Log(audioSource.clip.length);
        //Invoke(nameof(MyFunct), audioSource.clip.length);
    }

    void MyFunct()
    {
        button.onClick.Invoke();
        started = false;

        stageMenu.SetActive(false);
    }
    void Update()
    {
        if (gameObject.activeSelf && started == false) {
            Invoke(nameof(MyFunct), audioSource.clip.length);
            started = true;
        }
    }
}
