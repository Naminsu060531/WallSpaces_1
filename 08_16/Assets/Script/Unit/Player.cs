using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public static Player instance;

    public LayerMask playerLayer;
    Camera cam;
    Vector3 dragStartPos;
    public Transform firePos;
    public GameObject forceObj;
    bool isDrag;

    private void Awake()
    {
        instance = this;
        rigid = GetComponent<Rigidbody>();
        cam = Camera.main.GetComponent<Camera>();
    }

    private void Update()
    {
        Move();
        Clamp();
        DragAndMove();
    }

    public void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime;
    }

    public void Clamp()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -17, 17),
            Mathf.Clamp(transform.position.y, 0, 0),
            Mathf.Clamp(transform.position.z, -9.5f, 9.5f)
            );
    }

    public void DragAndMove()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            bool isHit = Physics.Raycast(ray, out hit, 120f, playerLayer);
            if(isHit)
            {
                dragStartPos = hit.point;
                isDrag = true;
            }
        }

        if(Input.GetMouseButtonUp(0) && isDrag)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            bool isHit = Physics.Raycast(ray, out hit, 120f);
            if(isHit)
            {
                Vector3 dir = dragStartPos - hit.point;
                dir.y = 0;
                rigid.AddForce(dir * (speed / 2), ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            OnDamage(1);
        }
    }
}
