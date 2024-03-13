using UnityEngine;
using UnityEngine.Events;

public class PickUpFood : MonoBehaviour
{
    [SerializeField] private GameObject food;
    //public bool pickedUpFood = false;
    public int foodAmount = 0;
    [SerializeField] private SpriteRenderer spriteRenderer;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            collision.GetComponent<PlayerState>().FoodPickup();
            spriteRenderer.enabled = false;
            foodAmount++;

           // pickedUpFood = true;
            
            DestroyFood();


        }
    }
    void DestroyFood()
    {

        Destroy(food);
    }
}

