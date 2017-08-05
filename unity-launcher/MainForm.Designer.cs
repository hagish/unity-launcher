namespace unity_launcher
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelProjects = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelUnitys = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelProjects, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.flowLayoutPanelUnitys, 0, 0);
            this.tableLayoutPanelMain.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanelMain.MinimumSize = new System.Drawing.Size(100, 100);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(100, 100);
            this.tableLayoutPanelMain.TabIndex = 0;
            this.tableLayoutPanelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanelProjects
            // 
            this.tableLayoutPanelProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelProjects.AutoSize = true;
            this.tableLayoutPanelProjects.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelProjects.ColumnCount = 2;
            this.tableLayoutPanelProjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelProjects.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelProjects.Location = new System.Drawing.Point(3, 9);
            this.tableLayoutPanelProjects.Name = "tableLayoutPanelProjects";
            this.tableLayoutPanelProjects.RowCount = 1;
            this.tableLayoutPanelProjects.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelProjects.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanelProjects.Size = new System.Drawing.Size(94, 88);
            this.tableLayoutPanelProjects.TabIndex = 0;
            // 
            // flowLayoutPanelUnitys
            // 
            this.flowLayoutPanelUnitys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelUnitys.AutoSize = true;
            this.flowLayoutPanelUnitys.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanelUnitys.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanelUnitys.Name = "flowLayoutPanelUnitys";
            this.flowLayoutPanelUnitys.Size = new System.Drawing.Size(94, 1);
            this.flowLayoutPanelUnitys.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(120, 123);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(120, 120);
            this.Name = "MainForm";
            this.Text = "UnityLauncher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProjects;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelUnitys;
    }
}

