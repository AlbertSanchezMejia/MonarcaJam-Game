using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_LoadBar : MonoBehaviour
{
    [SerializeField] GameObject loadPanel;
    [SerializeField] Slider sliderLoadBar;
    [SerializeField] GameObject menuButtons;

    public void LoadScene(int sceneIndex)
    {
        menuButtons.SetActive(false);
        loadPanel.SetActive(true);
        StartCoroutine(LoadAsync(sceneIndex));
    }

    IEnumerator LoadAsync(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while(!operation.isDone)
        {
            sliderLoadBar.value = operation.progress / 0.9f;
            yield return null;
        }
    }

}