using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBgController : ScrollingObjController
{
    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }

    protected override void InitObjsPosition()
    {
        float horizonPos =
                    objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalPos(horizonPos, 0f, 0f);
            horizonPos = horizonPos + objPrefabSize.x;
        }
    }

    protected override void RepositionFirstObj()
    {
        float lastScrollingobjXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x;
        if (lastScrollingobjXPos <= objPrefabSize.x * 0.5f)
        {
            scrollingPool[0].SetLocalPos(lastScrollingobjXPos + objPrefabSize.x, 0f, 0f);
            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);
        }
    }


}
