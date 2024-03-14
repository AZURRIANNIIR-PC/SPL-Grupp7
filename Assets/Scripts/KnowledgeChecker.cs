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
    //private int totalCorrectAnswers = 0; //denna bortkommenterars rn för vi skiter för stunden i flera slut

    void Start()
    {
        questionParent.SetActive(false); // Gör texten osynlig
        text.text = questionText; //Sätt texten till urspungliga
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
            
            //texten sätts aktiv oavsett vad som står på den, ifall det är spelaren som går in
            questionParent.SetActive(true);
            //audioS.PlayOneShot(clip);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            questionParent.SetActive(false);
            //Debug.Log("text försvinner");
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

    //public int getTotalCorrectAnswers() //för i slutet, när man från ett annat script ska checka hur bra spelaren gjorde
    //{
    //    return totalCorrectAnswers;
    //}
}
