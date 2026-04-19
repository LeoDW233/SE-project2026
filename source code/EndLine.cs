using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLine : MonoBehaviour
{

    public GameObject gameOverUI; // 拖拽Game Over的UI面板到此

    // 玩家触碰死亡线时触发
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameOverUI.SetActive(true); // 显示UI
            Time.timeScale = 0f;        // 暂停游戏（可选）
        }
    }

    // UI按钮点击事件（直接在Unity编辑器中绑定）
    public void RestartGame()
    {
        Time.timeScale = 1f;             // 恢复时间
        SceneManager.LoadScene(0);       // 重新加载第一个场景
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
