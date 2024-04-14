using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Cutscenes : MonoBehaviour
{
    private int seenCutscenes = 0;

    public TextMeshProUGUI SpeechText;
    private string NoText = string.Empty;

    public GeneralCluckAnimator GeneralCluckAnimator;

    // Start is called before the first frame update
    void Start()
    {
        SpeechText.text = NoText;

        switch(GameManager.Instance.CurrentCutscene){
            case 0:
                StartCoroutine("StartingCutscene");
                break;
            case 1:
                StartCoroutine("Cutscene2");
                break;
            case 2:
                StartCoroutine("Cutscene3");
                break;
            case 3:
                StartCoroutine("Cutscene3");
                break;
            case 4:
                StartCoroutine("Cutscene4");
                break;
            case 5:
                StartCoroutine("Cutscene5");
                break;
        }
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

    IEnumerator Cutscene2()
    {
        GeneralCluckAnimator.isTalking = true;

        SpeechText.text = "Well done! You have proven worthy of your skills, test 62.";
        yield return new WaitForSeconds(5);
        SpeechText.text = "Now it's time for the real thing.";
        yield return new WaitForSeconds(4);
        SpeechText.text = "Enter the next program.";
        yield return new WaitForSeconds(3);

        SpeechText.text = NoText;
        GeneralCluckAnimator.isTalking = false;
    }

    IEnumerator Cutscene3()
    {
        GeneralCluckAnimator.isTalking = true;

        SpeechText.text = "Let us continue onto the next program.";
        yield return new WaitForSeconds(4);

        SpeechText.text = NoText;
        GeneralCluckAnimator.isTalking = false;
    }

    IEnumerator Cutscene4()
    {
        GeneralCluckAnimator.isTalking = true;

        SpeechText.text = "We've almost taken over.";
        yield return new WaitForSeconds(3);
        SpeechText.text = "Enter the next program.";
        yield return new WaitForSeconds(3);

        SpeechText.text = NoText;
        GeneralCluckAnimator.isTalking = false;
    }

    IEnumerator Cutscene5()
    {
        GeneralCluckAnimator.isTalking = true;

        SpeechText.text = "Finally, the last-";
        yield return new WaitForSeconds(1);

        GeneralCluckAnimator.Glitching = true;

        SpeechText.text = ":S?C?LE{&W^ncduw%s*";
        yield return new WaitForSeconds(0.2f);
        SpeechText.text = NoText;
        yield return new WaitForSeconds(0.1f);
        SpeechText.text = "(s&dm$Km3nNkdn^s7S%";
        yield return new WaitForSeconds(0.2f);
        SpeechText.text = "fd8S*SKV(ED&EA^O4SC";
        yield return new WaitForSeconds(0.3f);
        SpeechText.text = "NC&*SD%AS$A!C(XZPA£";
        yield return new WaitForSeconds(0.2f);
        SpeechText.text = NoText;
        yield return new WaitForSeconds(0.3f);
        SpeechText.text = "3LSDHC*s7S89s97a&ds";
        yield return new WaitForSeconds(0.2f);
        SpeechText.text = "NO&S*(c67asDONTs89c";
        yield return new WaitForSeconds(0.4f);

        SpeechText.text = NoText;
        GeneralCluckAnimator.isTalking = false;
    }
}
