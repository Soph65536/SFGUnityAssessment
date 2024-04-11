using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cutscenes : MonoBehaviour
{
    public TextMeshProUGUI SpeechText;
    private string NoText = string.Empty;

    public GeneralCluckAnimator GeneralCluckAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        SpeechText.text = NoText;
        StartCoroutine("StartingCutscene");
    }

    IEnumerator StartingCutscene()
    {
        GeneralCluckAnimator.isTalking = true;

        SpeechText.text = "Welcome Sergeant 62! I am your new commander.";
        yield return new WaitForSeconds(5);
        SpeechText.text = "For your first mission, I will test your skills on the battlefield!";
        yield return new WaitForSeconds(5);
        SpeechText.text = "We are to eradicate as many of these pesky files as is possible!";
        yield return new WaitForSeconds(4);
        SpeechText.text = "Go enter that program over there when you're ready to start.";
        yield return new WaitForSeconds(5);

        SpeechText.text = NoText;
        GeneralCluckAnimator.isTalking = false;
    }
}
