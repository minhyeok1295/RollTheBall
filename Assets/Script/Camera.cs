using UnityEngine;

public class Camera : MonoBehaviour
{

    Transform playerTransform;
    Vector3 offset;

    void Awake() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTransform.position;
    }

    void LateUpdate() {
        transform.position = playerTransform.position + offset;
    }
}
