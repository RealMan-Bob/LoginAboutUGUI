using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    //CanvasGroup组件实现基本的panel面板的淡入淡出效果
    public CanvasGroup canvasGroup;
    //淡入淡出速度
    public float alphaSpeed = 7f;
    //完全淡出后的委托
    public UnityAction hideMeCallBack;
    private bool isShowing;
    protected virtual void Awake()
    {
        //自动挂载CanvasGroup，避免忘记手动挂载组件导致动画失效
        canvasGroup = GetComponent<CanvasGroup>();
        if( canvasGroup == null)
        {
            canvasGroup=this.AddComponent<CanvasGroup>();
        }
    }
    /// <summary>
    /// 淡出
    /// </summary>
    /// <param name="unityAction"></param>
    public virtual void Hide(UnityAction unityAction = null)
    {
        isShowing = false;

        canvasGroup.alpha = 1;
        
        hideMeCallBack=unityAction;

    }
    /// <summary>
    /// 淡入
    /// </summary>
    public virtual void Show()
    {
        isShowing = true;
        canvasGroup.alpha = 0;
    }
    /// <summary>
    /// 在start中进行初始化绑定
    /// </summary>
    protected abstract void Init();
    // Start is called before the first frame update
    protected virtual void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        //淡入
        if (isShowing && canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha > 1) 
            canvasGroup.alpha = 1;
        }
        //淡出
        else if (!isShowing)
        {
            canvasGroup.alpha -= alphaSpeed * Time.deltaTime;
            if (canvasGroup.alpha <= 0)
            {
                canvasGroup.alpha = 0;
                hideMeCallBack?.Invoke();
            }
        }
    }
}
