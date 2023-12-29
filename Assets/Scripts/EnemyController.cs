using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //[SerializeField] LayerMask layerMask;

    //private int degree = 0;

    //PlayerController playerController; // cache, 1

    //private Vector3 originPos;
    //[SerializeField] Transform targetPos;
    //private float factor;

    //public void SetInit(Transform targetPos)
    //{
    //this.targetPos = targetPos;
    //}

    [SerializeField] GameObject childObj;

    private int indexMove;
    private bool isFinished = false;

    PlayerController playerController; // cache
    NavMeshAgent agent; // cache

    // Start is called before the first frame update
    void Start()
    {
        //playerController = FindAnyObjectByType<PlayerController>(); // 1
        //layerMask = 1 << LayerMask.NameToLayer("Player");
        //layerMask = 1 << 6; // 0000 0000 0000 0000 0000 0000 0010 0000
        //layerMask = 1 << 0 | 1 << 6; // 0000 0000 0000 0000 0000 0000 0000 0001 // 1 << 0
        //                             // 0000 0000 0000 0000 0000 0000 0010 0000 // 1 << 6
        //                             // 0000 0000 0000 0000 0000 0000 0010 0001 // 1 << 0 | 1 << 6

        //originPos = transform.position;

        //yield return StartCoroutine(C_MoveRight());
        //yield return new WaitForSeconds(2);
        //yield return StartCoroutine(C_MoveDown());

        //transform.position = new Vector3(5, 0, 0);
        //transform.position = transform.TransformPoint(5, 0, 0);

        //childObj.transform.position = new Vector3(5, 0, 0); //transform.TransformPoint(5, 0, 0);

        playerController = FindAnyObjectByType<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
    }

    IEnumerator C_MoveRight()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Translate(1, 0, 0);
        yield return new WaitForSeconds(1f);
        transform.Translate(1, 0, 0);
        yield return new WaitForSeconds(1.5f);
        transform.Translate(1, 0, 0);

        int index = 0;
        while(true)
        {
            if (index >= 5)
                yield break;

            yield return null;
            transform.Translate(0, 0, 1);
            index++;
        }
    }

    IEnumerator C_MoveDown()
    {
        yield return null;
        transform.Translate(0, 0, -1);
        yield return null;
        transform.Translate(0, 0, -1);
        yield return null;
        transform.Translate(0, 0, -1);
    }
    

    // Update is called once per frame
    void Update()
    {
        // 1
        //float distance = Vector3.Distance(transform.position, playerController.transform.position);
        //if (distance <= 5f)
        //{
        //    transform.LookAt(playerController.transform.position);
        //    playerController.Warning();
        //}

        // 2
        //Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);
        //foreach (Collider collider in colliders)
        //{
        //    if (collider.gameObject.tag == "Player")
        //    {
        //        //transform.LookAt(collider.transform.position);
        //        //collider.GetComponent<PlayerController>().Warning();
        //    }
        //}

        //transform.rotation *= Quaternion.Euler(0, 5, 0);
        //transform.Rotate(0, 5, 0);

        //if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo,
        //    Mathf.Infinity, layerMask))
        //{
        //    if (hitInfo.collider.gameObject.tag == "Player")
        //    {
        //        Debug.Log("HIT! " + hitInfo.collider.gameObject.name);
        //        Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        //        hitInfo.collider.GetComponent<PlayerController>().Warning();
        //    }
        //}

        //transform.position = new Vector3(Mathf.Cos(Mathf.Deg2Rad * degree), transform.position.y, Mathf.Sin(Mathf.Deg2Rad * degree));
        //degree++;

        //factor += Time.deltaTime;
        //transform.position = Vector3.Lerp(originPos, targetPos.position, factor);

        //if (indexMove <= 3)
        //{
        //    transform.Translate(1, 0, 0);
        //    indexMove++;
        //} 
        //else
        //{
        //    isFinished = true;
        //}

        //if (isFinished)
        //{
        //    transform.Translate(0, 0, -1);
        //}

        //agent.SetDestination(playerController.transform.position);

        //Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        //foreach (Collider collider in colliders)
        //{
        //    if (collider.gameObject.tag == "Player")
        //    {
        //        collider.GetComponent<PlayerController>().Attack();
        //    }
        //}
    }

    public void Attack()
    {
        Debug.Log("Enemy Attack");
    }
}
