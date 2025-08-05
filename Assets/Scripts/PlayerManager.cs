using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    //����
    private int lifeValue = 3;

    public int playerScore = 0;
    public bool isDead;
    public bool isDead2;
    public bool isDefeat;

    //����
    public GameObject born;
    public GameObject born2;
    public Text playerScoreText;
    public Text playerLifeValueText;
    public GameObject GameOverUI;

    //����
    private static PlayerManager instance;

    public static PlayerManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }


    // Use this for initialization
    void Start()
    {
        if (Option.isTwoPlayer)
        {
            lifeValue = 6;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isDefeat)
        {
            //��Ϸʧ�ܣ�����������
            GameOverUI.SetActive(true);
            Invoke("ReturnToTheMainMenu", 3);
            return;
        }

        if (isDead)
        {

            Recover();
        }

        if (isDead2)
        {
            Recover2();
        }

        playerScoreText.text = playerScore.ToString();
        playerLifeValueText.text = lifeValue.ToString();

    }

    private void Recover()
    {
        if (lifeValue <= 1)
        {
            //��Ϸʧ�ܣ�����������
            isDefeat = true;

            Invoke("ReturnToTheMainMenu", 3);
        }
        else
        {
            lifeValue--;
            GameObject go = Instantiate(born, new Vector3(-3, -8, 0), Quaternion.identity);
            go.GetComponent<Born>().createPlayer = true;
            isDead = false;
        }
    }

    private void Recover2()
    {
        if (lifeValue <= 1)
        {
            //��Ϸʧ�ܣ�����������
            isDefeat = true;

            Invoke("ReturnToTheMainMenu", 3);
        }
        else
        {
            lifeValue--;
            GameObject go = Instantiate(born2, new Vector3(3, -8, 0), Quaternion.identity);

            isDead2 = false;
        }
    }


    private void ReturnToTheMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
