using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public Button b1;
    public Button b2;

    public Button b3;
    public Button b4;
    public GameObject controlls;
    public GameObject about_us;
    // Start is called before the first frame update
    void Start()
    {
        b1.onClick.AddListener(LoadLevel1);
        b2.onClick.AddListener(quitGame);
        b3.onClick.AddListener(controllMenu);
        b4.onClick.AddListener(aboutusMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel1(){
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

    void quitGame(){
        Application.Quit();
    }

    void controllMenu(){
        controlls.SetActive(true);
        this.gameObject.SetActive(false);
    }

    void aboutusMenu(){
        about_us.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
