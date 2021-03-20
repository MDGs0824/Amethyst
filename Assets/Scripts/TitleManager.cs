using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject fullTitle;
    [SerializeField] GameObject storyMode;
    [SerializeField] GameObject chapterSelect;
    [SerializeField] GameObject bossRush;
    [SerializeField] GameObject option;

    string mode;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void quit()
    {

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void storyModeSelect()
    {
        fullTitle.SetActive(false);
        storyMode.SetActive(true);
        chapterSelect.SetActive(false);
        bossRush.SetActive(false);
        option.SetActive(false);
        mode = "storyMode";

    }
    public void startButton()
    {
        if (mode == "storyMode")
        {
            SceneManager.LoadScene("2");
        }
        else if(mode == "bossRush")
        {
            Debug.Log("BossRush");
            //bossrushへ
        }

    }
    public void chapterSelectSelect()
    {
        fullTitle.SetActive(false);
        storyMode.SetActive(false);
        chapterSelect.SetActive(true);
        bossRush.SetActive(false);
        option.SetActive(false);
    }
    public void startChapter1()
    {
        SceneManager.LoadScene("2");
    }
    public void startChapter2()
    {
        SceneManager.LoadScene("9");
    }
    public void startChapter3()
    {
        SceneManager.LoadScene("16");
    }
    public void startChapter4()
    {
        SceneManager.LoadScene("24");
    }
    public void startChapter5()
    {
        SceneManager.LoadScene("29");
    }
    public void startChapter6()
    {
        SceneManager.LoadScene("39");
    }
    public void bossRushSelect()
    {
        fullTitle.SetActive(false);
        storyMode.SetActive(false);
        chapterSelect.SetActive(false);
        bossRush.SetActive(true);
        option.SetActive(false);
        mode = "bossRush";
    }

    public void optionSelect()
    {
        fullTitle.SetActive(false);
        storyMode.SetActive(false);
        chapterSelect.SetActive(false);
        bossRush.SetActive(false);
        option.SetActive(true);
    }
    public void BackFulltitle()
    {
        fullTitle.SetActive(true);
        storyMode.SetActive(false);
        chapterSelect.SetActive(false);
        bossRush.SetActive(false);
        option.SetActive(false);
    }
     
  
}
