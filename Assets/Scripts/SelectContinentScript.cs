using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectContinentScript : MonoBehaviour
{
    public Text Yarisan1;
    public Text Yarisan2;
    public Text Yarisan1Skor;
    public Text Yarisan2Skor;
    public Text Yarisan1Sıra;
    public Text Yarisan2Sıra;
    public Text SoruHazırlama;
    public Text CountDownText;

    public float CounterDown;

    public bool UpdateOn;
    public bool YarismaciDegistir;


    public GameObject YerImleci;

    int YRS1SCR;
    int YRS2SCR;
    int ContinentSelector;
    float YerDegistirmeTutucu;
    float SoruHazırlamaTutucu;
    float SoruYeriTutucu;
    bool DurBasıldı;
    

    string[] Continents = new string[6] { "ASYA", "AVRUPA", "AFRİKA", "KUZEY AMERİKA", "GÜNEY AMERİKA", "OKYANUSYA" };
    Vector2[] ContinentsPositions = new Vector2[]
    {
        new Vector2(-4f,-2.7f),
        new Vector2(-0.3f,-3f),
        new Vector2(-0.5f,-0.7f),
        new Vector2(7.3f,-3f),
        new Vector2(5f,1f),
        new Vector2(-8.6f,2.2f),
    };

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("YarismaciDegistir") == 1)
        {
            YarismaciDegistir = true;
        }
        else
        {
            YarismaciDegistir = false;
        }

        if (!YarismaciDegistir)
        {
            Yarisan1Sıra.enabled = true;
            Yarisan2Sıra.enabled = false;
            if(PlayerPrefs.GetInt("DogruCevap") == 1)
            {
                YRS2SCR = PlayerPrefs.GetInt("YRS2SCR");
                YRS2SCR++;
                PlayerPrefs.SetInt("YRS2SCR", YRS2SCR);
            }
        }
        else
        {
            Yarisan1Sıra.enabled = false;
            Yarisan2Sıra.enabled = true;
            if (PlayerPrefs.GetInt("DogruCevap") == 1)
            {
                YRS1SCR = PlayerPrefs.GetInt("YRS1SCR");
                YRS1SCR++;
                PlayerPrefs.SetInt("YRS1SCR", YRS1SCR);
            }
        }

        YRS1SCR = PlayerPrefs.GetInt("YRS1SCR");
        YRS2SCR = PlayerPrefs.GetInt("YRS2SCR");

        if (YRS1SCR >= 3)
        {
            if (YRS1SCR - YRS2SCR >= 2)
            {
                PlayerPrefs.SetString("Kazanan", PlayerPrefs.GetString("Yarismaci1"));
                SceneManager.LoadScene(0);
            }
        }

        if (YRS2SCR >= 3)
        {
            if(YRS2SCR - YRS1SCR >= 2)
            {
                PlayerPrefs.SetString("Kazanan", PlayerPrefs.GetString("Yarismaci2"));
                SceneManager.LoadScene(0);
            }

        }
        SoruHazırlama.enabled = false;
        YerDegistirmeTutucu = Time.time;
        SoruHazırlamaTutucu = 2.0f;
        CounterDown = 10.0f;

        UpdateOn = true;

        Yarisan1.text = PlayerPrefs.GetString("Yarismaci1");
        Yarisan2.text = PlayerPrefs.GetString("Yarismaci2");
        Yarisan1Skor.text = "SKOR: " + YRS1SCR.ToString();
        Yarisan2Skor.text = "SKOR: " + YRS2SCR.ToString();
        SoruHazırlama.text = "SORU HAZIRLANIYOR";
        YerImleci.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (UpdateOn)
        {
            CounterDown -= Time.deltaTime;
            CountDownText.text = ((int)CounterDown).ToString();           
            if (Time.time - YerDegistirmeTutucu > 0.1f)
            {
                ContinentSelector = Random.Range(0, 6);
                YerImleci.SetActive(true);
                YerImleci.GetComponent<RectTransform>().pivot = ContinentsPositions[ContinentSelector];
                YerDegistirmeTutucu = Time.time;
            }
        }
        if(CounterDown <= 0)
        {
            DurtusuBasıldı();
            SoruHazırlama.enabled = true;
            UpdateOn = false;
            CountDownText.text = Continents[ContinentSelector];
        }

        if(!UpdateOn)
        {
            SoruHazırlamaTutucu -= Time.deltaTime;
            if (SoruHazırlamaTutucu <= 0)
            {
                SoruHazırlama.text += ".";
                SoruHazırlamaTutucu += 2;
                if (SoruHazırlama.text.Length == 21)
                {
                    SoruHazırlama.text = "SORU HAZIRLANIYOR";
                }
            }
        }
        
    }

    public void DurtusuBasıldı()
    {
        CounterDown -= CounterDown;
        PlayerPrefs.SetString("Continent", Continents[ContinentSelector]);
        if (PlayerPrefs.GetInt("YarismaciDegistir") == 1)
        {
            PlayerPrefs.SetInt("YarismaciDegismeli", 0);
        }
        else
        {
            PlayerPrefs.SetInt("YarismaciDegismeli", 1);
        }
        Invoke("Degis", 10.0f);                
    }

    public void Degis()
    {
        PlayerPrefs.SetString("Kıta", Continents[ContinentSelector]);

        SceneManager.LoadScene(2);
    }

    //Dictionary<string, Vector2>[] Pivots = new Dictionary<string, Vector2>[]
    //{
    //    new Dictionary<string, Vector2>(),
    //    new Dictionary<string, Vector2>(),
    //    new Dictionary<string, Vector2>(),
    //    new Dictionary<string, Vector2>(),
    //    new Dictionary<string, Vector2>(),
    //    new Dictionary<string, Vector2>(),
    //};
}
