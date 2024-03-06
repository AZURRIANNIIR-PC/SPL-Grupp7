using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitharaObject : MonoBehaviour
{
    GameObject kitharaCloseUp;
    //GameObject kitharaObject;
    [SerializeField] GameObject kitharaText;
    private bool inCollder = false;
    private bool closeUpActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        kitharaCloseUp = GameObject.FindWithTag("KitharaCloseUp");
        //kitharaObject = GameObject.FindWithTag("KitharaObject");
        closeUpActivated = false;

        kitharaCloseUp.SetActive(false);
        //kitharaObject.SetActive(false);

        kitharaText.SetActive(false);
    }

    private void Update()
    {
        if(inCollder == true && Input.GetKeyDown(KeyCode.F))
        {
            if (closeUpActivated == false)
            {
                kitharaCloseUp.SetActive(true);
                closeUpActivated = true;
            }
            else if (closeUpActivated == true)
            {
                kitharaCloseUp.SetActive(false);
                closeUpActivated = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            kitharaText.SetActive(true);
            inCollder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            kitharaText.SetActive(false);
            inCollder = false;
        }
    }

    //public void triggerCloseUp() //f�r n�r kithara hade en knappkomponent
    //{
    //    Debug.Log("i am pressed!");
    //    if (kithara.activeSelf == false)
    //    {
    //        kithara.SetActive(true);
    //    }
    //    else if (kithara.activeSelf == true)
    //    {
    //        kithara.SetActive(false);
    //    }

    //}
}
