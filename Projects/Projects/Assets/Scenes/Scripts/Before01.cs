using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���ڷ���Ļ֮���ÿ������ǰ����Ϊ��������Ч��
public class Before01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Open",1.5f);//����Open�������ȴ�1.5��
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        GameObject ParentObject = GameObject.Find("Dialogs");//�ҵ�������
        GameObject ChildObject = ParentObject.transform.Find("Canvas01").gameObject;//�ҵ������������ص�������
        ChildObject.SetActive(true);//���������Ϊ��ʾ״̬
        //��ͬ��
        GameObject ParentObject1 = GameObject.Find("Player");
        GameObject ChildObject1 = ParentObject1.transform.Find("Player01").gameObject;
        ChildObject1.SetActive(true);
    }
}
