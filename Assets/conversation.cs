using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class conversation : MonoBehaviour
{
    public GameObject player;
    public GameObject conv_panel;
    public GameObject dialogos_panel;
    public GameObject erwtiseis_panel;
    public Image image;
    public Text conv_text;
    public Sprite portraito;

    public UiManager uiManager;

    public questionSelection questionSelection;


    public string[] conversation_text;

    private int counter = 0;
    private float distance;
    private bool inconversation;
    private IEnumerator routine;
    private bool HasAnsweredCorrect = false;

    private DisplayMessage displayMessage;
    // Start is called before the first frame update
    void Start()
    {
        inconversation = false;
        displayMessage = GetComponent<DisplayMessage>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position ,transform.position);
        if(distance<=1 && Input.GetKeyDown(KeyCode.E) && !inconversation && !HasAnsweredCorrect){
            inconversation = true;
            routine = start_conversation(2f);
        	StartCoroutine(routine);
        }
        
        
    }
    private IEnumerator start_conversation(float waitTime){

        player.GetComponent<characterController2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2();
        player.GetComponent<Animator>().SetInteger("State",0);
        this.GetComponent<DisplayMessage>().enabled = false;
        erwtiseis_panel.SetActive(false);
        dialogos_panel.SetActive(true);
        dialogos_panel.transform.GetChild(0).gameObject.SetActive(false);
        dialogos_panel.transform.GetChild(1).gameObject.SetActive(true);
        conv_panel.SetActive(true);
        image.sprite = portraito;


        for(int i=0;i<conversation_text.Length;i++){
            conv_text.text = conversation_text[i];
            yield return new WaitForSeconds(waitTime);
        }

        uiManager.QuestionUISetup(questionSelection.SelectQuestion());


        conv_panel.SetActive(false);
        erwtiseis_panel.SetActive(true);

        yield return new WaitUntil(()=> uiManager.hasAnswered);
        uiManager.hasAnswered = false;
        yield return new WaitForSeconds(3f);
        HasAnsweredCorrect = uiManager.IsCorrect;
        
        player.GetComponent<characterController2D>().enabled = true;
        this.GetComponent<DisplayMessage>().enabled = false;
        dialogos_panel.SetActive(false);
        inconversation = false;
    }
    
}