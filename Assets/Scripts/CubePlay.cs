using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class CubePlay : MonoBehaviour
{
    private Animator animator; // cache
    private bool isAttack = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontal) > Mathf.Epsilon)
        {
            if (!isAttack)
                animator.Play("Mov");
        }
        else
        {
            if (!isAttack)
                animator.Play("Idle");
        }

        if (Input.GetKeyDown(KeyCode.A)) 
        {
            AttackState();
        }
    }

    private void AttackState()
    {
        isAttack = true;
        animator.Play("Attack");
        StartCoroutine(C_AttackStateFinish());
    }

    private IEnumerator C_AttackStateFinish()
    {
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
    }
}
