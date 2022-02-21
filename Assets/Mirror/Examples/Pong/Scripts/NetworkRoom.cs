using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Examples.Pong
{
    struct PlayerItem
    {
        public NetworkConnection connection;
        public GameObject gameobject;
    }

    public class NetworkRoom : MonoBehaviour
    {
    private List<PlayerItem> players;
    
    public int max_capacity = 2;

    public bool AddPlayer(Mirror.NetworkConnection _player, GameObject playerObject)
    {
        PlayerItem _roomplayer = new PlayerItem();
        _roomplayer.connection = _player;
        _roomplayer.gameobject = playerObject;
        players.Add(_roomplayer);
        Debug.Log(players.Count);
        if(players.Count == max_capacity)
            return true;
            else
            return false;
    }

    public Mirror.NetworkConnection GetPlayerConnection(int index)
    {
        return players[index].connection;
    }

    public bool IsPlayerConnected(NetworkConnection conn)
    {
        for (int i = 0; i < max_capacity; i++)
        {
            if(players[i].connection == conn)
            return true;
        }
        return false;
    }

    public bool RemovePlayer(NetworkConnection conn)
    {
        for (int i = 0; i < max_capacity; i++)
        {
            if(players[i].connection == conn)
            {
                players.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public GameObject GetGameObject(int index)
    {
        return players[index].gameobject;
    }

    public GameObject GetGameObject(NetworkConnection conn)
    {
        for (int i = 0; i < max_capacity; i++)
        {
            if(players[i].connection == conn)
            {
                return players[i].gameobject;
            }
        }
        return null;
    }

    public bool isFull()
    {
        return players.Count >= max_capacity;
    }

    }
}
