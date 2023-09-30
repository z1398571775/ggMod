using MelonLoader;
using System;
using System.Reflection;
using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UIBattleInfoBase;
using static Il2CppSystem.Linq.Expressions.Interpreter.CastInstruction.CastInstructionNoT;

namespace MOD_aeYCNy.form
{
    public partial class ItemForm : Form
    {
        //private static HarmonyLib.Harmony harmony;

        //物品
        Il2CppSystem.Collections.Generic.List<ConfItemPropsItem> itemList = null;
        //物品品质字典
        Il2CppSystem.Collections.Generic.List<ConfItemLevelDescItem> itemLevelDescItems = null;
        //物品类型字典
        Il2CppSystem.Collections.Generic.List<ConfItemTypeItem> itemTypeItems = null;
        //列表数据
        DataTable dataTable = null;
        public ItemForm()
        {

            InitializeComponent();
            
            //物品
            itemList = g.conf.itemProps._allConfList;
            //物品品质字典
            itemLevelDescItems = g.conf.itemLevelDesc._allConfList;
            //物品类型字典
            itemTypeItems = g.conf.itemType._allConfList;

            try
            {

                ConfFateFeatureItem confFateFeatureItem = new ConfFateFeatureItem();
                //初始化物品类型下拉选
                DataTable typeData = new DataTable();
                typeData.Columns.Add("id", typeof(int));
                typeData.Columns.Add("name", typeof(string));
                foreach (ConfItemTypeItem item in itemTypeItems)
                {
                    typeData.Rows.Add(item.id, GameTool.LS(item.name));

                    //MelonLogger.Msg("唯一标识 " + " ========== " + item.id);
                    //MelonLogger.Msg("类型名称  " + " ========== " + GameTool.LS(item.name));
                    //MelonLogger.Msg("排序  " + " ========== " + item.sort);
                    //MelonLogger.Msg("所属大类   " + " ========== " + item.type);
                    //MelonLogger.Msg("UI显示分类   " + " ========== " + item.uiLabel);
                }
                typeSelect.DataSource = typeData;
                typeSelect.DisplayMember = "name";
                typeSelect.ValueMember = "id";

                //初始化物品品质下拉选
                DataTable levelData = new DataTable();
                levelData.Columns.Add("id", typeof(int));
                levelData.Columns.Add("name", typeof(string));
                foreach (ConfItemLevelDescItem item in itemLevelDescItems)
                {
                    levelData.Rows.Add(item.id, GameTool.LS(item.desc));
                    //MelonLogger.Msg("唯一标识 " + " ========== " + item.id);
                    //MelonLogger.Msg("品质描述 " + " ========== " + GameTool.LS(item.desc));
                }
                levelSelect.DataSource = levelData;
                levelSelect.DisplayMember = "name";
                levelSelect.ValueMember = "id";


                //foreach (ConfItemPropsItem item in itemList)
                //{
                   
                //    MelonLogger.Msg("是否可拍卖 " + " ========== " + item.auction);
                //    MelonLogger.Msg("物品分类  " + " ========== " + item.className);
                //    MelonLogger.Msg("物品说明  " + " ========== " + GameTool.LS(item.desc));
                //    MelonLogger.Msg("死亡掉落   " + " ========== " + item.dieDrop);
                //    MelonLogger.Msg("是否允许丢弃    " + " ========== " + item.drop);
                //    MelonLogger.Msg("是否隐藏     " + " ========== " + item.hide);
                //    MelonLogger.Msg("物品图标      " + " ========== " + item.icon);
                //    MelonLogger.Msg("可否翻倍产出       " + " ========== " + item.isMultiDrop);
                //    MelonLogger.Msg("是否叠加        " + " ========== " + item.isOverlay);
                //    MelonLogger.Msg("物品品质         " + " ========== " + item.level);
                //    MelonLogger.Msg("物品名称          " + " ========== " + GameTool.LS(item.name));
                //    MelonLogger.Msg("NPC背包是否强制显示           " + " ========== " + item.npcShow);
                //    MelonLogger.Msg("玩家背包是否强制显示            " + " ========== " + item.playerShow);
                //    MelonLogger.Msg("出售价格             " + " ========== " + item.sale);
                //    MelonLogger.Msg("物品类型              " + " ========== " + item.type);
                //    MelonLogger.Msg("道具价值               " + " ========== " + item.worth);
                //    MelonLogger.Msg("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                //}
                dataTable = new DataTable();
                dataTable.Columns.Add("id", typeof(int));
                dataTable.Columns.Add("name", typeof(string));
                foreach (ConfItemPropsItem item in itemList)
                {
                    dataTable.Rows.Add(item.id, GameTool.LS(item.name));
                }
                itemListBox.DataSource = dataTable;
                itemListBox.DisplayMember = "name";
                itemListBox.ValueMember = "id";
                itemListBox.SelectionMode = SelectionMode.One;

                saleNum.Maximum = int.MaxValue;
                worthNum.Maximum = int.MaxValue;
            }
            catch (Exception ex)
            {
                MelonLogger.Msg("初始化失败:"+ex.Message);
            }
            MelonLogger.Msg("初始化结束");
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            MelonLogger.Msg("搜索按钮被点击");
            String searchStr = textBox1.Text;
            if (String.IsNullOrEmpty(searchStr))
            {
                itemListBox.DataSource = dataTable;
            }
            else 
            {
                EnumerableRowCollection<DataRow> dataRows = dataTable.AsEnumerable().Where(r => r.Field<String>("name").Contains(searchStr));
                DataTable tempable = new DataTable();
                tempable.Columns.Add("id", typeof(int));
                tempable.Columns.Add("name", typeof(string));
                foreach (DataRow dataRow in dataRows)
                {
                    tempable.ImportRow(dataRow);
                }
                itemListBox.DataSource = tempable;
            }
            

        }

