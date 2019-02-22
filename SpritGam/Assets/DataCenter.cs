using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataCenter : MonoBehaviour {

    public Data.Inventory inventory = new Data.Inventory();
    public Data.AstroidMinerController miner_controller = new Data.AstroidMinerController();

    private void Start()
    {
        inventory.Init();
    }

    public void FixedUpdate()
    {
        miner_controller.handleGameTick();
    }
}

namespace Data
{
    public class Inventory
    {
        public static List<Item> Items = new List<Item>();

        public void Init()
        {
            get_items_from_save_state();
        }

        private void get_items_from_save_state()
        {
            Items.Add(new Item("Oxygen", 690));
            Items.Add(new Item("Hydrogen", 420));
        }
    }

    public class AstroidMinerController
    {
        public AstroidMiner miner_one = new AstroidMiner("miner_one", 0.01f);
        public AstroidMiner miner_dos = new AstroidMiner("miner_dos", 0.001f);
        public AstroidMiner miner_tre = new AstroidMiner("miner_tre", 0.0001f);
        public AstroidMiner miner_qua = new AstroidMiner("miner_qua", 0.00001f);
 
        public void handleGameTick()
        {
            miner_one.attempt_to_mine(); 
            miner_dos.attempt_to_mine();
            miner_tre.attempt_to_mine();
            miner_qua.attempt_to_mine();
        }
    }
}

public class AstroidMiner
{
    public string name;
    private float chance_per_ms;
    private float last_mine_time;

    public AstroidMiner(string _name, float _chance_per_ms)
    {
        name = _name;
        chance_per_ms = _chance_per_ms;
    }

    public bool attempt_to_mine()
    {
        float time = get_time();
        float rand = Random.Range(0.0f, 1.0f);

        if (rand < time * chance_per_ms)
        {
            last_mine_time = GameTime.CurrentTimeUnix;
            return true;
        }

        return false;
    }

    private float get_time()
    {
        if (last_mine_time == 0)
        {
            last_mine_time = GameTime.CurrentTimeUnix;
        }

        float time = GameTime.CurrentTimeUnix;


        return time - last_mine_time;
    }
}

public class Item
{
    public string name;
    public int count;

    public Item(string _name, int _count = 0)
    {
        name = _name;
        count = _count;
    }
}

