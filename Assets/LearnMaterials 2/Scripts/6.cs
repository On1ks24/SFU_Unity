using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkAndDestroyChildren : SampleScript
{
    [SerializeField] private Transform target;
    [SerializeField] private float shrinkDuration = 1f;

    public override void Use()
    {
        StartCoroutine(ShrinkAndDestroy());
    }

    private IEnumerator ShrinkAndDestroy()
    {
        foreach (Transform child in target)
        {
            StartCoroutine(Shrink(child));
        }
        yield return new WaitForSeconds(shrinkDuration);
        foreach (Transform child in target)
        {
            Destroy(child.gameObject);
        }
    }

    private IEnumerator Shrink(Transform obj)
    {
        float time = 0;
        Vector3 originalScale = obj.localScale;

        while (time < shrinkDuration)
        {
            obj.localScale = Vector3.Lerp(originalScale, Vector3.zero, time / shrinkDuration);
            time += Time.deltaTime;
            yield return null;
        }

        obj.localScale = Vector3.zero;
    }
}
