using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowEffect : MonoBehaviour
{
    Rigidbody2D body1;
    Rigidbody2D body2;
    Vector2 movementDirection;
    Vector2 movementDirection1;
    GameObject ArrowObjectVerti;
    GameObject ArrowObjectHori;

    [SerializeField] float accelerationPower;
    public float speed;
    
    private void setVerObstaclePosition(float[] posX)
    {
        ArrowObjectHori.transform.position = 
            Camera.main.ViewportToWorldPoint(new Vector3(posX[Random.Range(0, posX.Length)], Random.Range(-0.05f, 1.05f), Camera.main.nearClipPlane + 15f));
    }
    private void setHorObstaclePosition(float[] posY)
    {
        ArrowObjectVerti.transform.position =
            Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(-0.05f, 1.05f), posY[Random.Range(0, posY.Length)], Camera.main.nearClipPlane + 15f));


    }
    public void setMovementOne(Vector2 ArrowPosition,float low, float high)
    {
        if (ArrowPosition.y > high)
        {
            movementDirection = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), -1f, 0f));
        }
        else if (ArrowPosition.y < low)
        {
            movementDirection = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 1f, 0f));
        }
    }
    public void setMovementTwo(Vector2 ArrowPosition,float low, float high)
    {
        if (ArrowPosition.x > high)
        {
            movementDirection1 = Camera.main.ViewportToWorldPoint(new Vector3(-1f,Random.Range(0f, 1f), 0f));
        }
        else if (ArrowPosition.x < low)
        {
            movementDirection1 = Camera.main.ViewportToWorldPoint(new Vector3(1f,Random.Range(0f, 1f), 0f));
        }
    }
    private void Start()
    {
        ArrowObjectVerti = GameObject.Find("Obstacle_Template");
        ArrowObjectHori = GameObject.Find("Obstacle_Template_Hori");
        float[] pos = new float[] { -0.1f, 1.1f };
        body1 = ArrowObjectVerti.GetComponent<Rigidbody2D>();
        body2 = ArrowObjectHori.GetComponent<Rigidbody2D>();
        setHorObstaclePosition(pos);
        setVerObstaclePosition(pos);
        Vector2 ArrowPosition = Camera.main.WorldToViewportPoint(body1.transform.position);
        Vector2 ArrowPositionTwo = Camera.main.WorldToViewportPoint(body2.transform.position);
        setMovementOne(ArrowPosition,0f,1f);
        //setMovementTwo(ArrowPositionTwo, 0f , 1f);
    }

    private void Update()
    {
        bool t = false;

        Vector2 ArrowPosition = Camera.main.WorldToViewportPoint(body1.transform.position);
        Vector2 ArrowPositionTwo = Camera.main.WorldToViewportPoint(body2.transform.position);

        float yTop = 1.2f, yBottom = -0.25f, xRight = 1.05f, xLeft = -0.05f;
        float[] pos = new float[] { -0.1f, 1.1f };
            if (ArrowPosition.x < xLeft || ArrowPosition.x > xRight || (ArrowPosition.y < yBottom) || (ArrowPosition.y > yTop))
            {
                setHorObstaclePosition(pos);
                movementDirection = Vector2.zero;
                setMovementTwo(ArrowPositionTwo, 0f, 1f);
            }
            else
            {
                movementDirection.Normalize();
                body1.transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
                if (movementDirection != Vector2.zero)
                {
                    body1.transform.up = movementDirection;
                }
            }
        
      
            if (ArrowPositionTwo.x < -2 || ArrowPositionTwo.x > xRight || (ArrowPositionTwo.y < yBottom) || (ArrowPositionTwo.y > yTop))
            {
                setVerObstaclePosition(pos);
                movementDirection1 = Vector2.zero;
                setMovementOne(ArrowPositionTwo, 0f, 1f);

            }
            else
            {
                movementDirection1.Normalize();
                body2.transform.Translate(movementDirection1 * speed * Time.deltaTime, Space.World);
                if (movementDirection1 != Vector2.zero)
                {
                    body2.transform.up = movementDirection1;
                }
            }
        
      


    }

    private void FixedUpdate()
    {


    }
}
