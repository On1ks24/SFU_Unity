using UnityEngine;

public class MoveScript : SampleScript
{
    public float speed = 1f;
    public Vector3 targetPosition = new Vector3(3, 0, 0);
    private Vector3 startPosition;
    private float journeyLength;
    private float startTime;

    void Start()
    {
        startPosition = transform.position;
        journeyLength = Vector3.Distance(startPosition, targetPosition);
    }

    public override void Use()
    {
        startTime = Time.time;
        StartCoroutine(MoveObject());
    }

    private System.Collections.IEnumerator MoveObject()
    {
        while (transform.position != targetPosition)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            yield return null;
        }
    }
}
