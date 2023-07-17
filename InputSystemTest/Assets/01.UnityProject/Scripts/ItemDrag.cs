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

    private delegate void myAction001(object message, int number1, int number2);     // return 타입이 없는 delegate
    private System.Action<object, int, int> myAction;                                // return 타입이 없는 Action

    private delegate string myFunction001(float f1, float f2, int i1, int i2);       // return 타입이 있는 delegate
    private System.Func<float, float, int, int, string> myFunc;                      // return 타입이 있는 Function (<> 안의 맨 마지막이 return 타입)

    private void Awake()
    {
        uiCanvas = GFunc.GetRootobj("UICanvas").GetComponent<Canvas>();
        itemRect = GetComponent<RectTransform>();

        //Debug.LogFormat("제대로 찾아오나?? {0}", uiCanvas.gameObject.Findchildobj("Foreimg").name);

        //sdPlayer = GFunc.GetRootobj("Set Costume_02 SD Yuko");
        //GameObject yukoLeftEye = sdPlayer.Findchildobj("Eye_L");
        //Debug.LogFormat("Yuko is null {0}, Yuko's left eye is null: {1}", sdPlayer == null, yukoLeftEye == null);

        isDraging = false;

        myLogFunc myLogFunc = (object obj_) =>
        {
            Debug.Log("이 로그가 잘 찍히는지 테스트");
            Debug.Log("넘겨받은 메시지는");
            Debug.Log(obj_);
        };

        myLogFunc("이제부터 이 로그 함수는 제 껍니다.");
    }

    void Start()
    {
        //itemRect.anchoredPosition += new Vector2(100f, 0f);       // 앵커드 포지션 값 변경
        //itemRect.localPosition += new Vector3(100f, 0f, 0f);      // 로컬 포지션 값 변경
    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDraging = true;
        Debug.Log("마우스 왼쪽버튼 클릭한 바로 그순간");
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDraging)
        {
            // LEGACY:
            //itemRect.anchoredPosition += eventData.delta;
            itemRect.anchoredPosition += (eventData.delta / uiCanvas.scaleFactor);     // UI 캔버스 값을 나눠준다.
            //Debug.LogFormat("아이콘을 움직일 준비가 되었음. -> {0}", eventData.delta);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDraging = false;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("이거 함수 만든것 뿐인데 정말로 클릭이 되나???");
    }
}
