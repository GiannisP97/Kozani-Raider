using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bookCount : MonoBehaviour
{
    public GameObject player;
    public Text textCount;
    public int maxBooks = 65;
    public GameObject victory;

    public GameObject[] teleports;

    DisplayMessage displayMessage;
    private IEnumerator coroutine;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        displayMessage = this.GetComponent<DisplayMessage>();
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        textCount.text = player.GetComponent<Books>().maxbooks.ToString()+"/"+maxBooks.ToString();
        float distance = Vector3.Distance(player.transform.position ,transform.position);
        if(distance<=1){
            player.GetComponent<characterController2D>().can_enter_teleport_room = true;
            for(int i=0;i<teleports.Length;i++){
                teleports[i].GetComponent<Teleport>().active = true;

            }
            displayMessage.text.text = "Πρεπει να μαζεψεις ολα τα βιβλια για νικήσεις";
            if(Input.GetKeyDown(KeyCode.E) && maxBooks<=player.GetComponent<Books>().maxbooks){
                displayMessage.enabled = false;
                victory.SetActive(true);
                audioSource.Play();

                coroutine = loadMenu();
                StartCoroutine(coroutine);
            }
        }
    }


    private IEnumerator loadMenu(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("mainMenu");
    }
}
