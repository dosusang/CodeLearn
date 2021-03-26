using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageCreator : MonoBehaviour {

    public Tilemap tilemap;//引用的Tilemap
    public Tile baseTile;//使用的最基本的Tile，我这里是白色块，然后根据数据设置不同颜色生成不同Tile
    Tile[] arrTiles;//生成的Tile数组

    Dictionary<Vector3Int, int> tileType = new Dictionary<Vector3Int, int>();
    Dictionary<TileBase, string> Names = new Dictionary<TileBase, string>();
    void Awake() {
        //ins = this;
    }
    void Start() {
        InitData();
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PrintInfos();
        }
        //销毁墙体
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 wordPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(wordPosition);
            //tilemap.SetTile(cellPosition, gameUI.GetSelectColor().colorData.mTile);
            TileBase tb = tilemap.GetTile(cellPosition);
            if (tb == null) {
                return;
            }
            //tb.hideFlags = HideFlags.None;
            //Debug.Log("鼠标坐标" + mousePosition + "世界" + wordPosition + "cell" + cellPosition + "tb" + tb.name);
            //某个地方设置为空，就是把那个地方小格子销毁了
            tileType.Remove(cellPosition);
            tilemap.SetTile(cellPosition, null);
            //tilemap.RefreshAllTiles();
        }

        //空白地方创造墙体
        if (Input.GetMouseButtonDown(1)) {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 wordPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(wordPosition);
            //tilemap.SetTile(cellPosition, gameUI.GetSelectColor().colorData.mTile);
            TileBase tb = tilemap.GetTile(cellPosition);
            if (tb != null) {
                tileType[cellPosition]++;
                tilemap.SetTile(cellPosition, arrTiles[tileType[cellPosition]%5]);
                return;
            }

            tileType.Add(cellPosition, 0);

            tilemap.SetTile(cellPosition, arrTiles[tileType[cellPosition]]);
            //tilemap.RefreshAllTiles();
        }
    }

    private void PrintInfos() {
        int count = 0;
        string s = "\n";
        for (int i = -4; i <= 4; i++) {
            for (int j = -4; j <= 4; j++) {
                var tile = tilemap.GetTile(new Vector3Int(i, j, 0));
                if (tile != null) {
                    s += string.Format("stage.Items[{0}].Pos.Set({1}, 0, {2}); stage.Items[{0}].ItemType = ItemType.{3};", count, i, j, Names[tile]) + "\n";
                    count++;
                }
            }
        }

        s = string.Format("stage.Items = new ItemInfo[{0}];", count) + s;
        Debug.Log(s);
    }


    ///
    /// 地图生成
    ///
    ///
    void InitData() {
        int colorCount = 6;
        arrTiles = new Tile[colorCount];
        for (int i = 0; i < colorCount; i++) {
            arrTiles[i] = (Tile)ScriptableObject.CreateInstance("Tile");//创建Tile，注意，要使用这种方式
            arrTiles[i].sprite = baseTile.sprite;
        }
        arrTiles[0].color = new Color(0, 0, 0, 1); //边界 黑色
        Names.Add(arrTiles[0], "EDGE_ERROR");
        arrTiles[1].color = new Color(0, 0.5f, 0, 1); //草 墨绿
        Names.Add(arrTiles[1], "GRASS");
        arrTiles[2].color = new Color(0.5f, 0.5f, 0.5f, 1); //石头灰色
        Names.Add(arrTiles[2], "ROCK");
        arrTiles[3].color = new Color(1, 1, 1, 0.5f); //钻石 白色半透明
        Names.Add(arrTiles[3], "GEM");
        arrTiles[4].color = new Color(0, 2, 0, 1); //树 绿色//
        Names.Add(arrTiles[4], "TREE");


        for (int i = -5; i <= 5; i++) {
            for(int j = -5; j <= 5; j++) {
                if (Mathf.Abs(i) == 5 || Mathf.Abs(j) == 5) {
                    tilemap.SetTile(new Vector3Int(i,j,0), arrTiles[0]);
                }
            }
        }
    }

}