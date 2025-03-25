using UnityEngine;

public class RotateScript : SampleScript
{
    public float rotationSpeed = 10f;
    public Vector3 targetRotation = new Vector3(0, 90, 0);
    private Quaternion startRotation;
    private Quaternion endRotation;
    private float startTime;

    void Start()
    {
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(targetRotation);
    }

    public override void Use()
    {
        startTime = Time.time;
        StartCoroutine(RotateObject());
    }

    private System.Collections.IEnumerator RotateObject()
    {
        while (transform.rotation != endRotation)
        {
            float t = (Time.time - startTime) * rotationSpeed / 90f;
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
            yield return null;
        }
    }
}
