using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class GameController : MonoBehaviour
{
    public bool isPlaying;
    public bool isInMainMenu = true;
    public Player player;

    public SideGenerator sideGenerator;
    public EnvironmentGenerator environmentGenerator;
    
    public int money;
    public TextHandler moneyCounter;
    public TextHandler shopMoneyCounter;

    public EnergyBar energyBar;
    
    public GameObject deadPanel;
    
    public List<GameObject> objectsToShowOnStart;
    public List<GameObject> objectsToHideOnStart;

    private bool _isDeadPanelActive;
    private bool _isContinueAble;
    
    private void Start()
    {
        SetMoneyText();
    }

    private void Update()
    {
        if (isPlaying) return;
        isInMainMenu = objectsToHideOnStart[0].active;
        if (!Input.GetMouseButtonDown(0)) return;
        if (!(Input.mousePosition.y >= Screen.height * .2f) || !isInMainMenu && !_isDeadPanelActive) return;
                if(!_isDeadPanelActive) Play();
                else if(_isContinueAble) ResetGame();
                
    }

    private void Play()
    {
        isPlaying = true;
        SetGameObjects(objectsToShowOnStart, true);
        SetGameObjects(objectsToHideOnStart, false);
        player.Activate();
        sideGenerator.StartGenerating();
        environmentGenerator.StartGenerating();
        
        energyBar.damageEffect.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        isPlaying = false;
        SetGameObjects(objectsToShowOnStart, false);

        deadPanel.SetActive(true);
        _isDeadPanelActive = true;
        Invoke("MakeContinueAble", .6f);
        
        sideGenerator.StopGenerating();
    }

    private void ResetGame()
    {
        if (!_isDeadPanelActive) return;
        
        SetGameObjects(objectsToHideOnStart, true);
        
        player.Reset();
        Time.timeScale = 0;

        deadPanel.SetActive(false);
        _isDeadPanelActive = false;
        _isContinueAble = false;
        
        energyBar.damageEffect.gameObject.SetActive(false);
    }

    private void SetGameObjects(List<GameObject> list, bool active)
    {
        for(int i = 0; i<=list.Count-1; i++)
            list[i].SetActive(active);
    }

    private void SetMoneyText()
    {
        moneyCounter.SetText(money);
        shopMoneyCounter.SetText(money);
    }

    public void AddMoney(int amount)
    {
        money += amount;
        moneyCounter.Increase(amount);
        shopMoneyCounter.Increase(amount);
    }

    public void DecreaseMoney(int amount)
    {
        money -= amount;
        moneyCounter.Decrease(amount);
        shopMoneyCounter.Decrease(amount);
    }

    public bool ShopElementBuy(int price)
    {
        if (money < price) return false;
        DecreaseMoney(price);
        return true;
    }

    private void MakeContinueAble()
    {
        _isContinueAble = true;
    }
}
