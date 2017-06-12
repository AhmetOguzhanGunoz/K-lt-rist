using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    string[,] CountriesWithContinents = new string[,]
    {
       { "ASYA", "AVRUPA", "AFRİKA", "KUZEY AMERİKA", "GÜNEY AMERİKA", "OKYANUSYA" },
       { "RUSYA", "ALMANYA", "CEZAYİR", "AMERİKA BİRLEŞİK DEVLETLERİ", "ARJANTİN", "AVUSTRALYA" },
       { "ÇİN", "FRANSA", "KAMERUN", "KANADA", "BREZİLYA",  "ENDONEZYA"},
       { "HİNDİSTAN", "HOLLANDA", "LİBYA", "DOMİNİK", "KOLOMBİYA", "YENİ ZELANDA"  },
       { "JAPONYA", "ESTONYA", "TUNUS", "MEKSİKA", "ŞİLİ", "FİJİ"},
       { "TAYLAND", "İSVEÇ", "SENEGAL", "KÜBA", "PERU", "TONGA" },
    };

    string[,] OkyanusyaAnswers = new string[,]
    {
        { "7.692.024 km²", "CANBERRA", "DOLAR", "59.023", "66,984 $", "23.111.910" },
        { "1.904.569 km²", "CAKARTA", "RUPİ", "302.000", "3,469 $", "260.581.100" },
        { "270.467 km²", "WELLİNGTON", "DOLAR", "9.702", "38,227 $", "4.472.390" },
        { "18.272 km²", "SUVA", "DOLAR", "3.500", "3,806 $", "858.038" },
        { "747 km²", "NUKU ALOFA", "PA ANGA", "67.228", "3,648 $", "103.036" },
    };

    string[,] GüneyAmerikaAnswers = new string[,]
    {
        { "2.780.400 km²", "BUENOS AİRES", "AUSTRAL", "73.100", "10,640 $", "40.117.096" },
        { "8.515.767 km²", "BRAZİLYA", "REAL", "327.710", "12,917 $", "209.567.920" },
        { "1.141.748 km²", "BOGOTA", "PEZO", "285.220", "6,980 $", "47.181.000" },
        { "756.102 km²", "SANTİAGO", "PEZO", "60.560", "13,970 $", "17.200.000" },
        { "1.285.216 km²", "LİMA", "NUEVO SOL", "114.000", "5,614 $", "30.475.144" },
    };

    string[,] KuzeyAmerikaAnswers = new string[,]
    {
        { "9.629.091 km²", "WASHİNGTON DC.", "DOLAR", "1.580.255", "48,147 $", "324.118.940" },
        { "9.984.670 km²", "OTTAWA", "DOLAR", "65.722", "51,147 $", "35.141.542" },
        { "48.671 km²", "SANTO DOMİNGO", "PEZO", "49.910", "5,406 $", "9.445.281" },
        { "1.964.375 km²", "MEKSİKO", "PEZO", "267.506", "10,803 $", "128.632.004" },
        { "109.884 km²", "HAVANA", "PEZO", "49.000", "18.800 $", "11.163.934" },
    };

    string[,] AfrikaAnswers = new string[,]
    {
        { "2.381.741 km²", "CEZAYİR", "DİNAR", "147.000", "5,001 $", "37.900.000" },
        { "475.442 km²", "YAOUNDE", "FRANK", "14.100", "1,234 $", "20.386.799" },
        { "1.759.540 km²", "TRABLUS", "DİNAR", "76.000", "10,873 $", "6.202.000" },
        { "163.610 km²", "TUNUS", "DİNAR", "35.800", "4,593 $", "10.777.500" },
        { "196.722 km²", "DAKAR", "FRANK", "13.620", "1,096 $", "13.567.338" },
    };

    string[,] AvrupaAnswers = new string[,]
    {
        { "357.114 km²", "BERLİN", "MARK", "250.613", "44,558 $", "80.682.351" },
        { "640.679 km²", "PARİS", "FRANK", "352.771", "44,401 $", "65.107.000" },
        { "41.850 km²", "AMSTERDAM", "GULDEN", "61.302", "51,410 $", "16.795.200" },
        { "45.227 km²", "TALLİNN", "KRON", "4.750", "16,880 $", "1.286.540" },
        { "450.295 km²", "STOCKHOLM", "KRON", "13.050", "61,098 $", "9.588.569" },
    };

    string[,] AsyaAnswers = new string[,]
    {
        { "17.100.000 km²", "MOSKOVA", "RUBLE", "1.027.000", "13,926 $", "143.439.832" },
        { "9.597.000 km²", "PEKİN", "YUAN", "2.285.000", "5,184 $", "1.384.323.332" },
        { "3.287.000 km²", "YENİ DELHİ", "RUPİ", "1.325.000", "1,527 $", "1.326.801.576" },
        { "377.962 km²", "TOKYO", "YEN", "230.300", "45,774 $", "126.323.715" },
        { "513.120 km²", "BANGKOK", "BAHT", "305.860", "5,281 $", "68.146.609" },

    };

    string[] CountryQuestions = new string[]{"yüz ölçümü kilometre karesi","başkenti","para birimi","aktif asker sayısı","kişi başına düşen yıllık milli geliri","nüfusu"};

    string[] QuestionTags = new string[2] { "kaçtır ?", "hangisidir ?" };

    public Text SoruKısmı;
    public Text ÜlkeAdı;
    public Text DogruYanlıs;
    public Text A_Sıkkı;
    public Text B_Sıkkı;
    public Text C_Sıkkı;
    public Text D_Sıkkı;
    public Text CountDownText;
    public GameObject KıtadakiYer;
    public GameObject Bayrak;
    public GameObject A_Secimi;
    public GameObject B_Secimi;
    public GameObject C_Secimi;
    public GameObject D_Secimi;
    public string DogruSık;


    Text[] Sıklar = new Text[4];
    GameObject[] Secimler = new GameObject[4];
    int DogruSıkTutucu;
    int CountrySelector;
    int QuestionSelector;
    int DogruSıkSelector;
    int YanlısSıkSelector;
    int count;
    float CounterDown;
    string[] TumBilgiler = new string[30];
    string temp;
    bool ErkendenSecildi;



    // Use this for initialization
    void Start ()
    {
        DogruYanlıs.enabled = false;
        ErkendenSecildi = true;
        CounterDown = 31;
        Sıklar[0] = A_Sıkkı;
        Sıklar[1] = B_Sıkkı;
        Sıklar[2] = C_Sıkkı;
        Sıklar[3] = D_Sıkkı;
        Secimler[0] = A_Secimi;
        Secimler[1] = B_Secimi;
        Secimler[2] = C_Secimi;
        Secimler[3] = D_Secimi;
        DogruSıkSelector = Random.Range(0, 4);
        YanlısSıkSelector = Random.Range(0, 30);
        CountrySelector = Random.Range(1, 6);
        QuestionSelector = Random.Range(0, 6);
        count = 1;
        for (int counter = 0; counter < TumBilgiler.Length; counter++)
        {
            if (counter <= 4)
            {
                TumBilgiler[counter] = AsyaAnswers[counter % 5, QuestionSelector];
            }
            else if (counter > 4 && counter <= 9)
            {
                TumBilgiler[counter] = AvrupaAnswers[counter % 5, QuestionSelector];
            }
            else if (counter > 9 && counter <= 14)
            {
                TumBilgiler[counter] = AfrikaAnswers[counter % 5, QuestionSelector];
            }
            else if (counter > 14 && counter <= 19)
            {
                TumBilgiler[counter] = KuzeyAmerikaAnswers[counter % 5, QuestionSelector];
            }
            else if (counter > 19 && counter <= 24)
            {
                TumBilgiler[counter] = GüneyAmerikaAnswers[counter % 5, QuestionSelector];
            }
            else if (counter > 24 && counter <= 29)
            {
                TumBilgiler[counter] = OkyanusyaAnswers[counter % 5, QuestionSelector];
            }
        }

        for (int i = 0; i <= 5; i++)
        {
            if(PlayerPrefs.GetString("Continent") == CountriesWithContinents[0,i])
            {
                ÜlkeAdı.text = CountriesWithContinents[CountrySelector,i];
                DogruSıkTutucu = i;
            }
        }

        KıtadakiYer.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Pictures/LOCATIONS/"+ PlayerPrefs.GetString("Continent") +"/Yer_" + ÜlkeAdı.text);
        Bayrak.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Pictures/FLAGS/" + PlayerPrefs.GetString("Continent") + "/" + ÜlkeAdı.text);

        if (QuestionSelector == 1 || QuestionSelector == 2)
        {
            SoruKısmı.text = ÜlkeAdı.text[0] + ÜlkeAdı.text.Substring(1).ToLower() + " " + CountryQuestions[QuestionSelector] + " " + QuestionTags[1];
        }
        else
        {
            SoruKısmı.text = ÜlkeAdı.text[0] + ÜlkeAdı.text.Substring(1).ToLower() + " " + CountryQuestions[QuestionSelector] + " " + QuestionTags[0];
        }

        switch (DogruSıkTutucu)
        {
            case 0:
                // doğru şıkkı rastgele yerleştirme
                DogruSık = TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu];
                temp = TumBilgiler[TumBilgiler.Length - count];
                TumBilgiler[TumBilgiler.Length - count] = TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu];
                TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu] = temp;
                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                count++;
                Sıklar[DogruSıkSelector].text = DogruSık;

                //rastgele doğru şıktan ve birbirinden farklı yanlış şık atama
                for (int incrementer = 0; incrementer < 4; incrementer++)
                {
                    if (Sıklar[incrementer].text != DogruSık)
                    {
                        if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                        {
                            while(TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        else if(TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        else if(TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 3])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 3]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }

                        Sıklar[incrementer].text = TumBilgiler[YanlısSıkSelector];
                        temp = TumBilgiler[TumBilgiler.Length - count];
                        TumBilgiler[TumBilgiler.Length - count] = TumBilgiler[YanlısSıkSelector];
                        TumBilgiler[YanlısSıkSelector] = temp;
                        count++;
                        YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                    }
                }
                break;
            case 1:
                // doğru şıkkı rastgele yerleştirme
                DogruSık = TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu];
                temp = TumBilgiler[TumBilgiler.Length - count];
                TumBilgiler[TumBilgiler.Length - count] = TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu];
                TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu] = temp;
                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                count++;
                Sıklar[DogruSıkSelector].text = DogruSık;

                //rastgele doğrudan ve birbirinden farklı yanlış şık atama
                for (int incrementer = 0; incrementer < 4; incrementer++)
                {
                    if (Sıklar[incrementer].text != DogruSık)
                    {
                        if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        else if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        else if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 3])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 3]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }

                        Sıklar[incrementer].text = TumBilgiler[YanlısSıkSelector];
                        temp = TumBilgiler[TumBilgiler.Length - count];
                        TumBilgiler[TumBilgiler.Length - count] = TumBilgiler[YanlısSıkSelector];
                        TumBilgiler[YanlısSıkSelector] = temp;
                        count++;
                        YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                    }
                }
                break;
            case 2:
                // doğru şıkkı rastgele yerleştirme
                DogruSık = TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu];
                temp = TumBilgiler[TumBilgiler.Length - count];
                TumBilgiler[TumBilgiler.Length - count] = TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu];
                TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu] = temp;
                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                count++;
                Sıklar[DogruSıkSelector].text = DogruSık;

                //rastgele doğrudan ve birbirinden farklı yanlış şık atama
                for (int incrementer = 0; incrementer < 4; incrementer++)
                {
                    if (Sıklar[incrementer].text != DogruSık)
                    {
                        if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        else if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        else if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 3])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 3]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }

                        Sıklar[incrementer].text = TumBilgiler[YanlısSıkSelector];
                        temp = TumBilgiler[TumBilgiler.Length - count];
                        TumBilgiler[TumBilgiler.Length - count] = TumBilgiler[YanlısSıkSelector];
                        TumBilgiler[YanlısSıkSelector] = temp;
                        count++;
                        YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                    }
                }
                break;
            case 3:
                // doğru şıkkı rastgele yerleştirme
                DogruSık = TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu];
                temp = TumBilgiler[TumBilgiler.Length - count];
                TumBilgiler[TumBilgiler.Length - count] = TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu];
                TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu] = temp;
                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                count++;
                Sıklar[DogruSıkSelector].text = DogruSık;

                //rastgele doğrudan ve birbirinden farklı yanlış şık atama
                for (int incrementer = 0; incrementer < 4; incrementer++)
                {
                    if (Sıklar[incrementer].text != DogruSık)
                    {
                        if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        else if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        else if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 3])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 3]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }

                        Sıklar[incrementer].text = TumBilgiler[YanlısSıkSelector];
                        temp = TumBilgiler[TumBilgiler.Length - count];
                        TumBilgiler[TumBilgiler.Length - count] = TumBilgiler[YanlısSıkSelector];
                        TumBilgiler[YanlısSıkSelector] = temp;
                        count++;
                        YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                    }
                }
                break;
            case 4:
                // doğru şıkkı rastgele yerleştirme
                DogruSık = TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu];
                temp = TumBilgiler[TumBilgiler.Length - count];
                TumBilgiler[TumBilgiler.Length - count] = TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu];
                TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu] = temp;
                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                count++;
                Sıklar[DogruSıkSelector].text = DogruSık;

                //rastgele doğrudan ve birbirinden farklı yanlış şık atama
                for (int incrementer = 0; incrementer < 4; incrementer++)
                {
                    if (Sıklar[incrementer].text != DogruSık)
                    {
                        if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        else if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        else if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 3])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 3]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        Sıklar[incrementer].text = TumBilgiler[YanlısSıkSelector];
                        temp = TumBilgiler[TumBilgiler.Length - count];
                        TumBilgiler[TumBilgiler.Length - count] = TumBilgiler[YanlısSıkSelector];
                        TumBilgiler[YanlısSıkSelector] = temp;
                        count++;
                        YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                    }
                }
                break;
            case 5:
                // doğru şıkkı rastgele yerleştirme
                DogruSık = TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu];
                temp = TumBilgiler[TumBilgiler.Length - count];
                TumBilgiler[TumBilgiler.Length - count] = TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu];
                TumBilgiler[(CountrySelector - 1) + (DogruSıkTutucu * 4) + DogruSıkTutucu] = temp;
                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                count++;
                Sıklar[DogruSıkSelector].text = DogruSık;

                //rastgele doğrudan ve birbirinden farklı yanlış şık atama
                for (int incrementer = 0; incrementer < 4; incrementer++)
                {
                    if (Sıklar[incrementer].text != DogruSık)
                    {
                        if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        else if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        else if (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 3])
                        {
                            while (TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 3]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 2]
                                || TumBilgiler[YanlısSıkSelector] == TumBilgiler[TumBilgiler.Length - 1])
                            {
                                YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                            }
                        }
                        Sıklar[incrementer].text = TumBilgiler[YanlısSıkSelector];
                        temp = TumBilgiler[TumBilgiler.Length - count];
                        TumBilgiler[TumBilgiler.Length - count] = TumBilgiler[YanlısSıkSelector];
                        TumBilgiler[YanlısSıkSelector] = temp;
                        count++;
                        YanlısSıkSelector = Random.Range(0, TumBilgiler.Length - count);
                    }
                }
                break;
        }        
	}
	
	// Update is called once per frame
	void Update ()
    {
        CounterDown -= Time.deltaTime;
        CountDownText.text = ((int)CounterDown).ToString();
        
        for(int i = 0; i < 4; i++)
        {
            if(Secimler[i].GetComponentInChildren<Toggle>().isOn && ErkendenSecildi)
            {
                CounterDown = 5;
                ErkendenSecildi = false;
            }
        }
        
        if(CounterDown <= 0)
        {
            CountDownText.enabled = false;
            if(Secimler[DogruSıkSelector].GetComponentInChildren<Toggle>().isOn)
            {
                DogruYanlıs.text = "DOĞRU";
                DogruYanlıs.enabled = true;
                for (int i = 0; i < 4; i++)
                {
                    Secimler[i].GetComponentInChildren<Toggle>().enabled = false;
                }
                if (PlayerPrefs.GetInt("YarismaciDegismeli") == 1)
                {
                    PlayerPrefs.SetInt("YarismaciDegistir", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("YarismaciDegistir", 0);
                }
                PlayerPrefs.SetInt("DogruCevap", 1);
                Invoke("Degis", 5.0f);
            }
            else
            {
                DogruYanlıs.text = "YANLIŞ";
                DogruYanlıs.enabled = true;
                for (int i = 0; i < 4; i++)
                {
                    Secimler[i].GetComponentInChildren<Toggle>().enabled = false;
                }
                if (PlayerPrefs.GetInt("YarismaciDegismeli") == 1)
                {
                    PlayerPrefs.SetInt("YarismaciDegistir", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("YarismaciDegistir", 0);
                }
                PlayerPrefs.SetInt("DogruCevap", 0);
                Invoke("Degis", 5.0f);
            }
        }
    }

    public void Degis()
    {
        SceneManager.LoadScene(1);
    }
}
