using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFramework;
using DG.Tweening;

namespace QFramework.Example {

    public class GameMode1Manager : MonoSingleton<GameMode1Manager> {
        [SerializeField]
        private GameObject Grass;
        [SerializeField]
        private GameObject Gem;
        [SerializeField]
        private GameObject Rock;
        [SerializeField]
        private GameObject Tree;
        [SerializeField]
        private GameObject Car;
        [SerializeField]
        private Camera MainCamera;

        private UIMain uIMain;

        public BaseOrderExcuter Excuter;
        public int NowStage;
        private void Awake() {
            ResMgr.Init();
            InitAudio();
        }
        // Start is called before the first frame update

        private void InitAudio() {
            AudioKit.MusicPlayer.SetVolume(GameDataManager.GetFloat("MucisValue"));
            AudioKit.VoicePlayer.SetVolume(GameDataManager.GetFloat("SoundValue"));
        }
        void Start() {
            UIKit.OpenPanel("UIMenu");

            //test
            //GameStart(6);
        }

        public void GameStart(int id) {
            NowStage = id;
            uIMain = (UIMain)UIKit.OpenPanel("UIMain");
            this.Delay(0.1f, () => {
                CreateGrass();
                CreateCar();
                SetOrder(id);
                MoveCam();
            });

        }

        public void NextStage() {
            NowStage = NowStage + 1;
            QEventSystem.SendEvent(EventDefine.MainGameEvent.StageEnd);
            MoveCam(-1);
            uIMain.FadeClose();
            this.Delay(1.8f, () => {
                uIMain = (UIMain)UIKit.OpenPanel("UIMain");         
            });
            this.Delay(2.0f, () => {
                CreateGrass();
                CreateCar();
                SetOrder(NowStage);
                MoveCam();
            });
        }

        void SetOrder(int id) {
            uIMain.SetStageName(StageDefine.Instance.stages[id].StageName);
            var orderBase = uIMain.OrderBase.GetComponent<OrderBase>();
            var ordersNeed = StageDefine.Instance.stages[id].orders;
            Log.I(ordersNeed);
            orderBase.CheckOrders(ordersNeed);
        }
        public void CreateGrass() {
            var grassRoot = GameObject.Find("GrassRoot");
            var blockRoot = GameObject.Find("BlockRoot");

            grassRoot.DestroyChildren();
            blockRoot.DestroyChildren();
            //create Grass
            var Items = StageDefine.Instance.stages[NowStage].Items;
            for (int i = 0; i < Items.Length; i++) {
                GameObject obj;

                if (Items[i].ItemType == ItemType.GRASS) {
                    obj = Instantiate(Grass, grassRoot.transform);
                } else if (Items[i].ItemType == ItemType.GEM) {
                    obj = Instantiate(Gem, grassRoot.transform);
                } else if (Items[i].ItemType == ItemType.ROCK) {
                    obj = Instantiate(Rock, blockRoot.transform);
                } else {//tree
                    obj = Instantiate(Tree, blockRoot.transform);
                }
                obj.transform.localScale = Vector3.one;
                obj.transform.position = Items[i].Pos;
                var pos = obj.transform.position;
                pos.y = GameDefine.Instance.ItemTypeToH[Items[i].ItemType];
                obj.transform.position = pos;
            }

        }

        void CreateCar() {
            var copy = Instantiate(Car, transform);
            copy.transform.localScale = new Vector3(2, 2, 2);
            copy.transform.position = new Vector3(1, 0, 0);
            Excuter = copy.GetComponent<BaseOrderExcuter>();
        }
        void MoveCam(int pram = 1) {
            MainCamera.transform.DORotate(new Vector3(pram * 30, 0, 0), 2);
        }

        public void QuitStage() {
            QEventSystem.SendEvent(EventDefine.MainGameEvent.StageEnd);
            MoveCam(-1);
            uIMain.FadeClose();
            UIKit.OpenPanel("UISelectStage");
        }

        public bool CheckClear() {
            var grassRoot = GameObject.Find("GrassRoot");
            return grassRoot.transform.childCount == 0;
        }

        public override void OnSingletonInit() {

        }
        public override void Dispose() {

        }
    }
}
