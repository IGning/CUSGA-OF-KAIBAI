using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����¶Ի���ϵͳ
public class ThirdDialogSystem : MonoBehaviour
{
    [Header("UI���")]//��Ƿ���
    public Text text;//Text���

    [Header("�ı��ļ�")]
    public TextAsset textFile;//�ı��ļ�
    public int index;//����ļ��е�����
    public float textSpeed;//������������ٶ�

    bool textFinished;//���ĳ�������Ƿ��ȡ��
    bool cancelTyping;//������Կ�����ʾ����

    List<string> textList = new List<string>();//�����б�洢�ı��ļ���������
    // Start is called before the first frame update
    void Awake()
    {
        GetTextFromFile(textFile);//�����ຯ����ʼ����ǰ���ȡ�ı��ļ�
    }
    private void OnEnable()//�ڶԻ�������ʱ�������һ�仰
    {
        textFinished = true;
        StartCoroutine(SetTextUI());//Э�̴���
    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && index == textList.Count)
        {
            gameObject.SetActive(false);//�ڽ����Ի��󽫶Ի���ر�
            index = 0;//�����Ի��󽫱����������
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (textFinished && !cancelTyping)//���ļ����������δȡ����������ִ��
            {
                StartCoroutine(SetTextUI());//ִ��Э�̴���
                if (index == 3)//�������忪��
                {
                    GameObject.Find("Dialogs/Canvas01/Panel/MainPlayer").SetActive(true);
                    GameObject.Find("Dialogs/Canvas01/Panel/Chief").SetActive(true);
                }
                if (index == 4)//��������ر�
                {
                    GameObject.Find("Dialogs/Canvas01/Panel/MainPlayer").SetActive(false);
                }
            }
            else if (!textFinished)//ÿ����һ�ΰ�����canceTyping��ֵ�Ե�
            {
                cancelTyping = !cancelTyping;
            }
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n');//�Ի��з�Ϊ��ǵ�ʹ���ı��������

        foreach (var line in lineData)
        {
            textList.Add(line);//�������
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;//���ǰ���Ϊ��
        text.text = "";//ÿ�ε���ǰ����ǰ���������
        int letter = 0;
        while (!cancelTyping && letter < textList[index].Length - 1)//δȡ��������ִ��
        {
            text.text += textList[index][letter];//��ø������ֵĵ�letter���ַ�
            letter++;
            yield return new WaitForSeconds(textSpeed);//��ִ����һ��ǰ�ȴ�ʱ��
        }
        text.text = textList[index];//������ѭ����ִ����ֱ�����ȫ���ı�
        cancelTyping = false;//����������Ϊ�٣���ʾ��һ��δȡ������
        textFinished = true;//�������Ϊ��
        index++;
    }
}
