using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject prefabBody;// unused object

    public float timer = 0;
    public float speed = 1;
    private float screenWidth = 0;
    private float screenHeigth = 0;
    int headRot = 0;

    private bool is_eaten = false;

    public int HeadRot { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        screenHeigth = 30;
        screenWidth = (Screen.width / (Screen.height / screenHeigth)) + 1.0f;

        this.Move();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed * timer > 1)
        {
            this.Move();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    // 
    void Move()
    {
        Head head = GetComponentInChildren<Head>();
        Body body = GetComponentInChildren<Body>();
        Tail tail = GetComponentInChildren<Tail>();
        
        if (headRot == 0 && head.transform.position.x + 2.0f < screenWidth)
        {
            Vector3 new_body_position = head.transform.position;
            Vector3 new_tail_position = body.transform.position;
            Vector3 new_head_position = new Vector3(head.transform.position.x + 2.0f, head.transform.position.y, head.transform.position.z);

            Instantiate(prefabBody, head.transform.position, Quaternion.identity, transform);

            // move head
            head.transform.position = new_head_position;
            // move body
            body.transform.position = new_body_position;
            // move tail
            tail.transform.position = new_tail_position;

            Destroy(body.gameObject);
        }


        if (headRot == 90 && head.transform.position.y + 2.0f < screenHeigth)
        {
            Instantiate(prefabBody, head.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            head.transform.position = new Vector3(head.transform.position.x,
                                                head.transform.position.y + 2.0f,
                                                head.transform.position.z);
            MoveBody();
        }

        if (headRot == 180 && head.transform.position.x - 2.0f > -screenHeigth)
        {
            Instantiate(prefabBody, head.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            head.transform.position = new Vector3(head.transform.position.x - 2.0f,
                                                head.transform.position.y,
                                                head.transform.position.z);

            MoveBody();
        }

        if (headRot == 270 && head.transform.position.y - 2.0f > -screenHeigth)
        {
            Instantiate(prefabBody, head.transform.position, Quaternion.Euler(0, 0, headRot), transform);
            head.transform.position = new Vector3(head.transform.position.x,
                                                head.transform.position.y - 2.0f,
                                                head.transform.position.z);
            MoveBody();
        }
    }


    public void Eat()
    {
        is_eaten = true;
    }

    void MoveBody()
    {
        if (!is_eaten){
            Body[] body = GetComponentsInChildren<Body>();
            Tail tail = GetComponentInChildren<Tail>();

            tail.transform.rotation = body[0].transform.rotation;
            tail.transform.position = body[0].transform.position;

            Destroy(body[0].gameObject);

        } else {
            is_eaten = false;
        }

    }



    public void Right()
    {

    }
    public void Left()
    {
        
    }
    public void Up()
    {
        Head head = GetComponentInChildren<Head>();

        if (HeadRot == 0 || headRot == 180) {
            head.transform.position = new Vector3(head.transform.position.x,
                                                head.transform.position.y + 2.0f,
                                                head.transform.position.z);
        }
    }
    public void Down()
    {
       
    }


}
