using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Books : MonoBehaviour
{
    public int books = 0;

    public int maxbooks = 0;
    public Text textBooks;

    void Start(){
        maxbooks = books;
    }

    void Update(){
        textBooks.text = books.ToString();
    }



}
