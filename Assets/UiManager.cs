using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    [SerializeField]
    private Text questionText;
    [SerializeField]
    public Button[] answerButtons;

    [SerializeField]
    public GameObject correctAnswerPopup;
    [SerializeField]
    private GameObject wrongAnswerPopup;

    private question currentQuestions;

    public bool hasAnswered = false;

    public Books books;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void QuestionUISetup(question q)
    {
        currentQuestions = q;
        correctAnswerPopup.SetActive(false);
        wrongAnswerPopup.SetActive(false);
        questionText.text = q.QuestionText;

        for(int i=0;i<q.Answers.Length;i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text=q.Answers[i];
            answerButtons[i].gameObject.SetActive(true);
        }

    }

    public void submit(int i){
        if(currentQuestions!=null){
            hasAnswered = true;
            if(currentQuestions.CorrectAnswer==i){
                books.books+=5;
                rightOrWrongPopup(true);
            }
            else
                rightOrWrongPopup(false);
        }
    }

    public void rightOrWrongPopup(bool a)
    {
        for(int i=0;i<3;i++)
        {
            answerButtons[i].gameObject.SetActive(false);
        }
        if(a)
        {
            correctAnswerPopup.SetActive(true);
        }
        else
        {
            wrongAnswerPopup.SetActive(true);
        }
    }



}
