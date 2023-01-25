using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static partial class GFunc
{
    public static void SetTmpText(GameObject obj_, string text_)
    {
        TMP_Text tmpText = obj_.GetComponent<TMP_Text>();
        if(tmpText == null || tmpText == default(TMP_Text)){
            return;
        }       // if : 가져올 텍스트메쉬 컴포넌트가 없는 경우
        else if(text_ == string.Empty || text_ == default(string) || text_ == null){
            return;
        }       // 가져올 텍스트메쉬 컴포넌트가 존재하나 입력 string이 널 혹은 없는 경우
        else{
            tmpText.text = text_;
        }       // 가져올 텍스트메쉬 컴포넌트가 존재하는 경우
        
    }       // SetTextMeshPro

}
