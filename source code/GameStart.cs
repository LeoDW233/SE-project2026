using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject player; // 拖拽玩家对象到此字段
    public void OnStartButtonClick()
    {
       // SceneManager.LoadScene("GameScene"); // 替换为你的游戏场景名称
        player.SetActive(true);  // 显示玩家
        Time.timeScale = 1f;
        gameObject.SetActive(false); // 隐藏开始界面
    }

    // 点击「退出游戏」按钮时调用（可选）
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false); // 初始隐藏玩家
        Time.timeScale = 0f;        // 暂停游戏（可选）
    }


    // Update is called once per frame
    void Update(){
        
    }
}
