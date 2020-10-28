using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Square : MonoBehaviour
{
    public enum Marks
    {
        None,
        Circle,
        Cross
    }

    // マスの状態
    [SerializeField] Marks mark;
    [SerializeField] Image markImage;
    [SerializeField] Sprite noneIcon;
    [SerializeField] Sprite circleIcon;
    [SerializeField] Sprite crossIcon;


    // コールバック
    public UnityAction<Square> ClickAction;

    void Start()
    {
        ChangeMark(Marks.None);
    }

    void Show()
    {
        if (mark == Marks.Circle)
        {
            this.markImage.sprite = circleIcon;
        }
        else if (mark == Marks.Cross)
        {
            this.markImage.sprite = crossIcon;
        }
        else
        {
            this.markImage.sprite = noneIcon;
        }
    }

    public Marks GetMark()
    {
        return mark;
    }

    public void ChangeMark(Marks mark)
    {
        this.mark = mark;
        Show();
    }

    public void OnClickThis()
    {
        Debug.Log("OnClicked");
        ClickAction.Invoke(this);
    }

}