        private void itemListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView id = (DataRowView)itemListBox.SelectedItem;
            ConfItemPropsItem confItemPropsItem = g.conf.itemProps.GetItem(int.Parse(id["id"].ToString()));
            nameText.Text = GameTool.LS(confItemPropsItem.name);
            auctionNum.Value = confItemPropsItem.auction;
            classNameText.Text = confItemPropsItem.className.ToString();
            descText.Text = GameTool.LS(confItemPropsItem.desc);
            dieDropNum.Value = confItemPropsItem.dieDrop;
            dropNum.Value = confItemPropsItem.drop;
            hideNum.Value = confItemPropsItem.hide;
            iconText.Text = confItemPropsItem.icon;
            isMultiDropNum.Value = confItemPropsItem.isMultiDrop;
            isOverlayNum.Value = confItemPropsItem.isOverlay;
            levelSelect.SelectedValue = confItemPropsItem.level;
            npcShowNum.Value = confItemPropsItem.npcShow;
            playerShowNum.Value = confItemPropsItem.playerShow;
            saleNum.Value = confItemPropsItem.sale;
            typeSelect.SelectedValue = confItemPropsItem.type;
            worthNum.Value = confItemPropsItem.worth;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            System.Data.DataRowView id = (System.Data.DataRowView)itemListBox.SelectedItem;
            ConfItemPropsItem confItemPropsItem = g.conf.itemProps.GetItem(int.Parse(id["id"].ToString()));
            
            confItemPropsItem.auction  = (int)auctionNum.Value;
            //classNameText.Text = confItemPropsItem.className.ToString();

            confItemPropsItem.dieDrop = (int)dieDropNum.Value;
            confItemPropsItem.drop = (int)dropNum.Value;
            confItemPropsItem.hide = (int)hideNum.Value;
            //iconText.Text = confItemPropsItem.icon;
            confItemPropsItem.isMultiDrop = (int)isMultiDropNum.Value;
            confItemPropsItem.isOverlay = (int)isOverlayNum.Value;
            confItemPropsItem.level = int.Parse(levelSelect.SelectedValue.ToString());
            confItemPropsItem.npcShow = (int)npcShowNum.Value;
            confItemPropsItem.playerShow = (int)playerShowNum.Value;
            confItemPropsItem.sale = (int)saleNum.Value;
            confItemPropsItem.type = int.Parse(typeSelect.SelectedValue.ToString());
            confItemPropsItem.worth = (int)worthNum.Value;
        }


        /**
         * 
         * 
         * 
         * 
         * 重新获取数据
         * 
         */
        private void reload() 
        {

        }
    }
}
