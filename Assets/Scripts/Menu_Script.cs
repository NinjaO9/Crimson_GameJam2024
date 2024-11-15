using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Script : MonoBehaviour
{
    [SerializeField] Canvas main_canvas;
    [SerializeField] Canvas settings_canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play_Button()
    {
        SceneManager.LoadScene("Prologue");
    }

    public void Settings_Button()
    {
        main_canvas.gameObject.SetActive(false);
        settings_canvas.gameObject.SetActive(true);
    }

    public void Exit_Button()
    {
        Debug.Log("Bro wants to leave :skull:");
    }

    public void Back_Button()
    {
        settings_canvas.gameObject.SetActive(false);
        main_canvas.gameObject.SetActive(true);
    }
}
