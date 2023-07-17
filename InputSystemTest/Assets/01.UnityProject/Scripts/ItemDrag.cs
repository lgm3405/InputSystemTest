using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Canvas uiCanvas = default;
    private RectTransform itemRect = default;
    private bool isDraging = false;

    private GameObject sdPlayer = default;

    private delegate void myLogFunc(object message);

    private delegate void myAction001(object message, int number1, int number2);     // return Ÿ���� ���� delegate
    private System.Action<object, int, int> myAction;                                // return Ÿ���� ���� Action

    private delegate string myFunction001(float f1, float f2, int i1, int i2);       // return Ÿ���� �ִ� delegate
    private System.Func<float, float, int, int, string> myFunc;                      // return Ÿ���� �ִ� Function (<> ���� �� �������� return Ÿ��)

    private void Awake()
    {
        uiCanvas = GFunc.GetRootobj("UICanvas").GetComponent<Canvas>();
        itemRect = GetComponent<RectTransform>();

        //Debug.LogFormat("����� ã�ƿ���?? {0}", uiCanvas.gameObject.Findchildobj("Foreimg").name);

        //sdPlayer = GFunc.GetRootobj("Set Costume_02 SD Yuko");
        //GameObject yukoLeftEye = sdPlayer.Findchildobj("Eye_L");
        //Debug.LogFormat("Yuko is null {0}, Yuko's left eye is null: {1}", sdPlayer == null, yukoLeftEye == null);

        isDraging = false;

        myLogFunc myLogFunc = (object obj_) =>
        {
            Debug.Log("�� �αװ� �� �������� �׽�Ʈ");
            Debug.Log("�Ѱܹ��� �޽�����");
            Debug.Log(obj_);
        };

        myLogFunc("�������� �� �α� �Լ��� �� ���ϴ�.");
    }

    void Start()
    {
        //itemRect.anchoredPosition += new Vector2(100f, 0f);       // ��Ŀ�� ������ �� ����
        //itemRect.localPosition += new Vector3(100f, 0f, 0f);      // ���� ������ �� ����
    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDraging = true;
        Debug.Log("���콺 ���ʹ�ư Ŭ���� �ٷ� �׼���");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDraging)
        {
            // LEGACY:
            //itemRect.anchoredPosition += eventData.delta;
            itemRect.anchoredPosition += (eventData.delta / uiCanvas.scaleFactor);     // UI ĵ���� ���� �����ش�.
            //Debug.LogFormat("�������� ������ �غ� �Ǿ���. -> {0}", eventData.delta);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDraging = false;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("�̰� �Լ� ����� ���ε� ������ Ŭ���� �ǳ�???");
    }
}
