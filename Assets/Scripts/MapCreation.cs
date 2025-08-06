using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    //����װ�γ�ʼ����ͼ�������������
    //�ϼң�ǽ���ϰ�������Ч�����������ݣ�����ǽ, ����Ч��2
    public GameObject[] item;

    //�Ѿ��ж�����λ��
    private List<Vector3> itemPositionList = new List<Vector3>();

    //�������˵�ʱ����
    private float TimeCreateEnemy = 0;

    private void Awake()
    {
        InitMap();
    }

    private void InitMap()
    {
        //ʵ�����ϼ�
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);

        for (int i = -1; i < 2; i++)
        {
            CreateItem(item[1], new Vector3(i, -7, 0), Quaternion.identity);
        }

        //ʵ������Χǽ
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);
        }
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -9; i < 10; i++)
        {
            CreateItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);
        }
        for (int i = -9; i < 9; i++)
        {
            CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
        }

        //��ʼ�����
        GameObject player = Instantiate(item[3], new Vector3(-3, -8, 0), Quaternion.identity);
        player.GetComponent<Born>().createPlayer = true;

        if (Option.isTwoPlayer)
        {
            GameObject player2 = Instantiate(item[7], new Vector3(3, -8, 0), Quaternion.identity);

        }

        //��ʼ������
        CreateItem(item[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(10, 8, 0), Quaternion.identity);

        //��������
        InvokeRepeating("CreateEnemy", 4, 5);


        //ʵ������ͼ
        for (int i = 0; i < 6; i++)
        {
            CreateItem(item[1], new Vector3(-10, Random.Range(-8, 8), 0), Quaternion.identity);
            CreateItem(item[1], new Vector3(10, Random.Range(-8, 8), 0), Quaternion.identity);
        }

        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);
        }

        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);
            CreateItem(item[2], CreateRandomPosition(), Quaternion.identity);
            CreateItem(item[4], CreateRandomPosition(), Quaternion.identity);
            CreateItem(item[5], CreateRandomPosition(), Quaternion.identity);
        }
    }


    private void CreateItem(GameObject createGameObject, Vector3 createPosition, Quaternion createRotation)
    {
        GameObject itemGo = Instantiate(createGameObject, createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(createPosition);
    }

    //�������λ��
    private Vector3 CreateRandomPosition()
    {
        //������һȦ������
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);

            if (!HasThePosition(createPosition))
            {
                return createPosition;

            }
        }

    }

    //�ж�λ���Ƿ���ռ��
    private bool HasThePosition(Vector3 createPos)
    {
        foreach (Vector3 pos in itemPositionList)
        {
            if (createPos == pos)
            {
                return true;
            }
        }
        return false;
    }



    //����һ��
    //��������
    //private Vector3 CreateEnemy()
    //   {
    //	int num = Random.Range(0, 3);
    //	Vector3 EnemyPos = new Vector3();
    //	if(num == 0)
    //       {
    //		EnemyPos = new Vector3(-10,8,0);
    //	}
    //	else if (num == 1)
    //	{
    //		EnemyPos = new Vector3(0, 8, 0);
    //       }
    //	else if(num == 2)

    //	{
    //		EnemyPos = new Vector3(10, 8, 0);
    //	}

    //	return EnemyPos;

    //}


    //void Update()
    //   {
    //	TimeCreateEnemy += Time.deltaTime;
    //	if(TimeCreateEnemy >= 4)
    //       {
    //		CreateItem(item[3], CreateEnemy(), Quaternion.identity);
    //		TimeCreateEnemy = 0;
    //	}
    //}

    //��������
    private void CreateEnemy()
    {
        int num = Random.Range(0, 3);
        Vector3 EnemyPos = new Vector3();
        if (num == 0)
        {
            EnemyPos = new Vector3(-10, 8, 0);
        }
        else if (num == 1)
        {
            EnemyPos = new Vector3(0, 8, 0);
        }
        else if (num == 2)

        {
            EnemyPos = new Vector3(10, 8, 0);
        }

        CreateItem(item[3], EnemyPos, Quaternion.identity);

    }
}
