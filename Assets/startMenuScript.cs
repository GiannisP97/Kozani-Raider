using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMenuScript : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey){
            panel.SetActive(true);
            this.gameObject.SetActive(false);
        }
        
    }
}
