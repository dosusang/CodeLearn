using UnityEngine;
using QFramework;
using System.Collections.Generic;

namespace QFramework.Example {
    public class GameDefine:Singleton<GameDefine>  {

        public Vector3 CAR_FORWOARD = new Vector3(0, -180, 0);
        public int MAP_RIDIS = 4;
        public Vector3 BAD_POS = new Vector3(999, 999, 999);
        public float GrassH = -0.2f;
        public float GemH = 0.4f;
        public float RockH = -0.2f;
        public float TreeH = 0.6f;
        public string AudioPathPrefix = "resources://Audio/";

        public Dictionary<ItemType, float> ItemTypeToH = new Dictionary<ItemType, float>();

        public override void OnSingletonInit() {
            ItemTypeToH[ItemType.GRASS] = -0.2f;
            ItemTypeToH[ItemType.GEM] = 0.4f;
            ItemTypeToH[ItemType.ROCK] = -0.2f;
            ItemTypeToH[ItemType.TREE] = 0.6f;
        }
        GameDefine() {

        }
    }
}

