﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class setText : MonoBehaviour
{
    public Text message;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setmessage(string s){

        if(s==""){
            panel.SetActive(false);
        }
        else{
            message.text = s;
            panel.SetActive(true);
        }

    }
}
