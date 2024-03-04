using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitharaObject : MonoBehaviour
{
    GameObject kitharaCloseUp;
    //GameObject kitharaObject;
    [SerializeField] GameObject kitharaText;
    private bool closeUpActivated = false;

    // Start is called before the first frame update
    void Start()
    {
        kitharaCloseUp = GameObject.FindWithTag("KitharaCloseUp");
        //kitharaObject = GameObject.FindWithTag("KitharaObject");

        kitharaCloseUp.SetActive(false);
        //kitharaObject.SetActive(false);

        kitharaText.SetActive(false);
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            kitharaText.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true && Input.GetKey(KeyCode.F))
        {
            Debug.Log("In press, before if");
            Debug.Log("In press, closeupactivated: " + closeUpActivated);
            if (closeUpActivated == false)
            {
                kitharaCloseUp.SetActive(true);
                closeUpActivated = true;
                Debug.Log("Pressed to set active");
            }
            else if (closeUpActivated == true)
            {
                kitharaCloseUp.SetActive(false);
                closeUpActivated = false;
                Debug.Log("Pressed to close");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            kitharaText.SetActive(false);
        }
    }

    //public void triggerCloseUp() //för när kithara hade en knappkomponent
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
