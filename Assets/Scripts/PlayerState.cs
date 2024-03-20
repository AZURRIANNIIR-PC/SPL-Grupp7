using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {
    public int healthPoints = 6;
    public int initialHealthPoints = 6;
    public int foodAmount = 0;

    private Animator animator;
    //private bool isDead = false;

    public GameObject respawnPosition;
    

    // Start is called before the first frame update
    void Start() {
        healthPoints = initialHealthPoints;

        animator = gameObject.GetComponent<Animator>();
        
    }

    public void doHarm(int doDamageByThisMuch) {
        healthPoints -= doDamageByThisMuch;

        if (healthPoints <= 0) {
            //isDead = true; //beh�vs egentligen inte rn, men kan beh�lla variabeln f�r ifall jag tex vill g�ra s� att spelaren inte ska kunna g� d� etc
            //animator.SetTrigger("IsDead");
            animator.SetBool("IsDead", true);
            //Invoke("stopDeathAnimation", 1f);
            Invoke("Respawn", 1.3f);
            Debug.Log("Player is dead!");
            //Destroy(gameObject);
        }
        //else
        //{
        //animator.SetTrigger("isHurt");
        //Invoke("stopHurtAnimation", 0.4f);
        //}
    }

    public void Respawn() {
        healthPoints = initialHealthPoints;
        gameObject.transform.position = respawnPosition.transform.position;
        animator.SetBool("IsDead", false);
    }

    public void ChangeRespawnPosition(GameObject newRespawnPosition) {
        respawnPosition = newRespawnPosition;

        Debug.Log("Respawn position set to: " + respawnPosition);

        // Update the player's position immediately after setting the respawn position
        if (respawnPosition != null)
        {
            transform.position = respawnPosition.transform.position;
            Debug.Log("Player position set to respawn position: " + respawnPosition.transform.position);
        }
        else
        {
            Debug.LogWarning("Respawn position is null!");
        }
    }


    public void FoodPickup() {
        foodAmount++;
    }
}