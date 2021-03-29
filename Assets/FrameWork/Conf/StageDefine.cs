using UnityEngine;
namespace QFramework.Example {
    public class StageDefine: Singleton<StageDefine>  {


        public struct StageInfo {
            public string StageName;
            public OrderType[] orders;
            public ItemInfo[] Items;
        }

        public struct ItemInfo {
            public Vector3 Pos;
            public ItemType ItemType;
        }

        public StageInfo[] stages = new StageInfo[30];
        public override void OnSingletonInit() {
            var stage = stages[0];
            stage.StageName = "始于足下";
            stage.orders = new OrderType[1];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.Items = new ItemInfo[1];
            stage.Items[0].Pos.Set(-4, 0, -3); stage.Items[0].ItemType = ItemType.GRASS;
            stages[0] = stage;

            stage = stages[1];
            stage.StageName = "事不过三";
            stage.orders = new OrderType[1];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.Items = new ItemInfo[3];
            stage.Items[0].Pos.Set(-4, 0, -3); stage.Items[0].ItemType = ItemType.GRASS;
            stage.Items[1].Pos.Set(-4, 0, -2); stage.Items[1].ItemType = ItemType.GRASS;
            stage.Items[2].Pos.Set(-4, 0, -1); stage.Items[2].ItemType = ItemType.GRASS;
            stages[1] = stage;


            stage = stages[2];
            stage.StageName = "蓦然回首";
            stage.orders = new OrderType[2];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.orders[1] = OrderType.TURN_RIGHT;
            stage.Items = new ItemInfo[2];
            stage.Items[0].Pos.Set(-4, 0, -3); stage.Items[0].ItemType = ItemType.GRASS;
            stage.Items[1].Pos.Set(-3, 0, -3); stage.Items[1].ItemType = ItemType.GRASS;
            stages[2] = stage;


            stage = stages[3];
            stage.StageName = "世界正中";
            stage.orders = new OrderType[3];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.orders[1] = OrderType.TURN_RIGHT;
            stage.orders[2] = OrderType.TRUN_LEFT;
            stage.Items = new ItemInfo[1];
            stage.Items[0].Pos.Set(0, 0, 0); stage.Items[0].ItemType = ItemType.GEM;
            stages[3] = stage;

            stage = stages[4];
            stage.StageName = "曲径通幽";
            stage.orders = new OrderType[5];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.orders[1] = OrderType.TURN_RIGHT;
            stage.orders[2] = OrderType.TRUN_LEFT;
            stage.orders[3] = OrderType.LOOP_MAIN;
            stage.orders[4] = OrderType.LOOP_TAIL;
            stage.Items = new ItemInfo[8];
            stage.Items[0].Pos.Set(-3, -0.2f, -3); stage.Items[0].ItemType = ItemType.GRASS;
            stage.Items[1].Pos.Set(-2, -0.2f, -2); stage.Items[1].ItemType = ItemType.GRASS;
            stage.Items[2].Pos.Set(-1, -0.2f, -1); stage.Items[2].ItemType = ItemType.GRASS;
            stage.Items[3].Pos.Set(0, -0.2f, 0); stage.Items[3].ItemType = ItemType.GRASS;
            stage.Items[4].Pos.Set(1, -0.2f, 1); stage.Items[4].ItemType = ItemType.GRASS;
            stage.Items[5].Pos.Set(2, -0.2f, 2); stage.Items[5].ItemType = ItemType.GRASS;
            stage.Items[6].Pos.Set(3, -0.2f, 3); stage.Items[6].ItemType = ItemType.GRASS;
            stage.Items[7].Pos.Set(4, -0.2f, 4); stage.Items[7].ItemType = ItemType.GEM;
            stages[4] = stage;
            //============================================================================================

            stage = stages[5];
            stage.StageName = "挡路石";
            stage.orders = new OrderType[5];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.orders[1] = OrderType.TURN_RIGHT;
            stage.orders[2] = OrderType.TRUN_LEFT;
            stage.orders[3] = OrderType.LOOP_MAIN;
            stage.orders[4] = OrderType.LOOP_TAIL;
            stage.Items = new ItemInfo[17];
            stage.Items[0].Pos.Set(-3, -0.2f, -3); stage.Items[0].ItemType = ItemType.ROCK;
            stage.Items[1].Pos.Set(-2, -0.2f, -3); stage.Items[1].ItemType = ItemType.ROCK;
            stage.Items[2].Pos.Set(-1, -0.2f, -3); stage.Items[2].ItemType = ItemType.ROCK;
            stage.Items[3].Pos.Set(0, -0.2f, -3); stage.Items[3].ItemType = ItemType.ROCK;
            stage.Items[4].Pos.Set(1, -0.2f, -3); stage.Items[4].ItemType = ItemType.ROCK;
            stage.Items[5].Pos.Set(2, -0.2f, -3); stage.Items[5].ItemType = ItemType.ROCK;
            stage.Items[6].Pos.Set(3, -0.2f, -3); stage.Items[6].ItemType = ItemType.ROCK;
            stage.Items[7].Pos.Set(-4, -0.2f, -3); stage.Items[7].ItemType = ItemType.ROCK;
            stage.Items[8].Pos.Set(4, -0.2f, -1); stage.Items[8].ItemType = ItemType.ROCK;
            stage.Items[9].Pos.Set(-3, -0.2f, -1); stage.Items[9].ItemType = ItemType.ROCK;
            stage.Items[10].Pos.Set(-2, -0.2f, -1); stage.Items[10].ItemType = ItemType.ROCK;
            stage.Items[11].Pos.Set(-1, -0.2f, -1); stage.Items[11].ItemType = ItemType.ROCK;
            stage.Items[12].Pos.Set(0, -0.2f, -1); stage.Items[12].ItemType = ItemType.ROCK;
            stage.Items[13].Pos.Set(1, -0.2f, -1); stage.Items[13].ItemType = ItemType.ROCK;
            stage.Items[14].Pos.Set(2, -0.2f, -1); stage.Items[14].ItemType = ItemType.ROCK;
            stage.Items[15].Pos.Set(3, -0.2f, -1); stage.Items[15].ItemType = ItemType.ROCK;
            stage.Items[16].Pos.Set(-4, -0.2f, 1); stage.Items[16].ItemType = ItemType.GEM;
            stages[5] = stage;

            stage = stages[6];
            stage.StageName = "挡路石";
            stage.orders = new OrderType[5];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.orders[1] = OrderType.TURN_RIGHT;
            stage.orders[2] = OrderType.TRUN_LEFT;
            stage.orders[3] = OrderType.LOOP_MAIN;
            stage.orders[4] = OrderType.LOOP_TAIL;
            stage.Items = new ItemInfo[30];
            stage.Items[0].Pos.Set(-4, 0, 0); stage.Items[0].ItemType = ItemType.ROCK;
            stage.Items[1].Pos.Set(-3, 0, -4); stage.Items[1].ItemType = ItemType.GRASS;
            stage.Items[2].Pos.Set(-3, 0, 0); stage.Items[2].ItemType = ItemType.ROCK;
            stage.Items[3].Pos.Set(-2, 0, -4); stage.Items[3].ItemType = ItemType.GRASS;
            stage.Items[4].Pos.Set(-2, 0, 0); stage.Items[4].ItemType = ItemType.ROCK;
            stage.Items[5].Pos.Set(-1, 0, -4); stage.Items[5].ItemType = ItemType.GRASS;
            stage.Items[6].Pos.Set(-1, 0, 0); stage.Items[6].ItemType = ItemType.ROCK;
            stage.Items[7].Pos.Set(0, 0, -4); stage.Items[7].ItemType = ItemType.ROCK;
            stage.Items[8].Pos.Set(0, 0, -3); stage.Items[8].ItemType = ItemType.ROCK;
            stage.Items[9].Pos.Set(0, 0, -2); stage.Items[9].ItemType = ItemType.ROCK;
            stage.Items[10].Pos.Set(0, 0, -1); stage.Items[10].ItemType = ItemType.ROCK;
            stage.Items[11].Pos.Set(0, 0, 0); stage.Items[11].ItemType = ItemType.ROCK;
            stage.Items[12].Pos.Set(0, 0, 1); stage.Items[12].ItemType = ItemType.ROCK;
            stage.Items[13].Pos.Set(0, 0, 2); stage.Items[13].ItemType = ItemType.ROCK;
            stage.Items[14].Pos.Set(0, 0, 3); stage.Items[14].ItemType = ItemType.ROCK;
            stage.Items[15].Pos.Set(0, 0, 4); stage.Items[15].ItemType = ItemType.ROCK;
            stage.Items[16].Pos.Set(1, 0, -4); stage.Items[16].ItemType = ItemType.GRASS;
            stage.Items[17].Pos.Set(1, 0, 0); stage.Items[17].ItemType = ItemType.ROCK;
            stage.Items[18].Pos.Set(2, 0, -4); stage.Items[18].ItemType = ItemType.GRASS;
            stage.Items[19].Pos.Set(2, 0, -3); stage.Items[19].ItemType = ItemType.GRASS;
            stage.Items[20].Pos.Set(2, 0, -2); stage.Items[20].ItemType = ItemType.GRASS;
            stage.Items[21].Pos.Set(2, 0, -1); stage.Items[21].ItemType = ItemType.GRASS;
            stage.Items[22].Pos.Set(2, 0, 0); stage.Items[22].ItemType = ItemType.ROCK;
            stage.Items[23].Pos.Set(2, 0, 1); stage.Items[23].ItemType = ItemType.GRASS;
            stage.Items[24].Pos.Set(2, 0, 2); stage.Items[24].ItemType = ItemType.GEM;
            stage.Items[25].Pos.Set(2, 0, 3); stage.Items[25].ItemType = ItemType.GEM;
            stage.Items[26].Pos.Set(3, 0, 0); stage.Items[26].ItemType = ItemType.ROCK;
            stage.Items[27].Pos.Set(3, 0, 2); stage.Items[27].ItemType = ItemType.GEM;
            stage.Items[28].Pos.Set(3, 0, 3); stage.Items[28].ItemType = ItemType.GEM;
            stage.Items[29].Pos.Set(4, 0, 0); stage.Items[29].ItemType = ItemType.ROCK;

            stages[6] = stage;

            stage = stages[7];
            stage.StageName = "关卡8";
            stage.orders = new OrderType[1];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.Items = new ItemInfo[1];
            stage.Items[0].Pos.Set(-4, 0, -3); stage.Items[0].ItemType = ItemType.GRASS;
            stages[7] = stage;

            stage = stages[8];
            stage.StageName = "关卡9";
            stage.orders = new OrderType[1];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.Items = new ItemInfo[1];
            stage.Items[0].Pos.Set(-4, 0, -3); stage.Items[0].ItemType = ItemType.GRASS;
            stages[8] = stage;

            stage = stages[9];
            stage.StageName = "关卡10";
            stage.orders = new OrderType[1];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.Items = new ItemInfo[1];
            stage.Items[0].Pos.Set(-4, 0, -3); stage.Items[0].ItemType = ItemType.GRASS;
            stages[9] = stage;

            stage = stages[10];
            stage.StageName = "关卡11";
            stage.orders = new OrderType[1];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.Items = new ItemInfo[1];
            stage.Items[0].Pos.Set(-4, 0, -3); stage.Items[0].ItemType = ItemType.GRASS;
            stages[10] = stage;

            stage = stages[11];
            stage.StageName = "关卡12";
            stage.orders = new OrderType[1];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.Items = new ItemInfo[1];
            stage.Items[0].Pos.Set(-4, 0, -3); stage.Items[0].ItemType = ItemType.GRASS;
            stages[11] = stage;

            stage = stages[12];
            stage.StageName = "关卡13";
            stage.orders = new OrderType[1];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.Items = new ItemInfo[1];
            stage.Items[0].Pos.Set(-4, 0, -3); stage.Items[0].ItemType = ItemType.GRASS;
            stages[12] = stage;

            stage = stages[13];
            stage.StageName = "关卡14";
            stage.orders = new OrderType[1];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.Items = new ItemInfo[1];
            stage.Items[0].Pos.Set(-4, 0, -3); stage.Items[0].ItemType = ItemType.GRASS;
            stages[13] = stage;

            stage = stages[14];
            stage.StageName = "关卡15";
            stage.orders = new OrderType[1];
            stage.orders[0] = OrderType.MOVE_FORWARD;
            stage.Items = new ItemInfo[1];
            stage.Items[0].Pos.Set(-4, 0, -3); stage.Items[0].ItemType = ItemType.GRASS;
            stages[14] = stage;
        }
        StageDefine() {
            

        }

    }
}