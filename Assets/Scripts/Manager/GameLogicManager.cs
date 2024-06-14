using System;
using System.Collections.Generic;

public class Player
{
    public Player(int userId, string name)
    {
        UserId = userId;
        Name = name;
        Level = 0;
    }

    public int UserId { get; private set; }
    public string Name { get;  set; }
    public int Level { get; set; }
}

public class GameLogicManager
{
    private static GameLogicManager _instance = null;
    private int _curSelectedPlayerId = 0;

    private static Dictionary<int, Player> _playerDic = new Dictionary<int, Player>();
    private Action<int, int> _levelUpCallback;
    private Action<int, string> _nameChangeCallback;

    public static GameLogicManager Inst
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameLogicManager();
                TempInitPlayerList();
            }
            return _instance;
        }
    }

    public static void TempInitPlayerList()
    {
        _playerDic.Add(1, new Player(1, "죠스바"));
        _playerDic.Add(2, new Player(2, "쌍쌍바"));
        _playerDic.Add(3, new Player(3, "바밤바"));
    }

    public void RegisterLevelUpCallback(Action<int, int> levelupCallback)
    {
        _levelUpCallback += levelupCallback;
    }

    public void UnRegisterLevelUpCallback(Action<int, int> levelupCallback)
    {
        _levelUpCallback -= levelupCallback;
    }

    public void RequestLevelUp()
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            var curPlayer = _playerDic[reqUserId];
            curPlayer.Level++;
            _levelUpCallback.Invoke(reqUserId, curPlayer.Level);
        }
    }

    public void RequestLevelUpDouble()
    {
        int reqUserId = _curSelectedPlayerId;

        if (_playerDic.ContainsKey(reqUserId))
        {
            var curPlayer = _playerDic[reqUserId];
            curPlayer.Level += 2;
            _levelUpCallback.Invoke(reqUserId, curPlayer.Level);
        }
    }

    public void RegisterNameChangeCallback(Action<int, string> namechangeCallback)
    {
        _nameChangeCallback += namechangeCallback;
    }

    public void UnRegisterNameChangeCallback(Action<int, string> namechangeCallback)
    {
        _nameChangeCallback -= namechangeCallback;
    }

    public void RequestRandomName()
    { 
        int requjUserId = _curSelectedPlayerId;

        if(_playerDic.ContainsKey(requjUserId))
        {
            var curPlayer = _playerDic[requjUserId];
            int RandomNum = new Random().Next(0, 4);
            string RandomName = "";
            
            switch(RandomNum)
            {
                case 0:
                    RandomName = "양파쿵야";
                    break;
                case 1:
                    RandomName = "버섯쿵야";
                    break;
                case 2:
                    RandomName = "샐러리쿵야";
                    break;
                case 3:
                    RandomName = "계란쿵야";
                    break;   
            }

            curPlayer.Name = RandomName; 
            _nameChangeCallback.Invoke(requjUserId, curPlayer.Name);
        }
    }

    public void RefreshCharacterInfo(int requestId, Action<int, string, int> callback)
    {
        _curSelectedPlayerId = requestId;
        if (_playerDic.ContainsKey(requestId))
        {
            var curPlayer = _playerDic[requestId];
            callback.Invoke(curPlayer.UserId, curPlayer.Name, curPlayer.Level);
        }
    }
}
