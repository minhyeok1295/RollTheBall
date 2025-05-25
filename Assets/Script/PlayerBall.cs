using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    bool isJumping;
    public GameManagerLogic manager;
    Rigidbody rigid;
    public int itemCount;
    AudioSource audioSource;
    public float movePower = 5f;

    void Awake() {
        isJumping = false;
        rigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump") && !isJumping) {
            isJumping = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // Vector3 moveDir = new Vector3(h, 0, v).normalized;
        // rigid.linearVelocity = moveDir * movePower + new Vector3(0, rigid.linearVelocity.y, 0);
        rigid.AddForce(new Vector3(h, 0, v) * movePower, ForceMode.Force);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Floor") {
            isJumping = false;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Item") {
            Debug.Log("Item collected");
            itemCount++;
            manager.GetItem(itemCount);
            audioSource.Play();
            other.gameObject.SetActive(false);
        } else if (other.gameObject.tag == "Point") {
            Debug.Log("Reached Point");
            Debug.Log("Item count: " + itemCount);
            Debug.Log("Total item count: " + manager.totalItemCount);
            if (manager.totalItemCount == itemCount) {
                if (manager.stage == 3){
                    Debug.Log("Cleared all levels!!");
                    SceneManager.LoadScene(0);
                } else {
                    SceneManager.LoadScene(manager.stage + 1);
                }
            } else {
                // Restart
                Debug.Log("Restarting level " + (manager.stage).ToString());
                SceneManager.LoadScene(manager.stage);
            }
        }
    }
}
