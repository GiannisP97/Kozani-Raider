using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class facts : MonoBehaviour
{
    public string[] Facts;
    public GameObject dialogosPanel;
    public Text text;

    public GameObject player;

    private int counter = 0;
    private IEnumerator routine;
    private int cost = 1;
    private float distance;
    public bool finished = false;

    public bool inFact = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(player.transform.position ,transform.position);
        if(distance<=1 && Input.GetKeyDown(KeyCode.E) && inFact){
            finished = true;
        }
        
    }

    public int getcost(){
        return cost;
    }


    public string getFact(){
        if(Facts.Length>counter){
            counter++;
            cost+=2;
            return Facts[counter];
        }
        else
            return "Δεν υπαρχουν αλλα facts";
    }


    public void DisplayFact(){
        routine = start_conversation(0.5f);
        StartCoroutine(routine);
    }

     private IEnumerator start_conversation(float waitTime){

        player.GetComponent<characterController2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2();
        player.GetComponent<Animator>().SetInteger("State",0);

        //this.GetComponent<DisplayMessage>().enabled = false;
        //erwtiseis_panel.SetActive(false);
        dialogosPanel.SetActive(true);
        dialogosPanel.transform.GetChild(0).gameObject.SetActive(false);
        dialogosPanel.transform.GetChild(1).gameObject.SetActive(false);
        dialogosPanel.transform.GetChild(2).gameObject.SetActive(true);

        text.text = getFact();
        yield return new WaitForSeconds(3f);
        inFact = true;


        yield return new WaitUntil(()=> finished);
        finished = false;

        player.GetComponent<characterController2D>().enabled = true;
        dialogosPanel.SetActive(false);

     }
}
