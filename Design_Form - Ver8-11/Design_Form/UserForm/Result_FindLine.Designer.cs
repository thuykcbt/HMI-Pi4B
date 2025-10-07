namespace Design_Form.UserForm
{
    partial class Result_FindLine
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.text_StartX = new System.Windows.Forms.TextBox();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.Start_Y = new System.Windows.Forms.TextBox();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Center_X = new System.Windows.Forms.TextBox();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Center_Y = new System.Windows.Forms.TextBox();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.End_X = new System.Windows.Forms.TextBox();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.End_Y = new System.Windows.Forms.TextBox();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.End_Y);
            this.layoutControl1.Controls.Add(this.End_X);
            this.layoutControl1.Controls.Add(this.Center_Y);
            this.layoutControl1.Controls.Add(this.Center_X);
            this.layoutControl1.Controls.Add(this.Start_Y);
            this.layoutControl1.Controls.Add(this.text_StartX);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(945, 263);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(945, 263);
            this.Root.TextVisible = false;
            // 
            // text_StartX
            // 
            this.text_StartX.Location = new System.Drawing.Point(99, 12);
            this.text_StartX.Name = "text_StartX";
            this.text_StartX.ReadOnly = true;
            this.text_StartX.Size = new System.Drawing.Size(371, 20);
            this.text_StartX.TabIndex = 4;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.text_StartX;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(462, 24);
            this.layoutControlItem1.Text = "Start_X_Point";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(75, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(925, 171);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Start_Y
            // 
            this.Start_Y.Location = new System.Drawing.Point(561, 12);
            this.Start_Y.Name = "Start_Y";
            this.Start_Y.ReadOnly = true;
            this.Start_Y.Size = new System.Drawing.Size(372, 20);
            this.Start_Y.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.Start_Y;
            this.layoutControlItem2.Location = new System.Drawing.Point(462, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(463, 24);
            this.layoutControlItem2.Text = "Start_Y_Point";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(75, 13);
            // 
            // Center_X
            // 
            this.Center_X.Location = new System.Drawing.Point(99, 36);
            this.Center_X.Name = "Center_X";
            this.Center_X.ReadOnly = true;
            this.Center_X.Size = new System.Drawing.Size(371, 20);
            this.Center_X.TabIndex = 6;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.Center_X;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(462, 24);
            this.layoutControlItem3.Text = "Center_X_Point";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(75, 13);
            // 
            // Center_Y
            // 
            this.Center_Y.Location = new System.Drawing.Point(561, 36);
            this.Center_Y.Name = "Center_Y";
            this.Center_Y.ReadOnly = true;
            this.Center_Y.Size = new System.Drawing.Size(372, 20);
            this.Center_Y.TabIndex = 7;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.Center_Y;
            this.layoutControlItem4.Location = new System.Drawing.Point(462, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(463, 24);
            this.layoutControlItem4.Text = "Center_Y_Point";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(75, 13);
            // 
            // End_X
            // 
            this.End_X.Location = new System.Drawing.Point(99, 60);
            this.End_X.Name = "End_X";
            this.End_X.ReadOnly = true;
            this.End_X.Size = new System.Drawing.Size(371, 20);
            this.End_X.TabIndex = 8;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.End_X;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(462, 24);
            this.layoutControlItem5.Text = "End_X_Point";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(75, 13);
            // 
            // End_Y
            // 
            this.End_Y.Location = new System.Drawing.Point(561, 60);
            this.End_Y.Name = "End_Y";
            this.End_Y.ReadOnly = true;
            this.End_Y.Size = new System.Drawing.Size(372, 20);
            this.End_Y.TabIndex = 9;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.End_Y;
            this.layoutControlItem6.Location = new System.Drawing.Point(462, 48);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(463, 24);
            this.layoutControlItem6.Text = "End_Y_Point";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(75, 13);
            // 
            // Result_FindLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "Result_FindLine";
            this.Size = new System.Drawing.Size(945, 263);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private System.Windows.Forms.TextBox End_Y;
        private System.Windows.Forms.TextBox End_X;
        private System.Windows.Forms.TextBox Center_Y;
        private System.Windows.Forms.TextBox Center_X;
        private System.Windows.Forms.TextBox Start_Y;
        private System.Windows.Forms.TextBox text_StartX;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
    }
}
