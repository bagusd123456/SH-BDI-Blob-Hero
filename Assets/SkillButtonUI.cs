using Doozy.Runtime.UIManager.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButtonUI : MonoBehaviour
{
    public UIButton button;
    public BaseSkill SkillToAdd;
    
    public void Init()
    {
        button.AddBehaviour(Doozy.Runtime.UIManager.UIBehaviour.Name.PointerClick).Event.AddListener(() => SkillManager.instance.AddSkill(SkillToAdd));
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
