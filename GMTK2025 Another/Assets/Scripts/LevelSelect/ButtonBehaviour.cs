using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private int levelID;
    private Image img;

    private Button button;

    void Awake()
    {
        img = GetComponent<Image>();
        button = GetComponent<Button>();

        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);

        if (levelID <= unlockedLevels)
        {
            img.color = Color.white;
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            img.color = Color.black;
            button.onClick.RemoveAllListeners();
        }

        transform.GetChild(0).GetComponent<TMP_Text>().text = levelID.ToString();
    }

    public void OnButtonClick()
    {
        LevelSelectManager.Instance.LoadLevel(levelID);
    }
}
