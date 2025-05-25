using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCount;
    public int stage;
    public TMP_Text stageCountText;
    public TMP_Text playerCountText;

    void Awake() {
        stageCountText.text = "/ " + totalItemCount.ToString();
    }

    public void GetItem(int count) {
        playerCountText.text = count.ToString();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            SceneManager.LoadScene(stage);
        }
    }
}
