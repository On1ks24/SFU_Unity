using UnityEngine;

public class InstantiateScript : SampleScript
{
    public GameObject prefab;
    public int count = 5;
    public float step = 1f;

    public override void Use()
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 position = new Vector3(i * step, 0, 0);
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
