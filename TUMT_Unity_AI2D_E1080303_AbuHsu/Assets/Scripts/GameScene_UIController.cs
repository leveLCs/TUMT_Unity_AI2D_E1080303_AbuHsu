using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScene_UIController : MonoBehaviour {

    public static GameScene_UIController instance;

    [SerializeField]
    Text txtTime;
    [SerializeField]
    Text txtVCount;

    [SerializeField]
    Text txtBestTime;
    [SerializeField]
    Text txtCTime;

    [SerializeField]
    Slider sliHp;

    [SerializeField]
    Animator bloodAnim;
    [SerializeField]
    Animator winAnim;
    [SerializeField]
    Animator endAnim;

    float timer;

    private void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        PlayerController.instance.OnDamaged += OnDanage;
        PlayerController.instance.OnWin += OnWin;
        PlayerController.instance.OnDeath += OnEnd;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        txtTime.text = "Time " + timer.ToString("000");
        txtVCount.text = "V 10/" + PlayerController.instance.vCount;
    }

    public void OnRetryClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuitClick()
    {
        SceneManager.LoadScene("StartScene");
    }

    void OnWin()
    {
        Time.timeScale = 0;
        float bTime = PlayerPrefs.GetFloat("Score", 0);
        if (bTime == 0 || bTime > timer) 
        {
            PlayerPrefs.SetFloat("Score", timer);
            txtBestTime.text = "Best Time "+timer.ToString("000");
        }
        else
        {
            txtBestTime.text = "Best Time "+bTime.ToString("000");
        }
        txtCTime.text = "Current Time"+timer.ToString("000");

        winAnim.SetTrigger("OnOpen");
    }

    void OnEnd()
    {
        Time.timeScale = 0;

        endAnim.SetTrigger("OnOpen");
    }

    void OnDanage()
    {
        float hpV = (PlayerController.instance.currentHp / PlayerController.instance.hp);
        sliHp.value = (hpV);
        bloodAnim.SetTrigger("OnDamage");
    }

}
