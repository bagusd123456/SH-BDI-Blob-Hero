using Doozy.Runtime.UIManager.Animators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public List<BaseSkill> availableSkills = new List<BaseSkill>();
    List<BaseSkill> currentActiveSkills = new List<BaseSkill>();
    PlayerCharacter player;

    public UIContainerUIAnimator container;

    public SkillButtonUI skillButtonPrefab;
    public Transform skillButtonSpawnTransform;

    int level = 1;
    int currentExp = 0;
    int nextExpToLevelUp = 25;

    public void AddExp(int Exp)
    {
        currentExp += Exp;
        if(currentExp > nextExpToLevelUp * level)
        {
            ShowAvailableSkills();
            currentExp = 0;
            level++;
        }
    }

    private void Awake()
    {
        instance = this;
        player = GameObject.FindObjectOfType<PlayerCharacter>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitAvailableSkills()
    {
        foreach (var item in availableSkills)
        {
            var btn = Instantiate(skillButtonPrefab, skillButtonSpawnTransform);
            btn.SkillToAdd = item;
            btn.Init();
        }
    }

    public void AddSkill(BaseSkill skill)
    {
        var find = currentActiveSkills.Find(x => x.skillName == skill.skillName);
        if(find != null)
        {
            find.OnLevelUp();
        }
        else
        {
            var skillClone = Instantiate(skill, player.transform);
            currentActiveSkills.Add(skillClone);
        }
    }

    public void ShowAvailableSkills()
    {
        container.Show();
        Time.timeScale = 0;
    }

    public void HideAvailableSkills()
    {
        container.Hide();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
