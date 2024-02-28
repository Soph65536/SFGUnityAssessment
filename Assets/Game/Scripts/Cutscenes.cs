using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cutscenes : MonoBehaviour
{
    public TextMeshProUGUI SpeechText;
    private string NoText = string.Empty;

    // Start is called before the first frame update
    void Awake()
    {
        SpeechText.text = NoText;
        StartCoroutine("StartingCutscene");
    }

    IEnumerator StartingCutscene()
    {
        SpeechText.text = "Welcome Sergeant 62! Your mission here is to eradicate the blobgorbs in our battle against the idk yet";
        yield return new WaitForSeconds(7);
        SpeechText.text = "Go climb in to that hidey hole over there when you're ready to face our enemy!";
        yield return new WaitForSeconds(6);
        SpeechText.text = NoText;
    }
}
