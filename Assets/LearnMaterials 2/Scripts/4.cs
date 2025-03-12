using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : SampleScript
{
    [SerializeField] private Vector3 rotationAngles;
    [SerializeField] private float rotationSpeed = 10f;

    public override void Use()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles + rotationAngles);
        float time = 0f;
        float duration = rotationAngles.magnitude / rotationSpeed;

        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
