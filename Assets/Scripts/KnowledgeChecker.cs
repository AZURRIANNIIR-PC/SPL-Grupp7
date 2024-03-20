//Adin Farid, adfa8505
//Linn Li, lili6794
//Nora Wennerberg, nowe9092

using UnityEngine;
using UnityEngine.UI;

public class KnowledgeChecker : MonoBehaviour
{
    [SerializeField] private GameObject questionParent;
    [SerializeField] private Text text;
    [SerializeField] private string questionText;
    [SerializeField] private string rightAnswerResponse;
    [SerializeField] private string wrongAnswerResponse;
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    private bool hasAnswered = false;
    private bool answeredRight;
    //private int totalCorrectAnswers = 0; //denna bortkommenterars rn f�r vi skiter f�r stunden i flera slut

    void Start()
    {
        questionParent.SetActive(false); // G�r texten osynlig
        text.text = questionText; //S�tt texten till urspungliga
        //Debug.Log("in start: " + totalCorrectAnswers);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        { //Om spelaren integrerar
            if (hasAnswered)
            {
                if(answeredRight == true)
                {
                    text.text = rightAnswerResponse;
                    button1.interactable= false;
                    button2.interactable= false;
                } else if (answeredRight == false)
                {
                    text.text = wrongAnswerResponse;
                }
                
            }
            else
            {
                text.text = questionText;
                //Debug.Log("text synlig");
            }
            
            //texten s�tts aktiv oavsett vad som st�r p� den, ifall det �r spelaren som g�r in
            questionParent.SetActive(true);
            //audioS.PlayOneShot(clip);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            questionParent.SetActive(false);
            //Debug.Log("text f�rsvinner");
        }
    }

    public void AnsweredCorreclty()
    {
        text.text = rightAnswerResponse;
        hasAnswered = true;
        answeredRight = true;
        //totalCorrectAnswers = totalCorrectAnswers + 1; //denna funkar ej helt

        button1.interactable = false;
        button2.interactable = false;
        //Debug.Log("in answeredCorreclty: " + totalCorrectAnswers);
    }

    public void AnsweredWrong()
    {
        text.text = wrongAnswerResponse;
        hasAnswered = true;
        answeredRight = false;

        button1.interactable = false;
        button2.interactable = false;
        //Debug.Log("in answeredWrong: " + totalCorrectAnswers);
    }

    //public int getTotalCorrectAnswers() //f�r i slutet, n�r man fr�n ett annat script ska checka hur bra spelaren gjorde
    //{
    //    return totalCorrectAnswers;
    //}
}
