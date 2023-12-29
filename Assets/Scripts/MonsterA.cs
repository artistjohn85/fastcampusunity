using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterA : MonoBehaviour
{
    [SerializeField][Range(10f, 20f)] private float speed = 10f;

    void Start()
    {
    }

    private void OnEnable()
    {
        StartCoroutine(C_DisableObj());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private IEnumerator C_DisableObj()
    {
        yield return new WaitForSeconds(2f);
        // Destroy(this.gameObject);
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
    }
}
