using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMessage : MonoBehaviour
{

    public string dialogo;
    public Text text;
    public GameObject panel;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void setText(){
        panel.SetActive(true);
        text.text = dialogo;
    }

    public void hideText(){
        panel.SetActive(false);
        text.text="";
    }

}

