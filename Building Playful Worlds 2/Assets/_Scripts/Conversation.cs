using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Conversation")]
public class Conversation : ScriptableObject
{
    public int id;
    public Sprite image;
    public string speakerName;
    [TextArea]
    public string textEnglish;

    public AudioClip audioFragmant;
}
