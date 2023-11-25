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

namespace MOD_aeYCNy.form
{
    public partial class NpcForm : Form
    {

        //气运集合
        Il2CppSystem.Collections.Generic.Dictionary<String,DataUnit.UnitInfoData> allUnitList = null;

        //列表数据
        DataTable dataTable = null;

        public NpcForm()
        {
            InitializeComponent();
            try {
                allUnitList = g.data.unit.allUnit;
                dataTable = new DataTable();
                dataTable.Columns.Add("id", typeof(string));
                dataTable.Columns.Add("name", typeof(string));
                
                foreach (Il2CppSystem.Collections.Generic.KeyValuePair<String, DataUnit.UnitInfoData> unitDic in allUnitList)
                {
                    DataUnit.UnitInfoData unitDate = unitDic.value;
                    dataTable.Rows.Add(unitDic.key, GameTool.LS(unitDate.propertyData.GetName()));
                }
                NPCListBox.DataSource = dataTable;
                NPCListBox.DisplayMember = "name";
                NPCListBox.ValueMember = "id";
                NPCListBox.SelectionMode = SelectionMode.One;
            } catch(Exception e) {
                MelonLogger.Msg("初始化失败:" + e.Message);
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            String searchStr = textBox1.Text;
            if (String.IsNullOrEmpty(searchStr))
            {
                NPCListBox.DataSource = dataTable;
            }
            else
            {
                EnumerableRowCollection<DataRow> dataRows = dataTable.AsEnumerable().Where(r => r.Field<String>("name").Contains(searchStr));
                DataTable tempable = new DataTable();
                tempable.Columns.Add("id", typeof(string));
                tempable.Columns.Add("name", typeof(string));
                foreach (DataRow dataRow in dataRows)
                {
                    tempable.ImportRow(dataRow);
                }
                NPCListBox.DataSource = tempable;
            }
        }

        private void NPCListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView id = (DataRowView)NPCListBox.SelectedItem;
            DataUnit.UnitInfoData unitInfo = g.data.unit.GetUnit(id["id"].ToString());
            unitInfo.propertyData.
        }
    }
}
