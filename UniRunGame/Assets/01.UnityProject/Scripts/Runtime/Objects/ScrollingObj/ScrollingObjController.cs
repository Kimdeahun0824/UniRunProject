using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjController : MonoBehaviour
{
    public string prefabName = default;
    public int scrollingObjCount = default;
    public float scrollingSpeed = default;

    protected GameObject objPrefab = default;
    protected Vector2 objPrefabSize = default;
    protected List<GameObject> scrollingPool = default;

    // Start is called before the first frame update
    public virtual void Start()
    {
        objPrefab = gameObject.FindChildObj(prefabName);
        scrollingPool = new List<GameObject>();
        GFunc.Assert(objPrefab != null || objPrefab != default);

        objPrefabSize = objPrefab.GetRectSizeDelta();

        // { ?????? ??? ??????? ????? ????? ????
        GameObject tempObj = default;
        if (scrollingPool.Count <= 0)
        {
            for (int i = 0; i < scrollingObjCount; i++)
            {
                tempObj = Instantiate(objPrefab,
                    objPrefab.transform.position,
                    objPrefab.transform.rotation, transform);

                scrollingPool.Add(tempObj);
                tempObj = default;
            }       // loop: ?????? ????????? ????? ????? ???? ??? ????
        }       // if: scrolling pool?? ???? ???.

        objPrefab.SetActive(false);
        // } ?????? ??? ??????? ????? ????? ????

        // ?????? ????????? ????? ???????.
        scrollingSpeed = 800;
        InitObjsPosition();
    }       // Start()

    // Update is called once per frame
    public virtual void Update()
    {
        if (scrollingPool == default || scrollingPool.Count <= 0 || GameManager.instance.isGameOver)
        {
            return;
        }

        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].AddLocalPos(scrollingSpeed * Time.deltaTime * -1, 0f, 0f);
        }

        RepositionFirstObj();
    }


    //! 생성한 오브젝트의 위치를 설정하는 함수
    protected virtual void InitObjsPosition()
    {
        /* Do Something */
    }

    //! 스크롤링 풀의 첫번재 오브젝트를 마지막으로 리포지셔닝 하는 함수
    protected virtual void RepositionFirstObj()
    {
        /* Do Something */
    }
}
