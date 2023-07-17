using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.PackageManager;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]

    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! GameObject 받아서 Text 컴포넌트 찾아서 text 필드 값 수정하는 함수
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if (textComponent == null || textComponent == default) { return; }

        textComponent.text = text;
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //! 특정 오브젝트의 자식 오브젝트를 서치해서 컴포넌트를 찾아주는 함수
    public static T FindChildComponent<T>(this GameObject targetobj_, string objName_) where T : Component
    {
        T searchResultComponent = default(T);
        GameObject searchResultobj = default(GameObject);

        searchResultobj = targetobj_.Findchildobj(objName_);
        if (searchResultobj != null || searchResultobj != default)
        {
            searchResultComponent = searchResultobj.GetComponent<T>();
        }

        return searchResultComponent;
    }         // FindChildComponent()

    //! 특정 오브젝트의 자식 오브젝트를 서치해서 찾아주는 함수
    public static GameObject Findchildobj(this GameObject targetobj_, string objName_)     // 재귀 함수 (내 함수를 내가 콜하는 것)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;

        for (int i = 0; i < targetobj_.transform.childCount; i++)
        {
            searchTarget = targetobj_.transform.GetChild(i).gameObject;
            if (searchTarget.name.Equals(objName_))
            {
                searchResult = searchTarget;
                return searchResult;
            }
            else
            {
                searchResult = Findchildobj(searchTarget, objName_);

                if (searchResult == null || searchResult == default) { /* Pass */ }
                else { return searchResult; }
            }        // else: 내가 찾고 싶은 오브젝트를 아직 못찾은 경우
        }         // loop: 탐색 타겟 오브젝트의 자식 오브젝트 갯수만큼 순회하는 루프

        return searchResult;
    }         // FindChildobj()


    // 현재 씬의 이름을 리턴한다.
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    //! 활성화 된 현재 씬의 루트 오브젝트를 서치해서 찾아주는 함수
    public static GameObject GetRootobj(string objName_)
    {
        Scene activeScene_ = SceneManager.GetActiveScene();
        GameObject[] rootobjs_ = activeScene_.GetRootGameObjects();

        GameObject targetobj_ = default;
        foreach(GameObject rootobj_ in rootobjs_)
        {
            if (rootobj_.name.Equals(objName_))
            {
                targetobj_ = rootobj_;
            }
            else { continue; }
        }

        return targetobj_;
    }     // GetRootobj()

    public static Vector2 AddVector(this Vector3 origin, Vector2 addvector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addvector;
        return result;
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif
    }

    // 컴포넌트가 존재하는지 여부를 체크하는 함수
    public static bool isValid<T>(this T target) where T : Component
    {
        if (target == null || target == default) { return false; }
        else { return true; }
    }

    // 리스트가 존재하는지 여부를 체크하는 함수
    public static bool isValid<T>(this List<T> target)
    {
        bool isInValid = (target == null || target == default);
        isInValid = isInValid || target.Count == 0;

        if (isInValid == true) { return false; }
        else { return true; }
    }


}
