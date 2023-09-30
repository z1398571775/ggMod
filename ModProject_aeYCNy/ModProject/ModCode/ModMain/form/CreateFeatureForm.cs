using MelonLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ILLGEN = Il2CppSystem.Collections.Generic;

namespace MOD_aeYCNy.form
{
    public partial class CreateFeatureForm : Form
    {
        //气运集合
        Il2CppSystem.Collections.Generic.List<ConfRoleCreateFeatureItem> allLuckList = null;

        //列表数据
        DataTable dataTable = null;

        public CreateFeatureForm()
        {
            InitializeComponent();
            try {
                lockLuckNum.Maximum = int.MaxValue;
                concealNum.Maximum = int.MaxValue;
                groupNum.Maximum = int.MaxValue;
                levelNum.Maximum = int.MaxValue;
                refreshTypeNum.Maximum = int.MaxValue;
                weightNum.Maximum = int.MaxValue;
                typeNum.Maximum = int.MaxValue;

                allLuckList = g.conf.roleCreateFeature._allConfList;
                dataTable = new DataTable();
                dataTable.Columns.Add("id", typeof(int));
                dataTable.Columns.Add("name", typeof(string));
                foreach (ConfRoleCreateFeatureItem luck in allLuckList)
                {
                   
                    dataTable.Rows.Add(luck.id, GameTool.LS(luck.name));
                }
                luckListBox.DataSource = dataTable;
                luckListBox.DisplayMember = "name";
                luckListBox.ValueMember = "id";
                luckListBox.SelectionMode = SelectionMode.One;
            }
            catch (Exception e) {
                MelonLogger.Msg("初始化失败:" + e.Message);
            }        
            
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            String searchStr = textBox1.Text;
            if (String.IsNullOrEmpty(searchStr))
            {
                luckListBox.DataSource = dataTable;
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
                luckListBox.DataSource = tempable;
            }
        }

        private void luckListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView id = (DataRowView)luckListBox.SelectedItem;
            ConfRoleCreateFeatureItem roleCreateFeatureItem = g.conf.roleCreateFeature.GetItem(int.Parse(id["id"].ToString()));
            concealNum.Value = roleCreateFeatureItem.conceal;
            durationTextBox.Text = GameTool.LS(roleCreateFeatureItem.duration);
            effectTextBox.Text = GameTool.LS(roleCreateFeatureItem.effect);
            groupNum.Value = roleCreateFeatureItem.group;
            iconAndDescTextBox.Text = GameTool.LS(roleCreateFeatureItem.iconAndDesc);
            introduceTextTextBox.Text = GameTool.LS(roleCreateFeatureItem.introduceText);
            levelNum.Value = roleCreateFeatureItem.level;
            lockLuckNum.Value = roleCreateFeatureItem.lockLuck;
            nameTextBox.Text = GameTool.LS(roleCreateFeatureItem.name);
            refreshTypeNum.Value = roleCreateFeatureItem.refreshType;
            weightNum.Value = roleCreateFeatureItem.weight;
            typeNum.Value = roleCreateFeatureItem.type;
            tipsTextBox.Text = GameTool.LS(roleCreateFeatureItem.tips);
        }
    }
}
