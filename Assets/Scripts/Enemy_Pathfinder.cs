using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.EventSystems;

public class Enemy_Pathfinder : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private GameObject returnPoint;
    [SerializeField] private GameObject player;
    //[SerializeField] private Transform enemyGFX;
    [SerializeField] private float speed = 200f;
    [SerializeField] private float nextWayPointDistance = 3f;
    private Path path;
    private int currentWayPoint = 0;
    private bool reachedEndOfPath = false;
    private Seeker seeker;
    private Rigidbody2D rb;
    private bool isPlayerClose = false;
    [SerializeField] private BoxCollider2D returnPointCollider;

    [SerializeField] private Animator animator;
    [SerializeField] private bool isAlive = true;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip clip;
    private float movementDirection = 1f;
    private float moveDirection = 0f;

    // Start is called before the first frame update
    void Start() {
        isAlive = true;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        //Startpositionen är där vi befinner oss, slutdestinationen är där target befinner sig, funktionen skapar vi
    }

    private void Update() {
        //animator.SetBool("IsAlive", isAlive);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void OnPathComplete(Path p) {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0; //Startar i början av vår nya path
        }
    }

    void FixedUpdate() {
        if (isAlive) { //isPlayerClose?
            if (isPlayerClose) {
                target = player.transform;
            }
            else {
                //target = birdnest.transform;
                target = returnPointCollider.transform;
            }

            //target = player.transform;
            if (path == null) {
                return;
            }

            if (currentWayPoint >= path.vectorPath.Count) {
                reachedEndOfPath = true;
                return;
            }
            else {
                reachedEndOfPath = false;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

            if (distance < nextWayPointDistance) {
                currentWayPoint++;
            }

            if (force.x >= 0.01f) {
                gameObject.transform.localScale = new Vector3(-movementDirection, 1f, 1f);
            }
            else if (force.x <= -0.01f) {
                gameObject.transform.localScale = new Vector3(movementDirection, 1f, 1f);
            }
        }

        //if (isPlayerClose == false) {
        //    ReturnToHome();
        //}
    }


    private void UpdatePath() {
        if (seeker != null) {
            if (seeker.IsDone()) {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") == true) {
            if (collision.gameObject.GetComponent<Player_Movement>().IsFalling() == true) {
                KillMe();
            }
        }
    }

    public void KillMe() {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //animator.SetTrigger("IsDead");
        isAlive = false;
        Vector2 killForce = new Vector2(movementDirection, 4f);
        rb.AddForce(killForce, ForceMode2D.Impulse);
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, -gameObject.transform.localScale.y);
        audioS.PlayOneShot(clip);
        Destroy(gameObject, 0.5f);
    }

    public void GetPlayerCloseBy(bool tempIsPlayerClose) {
        isPlayerClose = tempIsPlayerClose;
    }

    public bool GetAliveStatus() {
        return isAlive;
    }
}

//private void ReturnToHome() {
//    target = birdnest.transform;
//    currentWayPoint = 0; // reset currentWayPoint
//    //UpdatePath(); // generate new path to eg birdnest
//    seeker.StartPath(rb.position, target.position, OnPathComplete);
//}