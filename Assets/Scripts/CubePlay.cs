using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class CubePlay : MonoBehaviour
{
    private Animator animator; // cache
    private SoundManager soundManager; // cache
    private EffectManager effectManager; // cache
    //[SerializeField] private GameObject effectPrefab; 
    [SerializeField] private Transform effectPos;
    private bool isAttack = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        soundManager = FindAnyObjectByType<SoundManager>();

        //soundManager.PlaySound(2, false);
        //Invoke("FadeOutSound", 3f);

        //Instantiate(effectPrefab, effectPos);

        effectManager = FindAnyObjectByType<EffectManager>();
        effectManager.PlayEffect(0, effectPos);
    }

    private void FadeOutSound()
    {
        soundManager.Fadeout(2);
    }
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontal) > Mathf.Epsilon)
        {
            MoveState();
        }
        else
        {
            IdleState();
        }

        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            AttackState();
        }
    }

    private void MoveState()
    {
        if (!isAttack)
        {
            animator.Play("Mov");
            soundManager.PlaySound(0, false);
        }
    }

    private void IdleState()
    {
        if (!isAttack)
            animator.Play("Idle");
    }

    private void AttackState()
    {
        isAttack = true;
        animator.Play("Attack");
        soundManager.PlaySound(1, true);

        StartCoroutine(C_AttackStateFinish());
    }

    private IEnumerator C_AttackStateFinish()
    {
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
    }
}
