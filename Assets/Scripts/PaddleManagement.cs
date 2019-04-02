using UnityEngine;

public class PaddleManagement : MonoBehaviour
{
    [SerializeField]
    GameObject LP, RP, Top, Bottom, Left, Right;

    [Range(10, 100)]
    public float PaddleMovementSpeed;

    float offset = 0.1f;

    void Start()
    {
        Top.transform.localScale = new Vector3(Camera.main.orthographicSize * Camera.main.aspect * 2, Top.transform.localScale.y, Top.transform.localScale.z);
        Bottom.transform.localScale = new Vector3(Camera.main.orthographicSize * Camera.main.aspect * 2, Bottom.transform.localScale.y, Bottom.transform.localScale.z);
        Left.transform.localScale = new Vector3(Left.transform.localScale.x, Camera.main.orthographicSize * 2, Left.transform.localScale.z);
        Right.transform.localScale = new Vector3(Right.transform.localScale.x, Camera.main.orthographicSize * 2, Right.transform.localScale.z);

        Top.transform.position = new Vector3(0, Camera.main.orthographicSize + Top.transform.localScale.y / 2, 0);
        Bottom.transform.position = new Vector3(0, -Camera.main.orthographicSize - Top.transform.localScale.y / 2, 0);
        Right.transform.position = new Vector3(Camera.main.orthographicSize * Camera.main.aspect + Top.transform.localScale.y / 2, 0);
        Left.transform.position = new Vector3(-Camera.main.orthographicSize * Camera.main.aspect - Top.transform.localScale.y / 2, 0);
    }
    
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W) && LP.transform.position.y + LP.transform.localScale.y / 2 + offset < Camera.main.orthographicSize && !Menu.paused)
        {
            LP.transform.position += new Vector3(0, PaddleMovementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.S) && LP.transform.position.y - LP.transform.localScale.y / 2 - offset > -Camera.main.orthographicSize && !Menu.paused)
        {
            LP.transform.position -= new Vector3(0, PaddleMovementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && RP.transform.position.y + RP.transform.localScale.y / 2 + offset < Camera.main.orthographicSize && !Menu.paused)
        {
            RP.transform.position += new Vector3(0, PaddleMovementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && RP.transform.position.y - RP.transform.localScale.y / 2 - offset > -Camera.main.orthographicSize && !Menu.paused)
        {
            RP.transform.position -= new Vector3(0, PaddleMovementSpeed * Time.deltaTime, 0);
        }
    }
}
