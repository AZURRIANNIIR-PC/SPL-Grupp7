using UnityEngine;
using UnityEngine.Events;

public class PickUpFood : MonoBehaviour {
    [SerializeField] private GameObject food;
    //public bool pickedUpFood = false;
    public int foodAmount = 0;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start() {
        Debug.Log("food amount is" + foodAmount);
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") == true) {
            collision.GetComponent<PlayerState>().FoodPickup();
            spriteRenderer.enabled = false;
            foodAmount++;

            DestroyFood();
        }
    }


    void DestroyFood() {
        Destroy(food);
    }
}