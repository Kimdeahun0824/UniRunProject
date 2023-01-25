using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static partial class GFunc
{

    // ! 현재 활성화 되어 있는 씬을 찾아주는 함수
    public static Scene GetActiveScene()
    {
        Scene activeScene_ = SceneManager.GetActiveScene();

        return activeScene_;

    }       // GetActiveScene()
    // ! 씬의 루트 오브젝트를 서치해서 찾아주는 함수
    public static GameObject GetRootObject(string objName_)
    {
        Scene activeScene_ = GetActiveScene();
        GameObject[] rootObjs = activeScene_.GetRootGameObjects();
        GameObject targetObj = default(GameObject);
        foreach (var rootObj in rootObjs)
        {
            Debug.Log(rootObj.name);
            if (rootObj.name.Equals(objName_))
            {
                targetObj = rootObj;
            }
            else
            {
                continue;
            }
        }       // loop
        if (targetObj == default(GameObject))
        {
            return null;
        }
        else
        {
            return targetObj;
        }
    }       // GetRootObject(string objName_)

    // ! 특정 오브젝트의 자식 오브잭트를 서치해서 찾아주는 함수
    private static GameObject GetChildObject(this GameObject targetObj, string objName_)
    {
        GameObject searchResult = default;
        for (int i = 0; i < targetObj.transform.childCount; i++)
        {
            if (targetObj.transform.GetChild(i).gameObject.name.Equals(objName_))
            {
                searchResult = targetObj.transform.GetChild(i).gameObject;
                return searchResult;
            }       // if : 타겟 오브젝트에서 이름이 같은 오브젝트를 찾아서 리턴
            else
            {
                continue;
            }
        }       // loop
        return searchResult;        // 이름이 같은 오브젝트를 찾지 못한 경우 default 값을 리턴
    }       // GetChildObject(this GameObject targetObj, string objName_)

    // ! 특정 오브젝트의 자식 오브젝트를 서치해서 찾아주는 함수 
    public static GameObject FindChildObject(this GameObject targetObj_, string objName_)
    {
        GameObject serchResult = default;
        GameObject serchTarget = default;
        for (int i = 0; i < targetObj_.transform.childCount; i++)
        {
            serchTarget = targetObj_.transform.GetChild(i).gameObject;
            if (serchTarget.name.Equals(objName_))
            {
                serchResult = serchTarget;
                return serchResult;
            }
            else
            {
                serchResult = FindChildObject(serchTarget, objName_);
            }
        }
        if (serchResult == null || serchResult == default) {/*Do Nothing*/}
        else { return serchResult; }
        return serchResult;
    }
}