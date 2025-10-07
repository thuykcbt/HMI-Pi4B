using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DevExpress.XtraEditors.Filtering;

namespace Design_Form.User_PLC
{
    public partial class ModelPLC: UserControl
    {
        public int index_select_model;
        private ContextMenuStrip treeContextMenu;
        public ModelPLC()
        {
            InitializeComponent();
            loadtre_model();
            InitializeContextMenu();
            index_select_model = Job_Model.Statatic_Model.config_machine.model_plc_machine.number_model_run;
        }
        private void InitializeContextMenu()
        {
            // Tạo ContextMenuStrip
            treeContextMenu = new ContextMenuStrip();

            // Thêm các mục vào menu
          //  ToolStripMenuItem addItem = new ToolStripMenuItem("Thêm Node", null, AddNode_Click);
            ToolStripMenuItem removeItem = new ToolStripMenuItem("Delete", null, RemoveNode_Click);

           // treeContextMenu.Items.Add(addItem);
            treeContextMenu.Items.Add(removeItem);

            // Gán ContextMenuStrip cho TreeView
            treeView1.ContextMenuStrip = treeContextMenu;
        }
        private void RemoveNode_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                Job_Model.Statatic_Model.config_machine.model_plc_machine.names_model.RemoveAt(index_select_model);
                loadtre_model();

            }

            //treeView1.Nodes.Remove(treeView1.SelectedNode);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength!=0)
            {
                Job_Model.Statatic_Model.config_machine.model_plc_machine.names_model.Add(textBox1.Text);
                textBox1.Clear();
                loadtre_model();
            }    
        }
        public void loadtre_model()
        {
            try 
            {
                treeView1.Nodes.Clear();
                for(int i=0;i < Job_Model.Statatic_Model.config_machine.model_plc_machine.names_model.Count;i++)
                {
                    TreeNode Node = new TreeNode();
                    Node.Text = "Model" + (i+1).ToString() + ": "+ Job_Model.Statatic_Model.config_machine.model_plc_machine.names_model[i];
                    Node.Name = (i).ToString();
                    treeView1.Nodes.Add(Node);
                }    
            }
            catch(Exception ex)
            {
                Job_Model.Statatic_Model.wirtelog.Log(ex.ToString());
                MessageBox.Show("Error load model : " + ex.ToString());
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            index_select_model = selectedNode.Index;
        }
    }
}
