using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleporter;
    public bool active = false;
    public GameObject player;
    public GameObject camere;

    public AudioClip[] audioClip;

    private AudioSource audioSource;
    private IEnumerator routine;

    //private bool isTeleporting = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position ,transform.position);
        

        if(distance<=0.6 && Input.GetKeyDown(KeyCode.E) && active && !player.GetComponent<characterController2D>().isTeleporting){

            Debug.Log(player.GetComponent<characterController2D>().isTeleporting);
            player.GetComponent<characterController2D>().isTeleporting = true;
            audioSource.clip = audioClip[0];
            audioSource.Play();
            player.GetComponent<characterController2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            routine = teleport();
            StartCoroutine(routine);
        }
        
    }

    public void playHealingAudio(){
        audioSource.clip = audioClip[1];
        audioSource.Play();
    }



	private void OnTriggerEnter2D(Collider2D other){


    }

    private IEnumerator teleport(){
        yield return new WaitForSeconds(0.5f);

        player.transform.position = teleporter.position;
        camere.transform.position = new Vector3(teleporter.position.x,teleporter.position.y,-10);
        
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<characterController2D>().enabled = true;
        player.GetComponent<characterController2D>().isTeleporting = false;
    }


    
}
