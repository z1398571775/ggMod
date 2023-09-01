using MelonLoader;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            
            foreach (ConfItemTypeItem item in itemTypeItems)
            {
                MelonLogger.Msg("唯一标识 " + " ========== " + item.id);
                MelonLogger.Msg("类型名称  " + " ========== " + GameTool.LS(item.name));
                MelonLogger.Msg("排序  " + " ========== " + item.sort);
                MelonLogger.Msg("所属大类   " + " ========== " + item.type);
                MelonLogger.Msg("UI显示分类   " + " ========== " + item.uiLabel);
            }


            
            foreach (ConfItemLevelDescItem item in itemLevelDescItems)
            {
                MelonLogger.Msg("唯一标识 " + " ========== " + item.id);
                MelonLogger.Msg("品质描述 " + " ========== " + GameTool.LS(item.desc));
            }

            
            //foreach (ConfItemPropsItem item in itemList)
            //{
            //    item.id
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
            dataTable.Columns.Add("name",typeof(string));
            foreach (ConfItemPropsItem item in itemList)
            {
                dataTable.Rows.Add(item.id, GameTool.LS(item.name));
            }
            itemListBox.DataSource = dataTable;
            itemListBox.DisplayMember = "name";
            itemListBox.ValueMember = "id";
            itemListBox.SelectionMode = SelectionMode.One;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
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
    }
}
