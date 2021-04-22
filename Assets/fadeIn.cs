using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fadeIn : MonoBehaviour
{
    private bool fadeout = false;
    private IEnumerator coroutine;
    public Sprite library;

    public Image background;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.E))
        {
            fadeout = true;
        }
        if(fadeout){
            this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r,this.GetComponent<Image>().color.g,this.GetComponent<Image>().color.b,this.GetComponent<Image>().color.a-1f*Time.deltaTime);
        }
        if( this.GetComponent<Image>().color.a==0){
            background.sprite = library;
        }
        
    }

}
