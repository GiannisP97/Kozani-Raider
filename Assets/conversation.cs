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


    public string[] conversation_text;

    private int counter = 0;
    private float distance;

    private IEnumerator routine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position ,transform.position);
        if(distance<=1 && Input.GetKeyDown(KeyCode.E)){
            routine = start_conversation(4.5f);
        	StartCoroutine(routine);
        }
        
        
    }

    private IEnumerator start_conversation(float waitTime){

        player.GetComponent<characterController2D>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2();
        player.GetComponent<Animator>().SetInteger("State",0);
        erwtiseis_panel.SetActive(false);
        dialogos_panel.SetActive(true);
        conv_panel.SetActive(true);
        image.sprite = portraito;


        for(int i=0;i<conversation_text.Length;i++){
            conv_text.text = conversation_text[i];
            yield return new WaitForSeconds(waitTime);
        }
        conv_panel.SetActive(false);

        player.GetComponent<characterController2D>().enabled = true;
        dialogos_panel.SetActive(false);
        
     }
    
}
