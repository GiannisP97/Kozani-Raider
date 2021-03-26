using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class questionSelection : MonoBehaviour
{
    private question[] allQuestions;

    private void Awake()
    {
        LoadQuestions();
    }

    private void LoadQuestions()
    {
        allQuestions = Resources.LoadAll<question>("Questions");
    }

    public question SelectQuestion()
    {
        ResetIfAllAsked();

        question q = allQuestions.Where(t => t.Asked == false).OrderBy(t => UnityEngine.Random.Range(0, int.MaxValue)).FirstOrDefault();
 
        q.Asked = true;
        return q;

    }



    private void ResetIfAllAsked()
    {
        if(allQuestions.Any(t => t.Asked == false) == false)
        {
            foreach(question q in allQuestions)
            {
                q.Asked = false;
            }
        }


    }

}
