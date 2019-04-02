using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    GameObject LP, RP;

    Vector2 Direction;
    Vector3 LPP, RPP;
    Rigidbody rb;
    float moveSpeed = 10f;

    int LScore = 0, RScore = 0;

    public Text L, R, W;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        LPP = LP.transform.position;
        RPP = RP.transform.position;
        RandomizeDirection();
        rb.velocity = Direction * moveSpeed;
        L.text = "Score: " + LScore.ToString();
        R.text = "Score: " + RScore.ToString();
        W.text = "";
    }

    private void Update()
    {

        L.text = "Score: " + LScore.ToString();
        R.text = "Score: " + RScore.ToString();

        if (LScore == 10 || RScore == 10)
        {
            GameEnd();
        }
    }

    void RandomizeDirection()
    {
        if (Random.value < 0.5f)
        {
            if (Random.value < 0.5f)
                Direction = new Vector2(1, 1).normalized;
            else
                Direction = new Vector2(1, -1).normalized;
        }
        else
        {
            if (Random.value < 0.5f)
                Direction = new Vector2(-1, 1).normalized;
            else
                Direction = new Vector2(-1, -1).normalized;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Top")
        {
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
        }
        if (other.tag == "Bottom")
        {
            rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
        }
        if (other.tag == "Left")
        {
            RScore++;
            if (Random.value < 0.5f)
                Direction = new Vector2(-1, 1).normalized;
            else
                Direction = new Vector2(-1, -1).normalized;
            Resetting();
        }
        if (other.tag == "Right")
        {
            LScore++;
            if (Random.value < 0.5f)
                Direction = new Vector2(1, 1).normalized;
            else
                Direction = new Vector2(1, -1).normalized;
            Resetting();
        }
        if (other.tag == "LP")
        {
            if (transform.position.x - LP.transform.position.x > 0.75f)
            {
                rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z);
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
            }
        }
        if (other.tag == "RP")
        {
            if (-transform.position.x + RP.transform.position.x > 0.75f)
            {
                rb.velocity = new Vector3(-rb.velocity.x, rb.velocity.y, rb.velocity.z);
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, -rb.velocity.y, rb.velocity.z);
            }
        }
    }

    private void Resetting()
    {
        transform.position = new Vector3(0, 0, 0);
        LP.transform.position = LPP;
        RP.transform.position = RPP;
        rb.velocity = Direction * moveSpeed;
    }

    void GameEnd()
    {
        rb.velocity = new Vector3(0, 0, 0);
        if (LScore == 10)
        {
            L.text = "";
            R.text = "";
            W.text = "Left Wins with a lead of " + (LScore - RScore).ToString();
        }
        else
        {
            L.text = "";
            R.text = "";
            W.text = "Right Wins with a lead of " + (RScore - LScore).ToString();
        }

        if (Input.GetKey(KeyCode.R))
        {
            LScore = RScore = 0;
            LP.transform.position = LPP;
            RP.transform.position = RPP;
            RandomizeDirection();
            rb.velocity = Direction * moveSpeed;
            L.text = "Score: " + LScore.ToString();
            R.text = "Score: " + RScore.ToString();
            W.text = "";
        }
    }
}
