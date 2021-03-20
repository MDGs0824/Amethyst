using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    [SerializeField] Text textLabel;
    [SerializeField] Text nameLabel;
    [SerializeField] float textSpeed;//一文字一文字の表示する速さ


    [SerializeField] private TextAsset textFile;
    private string textData;
    private string[] splitText;

    private int nameNum = 0;
    private int currentNum = 1;

    [SerializeField] GameObject next;
    [SerializeField] GameObject nextScene;

    [SerializeField] int Act1Row;
    [SerializeField] int NextSceneRow;

    string sceneName;
    int sceneNameInt;

    // Start is called before the first frame update
    void Start()
    {
        textData = textFile.text;
        splitText = textData.Split(char.Parse("\n"));
        nameLabel.text = splitText[nameNum];
        textLabel.text = splitText[currentNum];
        StartCoroutine(TextControll());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   private IEnumerator TextControll()
    {
        int MessageCount = 0;
        textLabel.text = "";
        while (splitText[currentNum].Length > MessageCount)
        {
            nameLabel.text = splitText[nameNum];
            textLabel.text += splitText[currentNum][MessageCount];
            MessageCount++;
            yield return new WaitForSeconds(textSpeed);
        }
        if(splitText[currentNum].Length > MessageCount)
        {
            next.SetActive(false);
        }

        else if (currentNum == (NextSceneRow - 1))
        {
            nextScene.SetActive(true);
        }

        else if (currentNum == (Act1Row - 1))
        {
            Act1();
            next.SetActive(true);
        }


        else
        {
            next.SetActive(true);

        }

    }

    public void NextText()
    {
        next.SetActive(false);
        Debug.Log("NextText");
        nameNum += 2;
        currentNum += 2;
        StartCoroutine(TextControll());

    }

    public void SceneChangeToNext() //現在のシーン名を取得して、プラス１して次のシーン名（数）にして再度読みこむ。メモ用このスクリプトでは使用していない。
    {
        sceneNameInt = int.Parse(SceneManager.GetActiveScene().name);
        sceneNameInt++;
        sceneName = sceneNameInt.ToString();
        SceneManager.LoadScene(sceneName);
    }

    void Act1()
    {
        Debug.Log("Act1");
    }

}
