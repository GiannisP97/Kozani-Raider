using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public Button b1;
    public Button b2;
    public 
    // Start is called before the first frame update
    void Start()
    {
        b1.onClick.AddListener(LoadLevel1);
        b1.onClick.AddListener(quitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel1(){
        SceneManager.LoadScene("level1", LoadSceneMode.Single);
    }

    void quitGame(){
        Application.Quit();
    }
}
