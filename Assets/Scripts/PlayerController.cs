using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    Rigidbody rb; // cache
    EnemyManager enemyManager;
    private bool isGround = false;
    CameraShake cameraShake; // cache

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Debug.Log(transform.position);

        rb = GetComponent<Rigidbody>();
        enemyManager = FindAnyObjectByType<EnemyManager>();
        cameraShake = FindAnyObjectByType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        //// 1
        //foreach (var item in enemyManager.Enemies)
        //{
        //    float distance = Vector3.Distance(transform.position, item.transform.position);
        //    if (distance <= 3f)
        //    {
        //        item.Attack();
        //    }
        //}

        //Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);
        //foreach (Collider collider in colliders)
        //{
        //    if (collider.gameObject.tag == "Enemy")
        //    {
        //        collider.GetComponent<EnemyController>().Attack();
        //    }
        //}

    }

    float yRotation = 0;
    float xRotation = 0;

    void Movement()
    {
        //transform.position += new Vector3(0.1f, 0, 0.1f) * Time.deltaTime * speed;

        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //Debug.Log($"{horizontal}, {vertical}");

        //Vector3 mov = new Vector3(horizontal, 0, vertical);
        //Vector3 movNormalized = mov.normalized * Time.deltaTime * speed;
        ////transform.position += movNormalized;
        //transform.Translate(movNormalized);

        //Vector3 mov = new Vector3(horizontal, 0, vertical);
        //Vector3 movNormalized = mov.normalized * speed;
        //rb.linearVelocity = new Vector3(movNormalized.x, rb.linearVelocity.y, movNormalized.z);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(horizontal, 0, vertical); // 1, 0, 0 
        Vector3 worldPos = transform.TransformDirection(mov); // to world
        transform.Translate(worldPos * Time.deltaTime * 10f, Space.World);

        // 화면 회전
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * 100;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 100;
        //Debug.Log($"{mouseX},  {mouseY}");

        yRotation += mouseX;
        xRotation -= mouseY;
        transform.rotation = Quaternion.Euler(Mathf.Clamp(xRotation, -90, 90), yRotation, 0);

        if (Input.GetButtonDown("Jump") && isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 5f, rb.linearVelocity.z);
        isGround = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        //if (collision.gameObject.tag == "Enemy")
        //{
        //    EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
        //    enemyController.Attack();
        //}

        if (collision.gameObject.name == "Plane")
        {
            isGround = true;
        }
    }

    public void Warning()
    {
        Debug.Log("Player Warning");
    }

    public void Attack()
    {
        Debug.Log("Player Attack");
        cameraShake.Shake(0.1f, 0.01f);
    }
}
