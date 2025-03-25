using UnityEngine;

public class DeleteChildrenScript : SampleScript
{
    public Transform target;
    public float shrinkSpeed = 1f;

    public override void Use()
    {
        foreach (Transform child in target)
        {
            StartCoroutine(ShrinkAndDestroy(child));
        }
    }

    private System.Collections.IEnumerator ShrinkAndDestroy(Transform child)
    {
        Vector3 originalScale = child.localScale;
        while (child.localScale.x > 0)
        {
            child.localScale -= originalScale * shrinkSpeed * Time.deltaTime;
            yield return null;
        }
        Destroy(child.gameObject);
    }
}
