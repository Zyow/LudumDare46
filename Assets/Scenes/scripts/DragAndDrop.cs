using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{

    Rigidbody2D rb;

    public bool isDragging;
    public bool isCollided = false;

    public bool onAObject = false;
    public GameObject onThisGO = null;

    private Vector2 initPosition;
    private float deltaX, deltaY;

    public AudioSource audioData;

    private void Start() {
        initPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        audioData = GetComponent<AudioSource>();
    }

    private void OnMouseDown() {
        isDragging = true;
    }

    private void OnMouseDrag() {
          if( isDragging )
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            rb.MovePosition(mousePosition);
        }
    }

    private void OnMouseUp() {
        isDragging = false;

        if(!isCollided)
            RestartPosition();

    }

    private void CallAction(){
        
    }

    private void RestartPosition()
    {
        transform.position = initPosition;
    }

    public void OnObject(){
        onAObject = true;
    }

    public void ExitObject(){
        onAObject = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Collision avec " + other.gameObject.name);
        
        if ((other.gameObject.tag == "Plant"))
        {
            Debug.Log("Collision avec " + other.gameObject.name);

        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Plant")
        {
            onThisGO = other.gameObject;
            transform.rotation = Quaternion.Euler(0, 0, 35);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log("Plus de collision avec " + other.gameObject.name);
        if (other.gameObject.tag == "Plant")
        {
            if (onThisGO != null)
            {
                onThisGO = null;
            }

            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }
}

