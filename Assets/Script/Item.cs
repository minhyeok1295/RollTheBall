using UnityEngine;

public class Item : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 80 * Time.deltaTime, Space.World);
    }

}
