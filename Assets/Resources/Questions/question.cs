using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenuAttribute]
public class question : ScriptableObject
{
    [SerializeField]
    private string questiontext;

    [SerializeField]
    private string[] answers;

    [SerializeField]
    private int correct;

    public string QuestionText{get{return questiontext;}}
    public string[] Answers{get{return answers;}}
    public int CorrectAnswer{get{return correct;}}

    public bool Asked{get; internal set;}




}
