using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public Button tryAgain;
    public Button Quit;

    public Transform player;

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
        //SceneManager.LoadScene("level1",LoadSceneMode.Single);
        player.position = new Vector3(-8,-1,0);
        player.GetComponent<Health>().health = player.GetComponent<Health>().numOfHearts;
        player.gameObject.SetActive(true);
        player.GetComponent<characterController2D>().resetInvisiblility();
        this.gameObject.SetActive(false);
    }

    private void Task2(){
        SceneManager.LoadScene("mainMenu",LoadSceneMode.Single);
    }
}
