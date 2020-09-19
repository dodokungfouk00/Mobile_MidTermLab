using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    public float increment;
    public float maxY;
    public float minY;

    private Vector2 targetPos;

    public int health;

    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;

    public GameObject spawner;
    public GameObject restartDisplay;
    public Camera cam;
    Vector3 startPoint;
    Vector3 endPoint;

    private void Update()
    {
        //gameover
        if (health <= 0)
        {
            spawner.SetActive(false);
            restartDisplay.SetActive(true);
            Destroy(gameObject);
            ScoreManager.instance.ResetScore();
            health=0;
            
            
        }


        healthDisplay.text = health.ToString();

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        //Keyboard Input
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY)
        {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y + increment);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY)
        {
            camAnim.SetTrigger("shake");
            Instantiate(moveEffect, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - increment);
        }
        //mobile Input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = cam.ScreenToViewportPoint(touch.position);
            if (touch.phase == TouchPhase.Began) //starting touching
            {
                startPoint = touchPos;
                Debug.Log(startPoint);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                endPoint = touchPos;
                Debug.Log(endPoint);
                if (startPoint.y > endPoint.y && transform.position.y > minY ) 
                {
                    camAnim.SetTrigger("shake");
                    Instantiate(moveEffect, transform.position, Quaternion.identity);
                    targetPos = new Vector2(transform.position.x, transform.position.y - increment);
                }
                if (startPoint.y < endPoint.y && transform.position.y < maxY )
                {
                    camAnim.SetTrigger("shake");
                    Instantiate(moveEffect, transform.position, Quaternion.identity);

                    targetPos = new Vector2(transform.position.x, transform.position.y + increment);
                }
            }

        }






    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dead"))
        {
            health -= 100;
        }
        if (other.CompareTag("Health"))
        {
            health += 2;
        }
        if (other.CompareTag("RedBall"))
        {
            health -= 1;
        }
    }
}
