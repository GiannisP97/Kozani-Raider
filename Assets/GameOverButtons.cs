using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public Button tryAgain;
    public Button Quit;

    // Start is called before the first frame update
    void Start()
    {
		tryAgain.onClick.AddListener(Task1);
        Quit.onClick.AddListener(Task2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Task1(){
        SceneManager.LoadScene("level1",LoadSceneMode.Single);
    }

    private void Task2(){
        SceneManager.LoadScene("mainMenu",LoadSceneMode.Single);
    }
}
