using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraShake : MonoBehaviour
{
    Camera camera; // cache
    Vector3 originPos;

    void Start()
    {
        camera = camera.GetComponent<Camera>();
        originPos = camera.transform.localPosition;
    }

    public void Shake(float second, float magnitude)
    {
        StopCoroutine("C_Shake");
        ResetPostion();
        StartCoroutine(C_Shake(second, magnitude));
    }

    private IEnumerator C_Shake(float second, float magnitude)
    {
        float time = 0;
        while (true)
        {
            if (time >= second)
            {
                break;
            }

            Vector3 offset = Random.insideUnitCircle * magnitude;
            transform.localPosition += new Vector3(offset.x, offset.y, 0f);

            time += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originPos;
    }

    private void ResetPostion()
    {
        transform.localPosition = originPos;
    }
}
