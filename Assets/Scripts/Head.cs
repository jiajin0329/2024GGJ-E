using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Head : MonoBehaviour
{
    [Header("頭設定")]
    [SerializeField] private GameObject head;
    [HideInInspector] public int headLevel = 1;
    [SerializeField] private int maxHeadLevel;
    [Header("漂浮設定")]
    private float floatSpeed;

    private void Start()
    {
        Observable.EveryUpdate().First().Subscribe(_ =>
          {
              transform.position += new Vector3(0, floatSpeed * Time.deltaTime, 0);
          }).AddTo(this);
    }
    public void Reset()
    {
        headLevel = 1;
        head.transform.localScale = new Vector3(headLevel, headLevel, 1);

    }

    public void IncreaseHeadLevel()
    {
        headLevel++;
        head.transform.localScale = new Vector3(headLevel, headLevel, 1);

        if (headLevel >= maxHeadLevel)
        {
            //關閉碰撞
            Collider collider2D = GetComponent<Collider>();
            if (collider2D != null)
                collider2D.enabled = false;

            //圖片層級跳至HeadDie
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            if (sprite != null)
                sprite.sortingLayerName = "HeadDie";
        }
    }
}
