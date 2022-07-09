using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void OnClickRestartButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
