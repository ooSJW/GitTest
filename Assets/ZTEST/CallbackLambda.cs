using System;
using UnityEngine;

public partial class CallbackLambda : MonoBehaviour // DataField
{
    private void Start()
    {
        Performcalculation(
            10,
            20,
            //OnPlayCallback

            //Lambda
            (res, res2) =>
            {
                return 0f;
            }
            );
        //Lambda ������ ����
        Action<int, int> action = (a, b) => { print(a + b); };
        action(1, 2);

        Func<string, int> func =
            (elem) =>
            {
                int result = 0;
                foreach (char item in elem.ToCharArray())
                {
                    result += item;
                }
                return result;
            };
        print(func("Hello"));


    }
    private int propertyTest; // ������Ƽ������ ������ ����
    public int PropertyText { get => propertyTest; set => propertyTest = value; }
}
public partial class CallbackLambda : MonoBehaviour // 
{
    // public void Performcalculation(int a, int b, Action callback) // �⺻���� callback
    // public void Performcalculation(int a, int b, Action<int, int> callback) // �Ű������� ���� ��

    // Action : ��ȯ���� ���� Ư���� ��������Ʈ
    // Func<�Ű�����1,�Ű�����2,����Ÿ��>
    public void Performcalculation(int a, int b, Func<int, int, float> callback) // �Ű������� ����Ÿ���� ���� ��
    {
        int result = a + b;
        // ?: null������ ?? : ���ʰ��� null�� �� ������ �� ��ȯ.

        float c = callback?.Invoke(0, 0) ?? 0f;
    }
    public float OnPlayCallback(int res, int res2)
    {
        Debug.Log("OnPlayCallback ȣ��");
        print(res);
        print(res2);
        return 0.5f;
    }
}