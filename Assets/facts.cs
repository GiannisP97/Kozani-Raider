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

    private bool isEmpty = false;

    private int counter = 7;
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

    public bool getIsEmpty(){
        if(Facts.Length<counter+1){
            isEmpty = true;
        }
        else
        isEmpty = false;


        return isEmpty;
    }

    public int getcost(){
        return cost;
    }


    public string getFact(){
        if(Facts.Length>counter){
            string f = Facts[counter];
            counter++;
            cost+=2;
            print(counter);
            return f;
        }
        else{
            isEmpty = true;
            return "Δεν υπαρχουν αλλα facts";
        }
            
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
        string txt = getFact();


        inFact = true;
        finished = false;
        if(txt.Length>320)
        {
            if(txt.Length>640){
                text.text = txt.Substring(0,320);
                print(txt.Length);

                yield return new WaitForSeconds(1.5f);
                yield return new WaitUntil(()=> finished);
                
                finished = false;
                text.text = txt.Substring(320,320);

                yield return new WaitForSeconds(1.5f);
                yield return new WaitUntil(()=> finished);

                finished = false;
                text.text = txt.Substring(640);

                yield return new WaitForSeconds(1.5f);
                yield return new WaitUntil(()=> finished);
                

            }
            else{
                text.text = txt.Substring(0,320);
            
                yield return new WaitForSeconds(1.5f);


                yield return new WaitUntil(()=> finished);
                finished = false;
                text.text = txt.Substring(320);

                yield return new WaitForSeconds(1.5f);
                yield return new WaitUntil(()=> finished);

            }

        }
        else{
            text.text = txt;
            
            yield return new WaitForSeconds(1.5f);
            yield return new WaitUntil(()=> finished);
        }



        finished = false;

        player.GetComponent<characterController2D>().enabled = true;
        dialogosPanel.SetActive(false);

     }
}
