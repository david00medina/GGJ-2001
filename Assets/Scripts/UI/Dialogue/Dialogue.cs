using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField]
    private string _header;
    [SerializeField][TextArea(3,10)]
    private string[] _sentences;

    public string Header => _header;

    public string[] Sentences => _sentences;
}
