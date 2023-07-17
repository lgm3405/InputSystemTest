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

    //! GameObject �޾Ƽ� Text ������Ʈ ã�Ƽ� text �ʵ� �� �����ϴ� �Լ�
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

    //! Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ������Ʈ�� ã���ִ� �Լ�
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

    //! Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ�
    public static GameObject Findchildobj(this GameObject targetobj_, string objName_)     // ��� �Լ� (�� �Լ��� ���� ���ϴ� ��)
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
            }        // else: ���� ã�� ���� ������Ʈ�� ���� ��ã�� ���
        }         // loop: Ž�� Ÿ�� ������Ʈ�� �ڽ� ������Ʈ ������ŭ ��ȸ�ϴ� ����

        return searchResult;
    }         // FindChildobj()


    // ���� ���� �̸��� �����Ѵ�.
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    //! Ȱ��ȭ �� ���� ���� ��Ʈ ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ�
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

    // ������Ʈ�� �����ϴ��� ���θ� üũ�ϴ� �Լ�
    public static bool isValid<T>(this T target) where T : Component
    {
        if (target == null || target == default) { return false; }
        else { return true; }
    }

    // ����Ʈ�� �����ϴ��� ���θ� üũ�ϴ� �Լ�
    public static bool isValid<T>(this List<T> target)
    {
        bool isInValid = (target == null || target == default);
        isInValid = isInValid || target.Count == 0;

        if (isInValid == true) { return false; }
        else { return true; }
    }


}
