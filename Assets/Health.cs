using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart;

    public GameObject gameover;

    void Update(){


        if(health<=0){
            //Destroy(this);
            this.gameObject.SetActive(false);
            gameover.SetActive(true);
        }


        for (int i=0;i<hearts.Length;i++){
            if(i<health){
                hearts[i].sprite=fullHeart;
            }
            else{
                hearts[i].sprite = EmptyHeart;
            }
            if(i<numOfHearts){
                hearts[i].enabled = true;
            }
            else
                hearts[i].enabled = false;
        }
        
    }
}
