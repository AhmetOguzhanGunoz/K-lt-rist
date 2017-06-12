using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public InputField YRS1;
    public InputField YRS2;

    public string Yarismaci1;
    public string Yarismaci2;

    public Text CountDownText;
    public float CounterDown;
    public bool UpdateOn;

    // Use this for initialization
    void Start()
    {
        CountDownText.enabled = false;
        if(PlayerPrefs.GetString("Kazanan").Length > 0)
        {
            CountDownText.text = "Kazanan Yarısmacı " + PlayerPrefs.GetString("Kazanan");
            CountDownText.enabled = true;
        }
        PlayerPrefs.DeleteAll();
        CounterDown = 4.0f;
        UpdateOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (UpdateOn)
        {
            CountDownText.enabled = true;
            CounterDown -= Time.deltaTime;
            CountDownText.text = ((int)CounterDown).ToString();
        }
    }

    public void Basla()
    {
        Yarismaci1 = (YRS1.text).ToString();
        Yarismaci2 = (YRS2.text).ToString();
        Invoke("Degis", 4.0f);
        UpdateOn = true;
    }

    public void Degis()
    {
        PlayerPrefs.SetString("Yarismaci1", Yarismaci1);
        PlayerPrefs.SetString("Yarismaci2", Yarismaci2);
        PlayerPrefs.SetInt("YRS1SCR", 0);
        PlayerPrefs.SetInt("YRS2SCR", 0);
        SceneManager.LoadScene(1);
    }

    public void Cık()
    {
        Application.Quit();
    }

    public void HakkındayaGec()
    {
        SceneManager.LoadScene(3);
    }
}
