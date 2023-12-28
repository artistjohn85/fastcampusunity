using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public enum CUBE_PLAY_STATE_TYPE
{
    idle,
    move,
    attack,
}

public class CubePlay : MonoBehaviour
{
    private Animator animator; // cache
    private SoundManager soundManager; // cache
    private EffectManager effectManager; // cache
    //[SerializeField] private GameObject effectPrefab; 
    [SerializeField] private Transform effectPos;
    private bool isAttack = false;

    private CUBE_PLAY_STATE_TYPE currentState = CUBE_PLAY_STATE_TYPE.idle;

    public bool IsMove
    {
        get
        {
            return currentState != CUBE_PLAY_STATE_TYPE.attack;
        }
    }

    public bool IsIdle
    {
        get
        {
            return currentState != CUBE_PLAY_STATE_TYPE.attack;
        }
    }

    public bool IsDuplacationState
    {
         get
        {
            return currentState == CUBE_PLAY_STATE_TYPE.attack;
        }
    }


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
            if (IsMove)
                ChangeState(CUBE_PLAY_STATE_TYPE.move);
        }
        else
        {
            if (IsIdle)
                ChangeState(CUBE_PLAY_STATE_TYPE.idle);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeState(CUBE_PLAY_STATE_TYPE.attack);
        }

        UpdateState();
    }

    private void UpdateState()
    {
        switch (currentState)
        {
            case CUBE_PLAY_STATE_TYPE.idle:
                IdleUpdateState();
                break;
            case CUBE_PLAY_STATE_TYPE.move:
                MoveUpdateState();
                break;
            case CUBE_PLAY_STATE_TYPE.attack:
                AttackUpdateState();
                break;
        }
    }

    public void ChangeState(CUBE_PLAY_STATE_TYPE stateType)
    {
        if (!IsDuplacationState)
        {
            if (this.currentState == stateType)
                return;
        }

        this.currentState = stateType;

        switch (currentState)
        {
            case CUBE_PLAY_STATE_TYPE.idle:
                IdleEnterState();
                break;
            case CUBE_PLAY_STATE_TYPE.move:
                MoveEnterState();
                break;
            case CUBE_PLAY_STATE_TYPE.attack:
                AttackEnterState();
                break;
        }
    }

    private void MoveEnterState()
    {

    }

    private void MoveUpdateState()
    {
        if (IsMove)
        {
            animator.Play("Mov");
            soundManager.PlaySound(0, false);
        }
    }

    private void IdleEnterState()
    {
    }

    private void IdleUpdateState()
    {
        if (IsIdle)
            animator.Play("Idle");
    }

    private void AttackEnterState()
    {
        animator.Play("Attack");
        soundManager.PlaySound(1, true);

        StartCoroutine(C_AttackStateFinish());
    }

    private void AttackUpdateState()
    {
       
    }

    private IEnumerator C_AttackStateFinish()
    {
        yield return new WaitForSeconds(1.5f);
        ChangeState(CUBE_PLAY_STATE_TYPE.idle);
    }
}
