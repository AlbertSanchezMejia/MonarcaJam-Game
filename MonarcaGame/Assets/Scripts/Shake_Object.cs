using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake_Object : MonoBehaviour
{
    [SerializeField] float shakeTime = 1.0f;
    [SerializeField] float shakeDistance = 0.25f;
    [SerializeField] Transform objectToShake;
    Vector3 startPosition;

    void Start()
    {
        startPosition = objectToShake.localPosition;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartShake();
        }
    }
    public void StartShake()
    {
        StopAllCoroutines();
        StartCoroutine(C_ShakeObject(shakeTime));
    }

    IEnumerator C_ShakeObject(float shakeCount)
    {
        while (shakeCount > 0)
        {
            objectToShake.localPosition = startPosition + Random.insideUnitSphere * shakeDistance;
            shakeCount -= Time.deltaTime;
            yield return null;
        }

        ObjectBackToNormal();
    }

    void ObjectBackToNormal()
    {
        objectToShake.localPosition = startPosition;
    }



}
