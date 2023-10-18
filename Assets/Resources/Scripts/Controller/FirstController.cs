using UnityEngine;

public class FirstController : MonoBehaviour,ISceneController
{
    public River river;
    public Boat boat;
    public Bank[] banks = new Bank[2];
    public Role[] devilsAndpriests = new Role[6];

    void Awake()
    {
        
        SSDirector director = SSDirector.getInstance();
        director.setFPS(60);
        director.currentSceneController = this;
        director.currentSceneController.LoadResources();
        
    }

    // loading resources for the first scence
    public void LoadResources()
    {
        river = new River();
        boat = new Boat();
        for (int i = 0; i < 2; i++)
        {
            banks[i] = new Bank(i);
            banks[i].SetName("bank" + i);
        }
        for(int i = 0; i < 3; i++)
        {
            devilsAndpriests[i] = new Role("Priest", new Vector3(2 + i, 0.5f, -3.5f));
            devilsAndpriests[i].SetName("priest" + i);
            devilsAndpriests[i].SetPosition(devilsAndpriests[i].posRight);
        }
        for (int i = 0; i < 3; i++)
        {
            devilsAndpriests[i + 3] = new Role("Devil", new Vector3(-4 + i, 0.5f, -3.5f));
            devilsAndpriests[i + 3].SetName("devil" + i);
            devilsAndpriests[i + 3].SetPosition(devilsAndpriests[i + 3].posRight);
        }
    }

    public Role[] getRole()
    {
        return devilsAndpriests;
    }

    public void Reset()
    {
        foreach(Role role in devilsAndpriests)
        {
            Destroy(role.character);
        }
        foreach(Bank bank in banks)
        {
            Destroy(bank.bank);
        }
        Destroy(boat.thisboat);
        Destroy(river.river);
        LoadResources();
    }
}
