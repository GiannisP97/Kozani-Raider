using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facts : MonoBehaviour
{
    public string[] Facts;


    private int counter = 0;

    private int cost = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
