using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class fadeIn : MonoBehaviour
{
    private bool fadeout = false;
    private IEnumerator coroutine;
    public Sprite library;

    public Text[] text;
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
            this.GetComponent<Image>().color = new Color(this.GetComponent<Image>().color.r,this.GetComponent<Image>().color.g,this.GetComponent<Image>().color.b,this.GetComponent<Image>().color.a-0.5f*Time.deltaTime);
            foreach(Text t in text){
                t.color = new Color(t.color.r,t.color.g,t.color.b,t.color.a-0.5f*Time.deltaTime);
            }
            coroutine = loadScene();
            StartCoroutine(coroutine);
        }
        if( this.GetComponent<Image>().color.a==0){
            background.sprite = library;
        }
        
    }

    private IEnumerator loadScene(){
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

}
