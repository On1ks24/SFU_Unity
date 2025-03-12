using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : SampleScript
{
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float speed = 1f;

    public override void Use()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}
