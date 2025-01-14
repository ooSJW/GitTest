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
        //Lambda 간단한 예제
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
    private int propertyTest; // 프로퍼티에서의 간단한 예제
    public int PropertyText { get => propertyTest; set => propertyTest = value; }
}
public partial class CallbackLambda : MonoBehaviour // 
{
    // public void Performcalculation(int a, int b, Action callback) // 기본적인 callback
    // public void Performcalculation(int a, int b, Action<int, int> callback) // 매개변수가 있을 때

    // Action : 반환값이 없는 특수한 델리게이트
    // Func<매개변수1,매개변수2,리턴타입>
    public void Performcalculation(int a, int b, Func<int, int, float> callback) // 매개변수와 리턴타입이 있을 때
    {
        int result = a + b;
        // ?: null연산자 ?? : 왼쪽값이 null일 시 오른쪽 값 반환.

        float c = callback?.Invoke(0, 0) ?? 0f;
    }
    public float OnPlayCallback(int res, int res2)
    {
        Debug.Log("OnPlayCallback 호출");
        print(res);
        print(res2);
        return 0.5f;
    }
}