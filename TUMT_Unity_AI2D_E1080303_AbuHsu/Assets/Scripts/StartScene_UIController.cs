using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartScene_UIController : MonoBehaviour
{
    [SerializeField]
    GameObject sound;

    [SerializeField]
    Animator soundAnim;

    [SerializeField]
    AudioMixer mixer;

    public void OnSetBGM(float value)
    {
        mixer.SetFloat("BGM", value);
    }

    public void OnSetFX(float value)
    {
        mixer.SetFloat("FX", value);
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnSettiongButtonClick()
    {
        bool isopen = soundAnim.GetBool("IsOpen");
        soundAnim.SetBool("IsOpen", isopen ? false : true);
    }

    private void Start()
    {
        DontDestroyOnLoad(sound);
    }
}
