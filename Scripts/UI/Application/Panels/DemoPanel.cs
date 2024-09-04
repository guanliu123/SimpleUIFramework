using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DemoPanel : BasePanel
{
    private static readonly string path = "Prefabs/Panels/DemoPanel";
    private string message;
    
    public DemoPanel(string message) : base(new UIType(path))
    {
        this.message = message;
    }

    public override void OnEnter()
    {
        base.OnEnter();
        //===================================示例方法（不推荐）========================================//
        //使用UITool工具中的方法直接通过名字遍历查找Panel下挂载的物体及组件，性能差，好处是不需要操作UIContainer
        // UITool.GetOrAddComponentInChildren<Button>("Btn_HL", panel).onClick.AddListener(() =>
        // {
        //     UITool.GetOrAddComponentInChildren<Text>("Text_HL", panel).text = this.message;
        // });
        //===================================示例方法（不推荐）========================================//
        
        //使用字典的存取方法，查找获取更加高效
        GetXXX<Button>("Btn_HL").onClick.AddListener(() =>
        {
            GetXXX<Text>("Text_HL").text = this.message;
        });
    }
}
