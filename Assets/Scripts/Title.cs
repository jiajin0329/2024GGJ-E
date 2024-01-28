using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    [SerializeField] Button start;
    [SerializeField] Button exit;

    private void Start()
    {
        start.onClick.AddListener(() =>
        {
            SceneManager.LoadSceneAsync(1);
        });

        start.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
