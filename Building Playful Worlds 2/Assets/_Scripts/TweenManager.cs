using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenManager : MonoBehaviour
{
    //objects to animate
    public GameObject conversationSpaceUI;
    // Start is called before the first frame update
    void Start() {
        LeanTween.scale(conversationSpaceUI, new Vector3(1.2f, 1.2f, 1.2f), 1f).setEase(LeanTweenType.easeOutElastic).setLoopPingPong();
    }

    // Update is called once per frame
    void Update() {

    }
}
