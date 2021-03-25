using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject[] hearts;

    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Button[] answerButtons;

    [SerializeField]
    private GameObject correctAnswerPopup;
    [SerializeField]
    private GameObject wrongAnswerPopup;



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

        correctAnswerPopup.SetActive(false);
        wrongAnswerPopup.SetActive(false);
        questionText.text = q.QuestionText;

        for(int i=0;i<q.Answers.Length;i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text=q.Answers[i];
            answerButtons[i].gameObject.SetActive(true);
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
