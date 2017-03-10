namespace ClassModels
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
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSaveJson = new System.Windows.Forms.Button();
            this.btnLoadJson = new System.Windows.Forms.Button();
            this.btnCreateCampus = new System.Windows.Forms.Button();
            this.btnSaveCampus = new System.Windows.Forms.Button();
            this.btnLoadCampus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(24, 25);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(106, 24);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(214, 24);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(99, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSaveJson
            // 
            this.btnSaveJson.Location = new System.Drawing.Point(106, 54);
            this.btnSaveJson.Name = "btnSaveJson";
            this.btnSaveJson.Size = new System.Drawing.Size(99, 23);
            this.btnSaveJson.TabIndex = 3;
            this.btnSaveJson.Text = "Save Json";
            this.btnSaveJson.UseVisualStyleBackColor = true;
            this.btnSaveJson.Click += new System.EventHandler(this.btnSaveJson_Click);
            // 
            // btnLoadJson
            // 
            this.btnLoadJson.Location = new System.Drawing.Point(214, 54);
            this.btnLoadJson.Name = "btnLoadJson";
            this.btnLoadJson.Size = new System.Drawing.Size(99, 23);
            this.btnLoadJson.TabIndex = 4;
            this.btnLoadJson.Text = "Load Json";
            this.btnLoadJson.UseVisualStyleBackColor = true;
            this.btnLoadJson.Click += new System.EventHandler(this.btnLoadJson_Click);
            // 
            // btnCreateCampus
            // 
            this.btnCreateCampus.Location = new System.Drawing.Point(24, 102);
            this.btnCreateCampus.Name = "btnCreateCampus";
            this.btnCreateCampus.Size = new System.Drawing.Size(128, 23);
            this.btnCreateCampus.TabIndex = 5;
            this.btnCreateCampus.Text = "Create Campus";
            this.btnCreateCampus.UseVisualStyleBackColor = true;
            this.btnCreateCampus.Click += new System.EventHandler(this.btnCreateCampus_Click);
            // 
            // btnSaveCampus
            // 
            this.btnSaveCampus.Location = new System.Drawing.Point(159, 102);
            this.btnSaveCampus.Name = "btnSaveCampus";
            this.btnSaveCampus.Size = new System.Drawing.Size(111, 23);
            this.btnSaveCampus.TabIndex = 6;
            this.btnSaveCampus.Text = "Save Campus";
            this.btnSaveCampus.UseVisualStyleBackColor = true;
            this.btnSaveCampus.Click += new System.EventHandler(this.btnSaveCampus_Click);
            // 
            // btnLoadCampus
            // 
            this.btnLoadCampus.Location = new System.Drawing.Point(277, 102);
            this.btnLoadCampus.Name = "btnLoadCampus";
            this.btnLoadCampus.Size = new System.Drawing.Size(119, 23);
            this.btnLoadCampus.TabIndex = 7;
            this.btnLoadCampus.Text = "Load Campus";
            this.btnLoadCampus.UseVisualStyleBackColor = true;
            this.btnLoadCampus.Click += new System.EventHandler(this.btnLoadCampus_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 391);
            this.Controls.Add(this.btnLoadCampus);
            this.Controls.Add(this.btnSaveCampus);
            this.Controls.Add(this.btnCreateCampus);
            this.Controls.Add(this.btnLoadJson);
            this.Controls.Add(this.btnSaveJson);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSaveJson;
        private System.Windows.Forms.Button btnLoadJson;
        private System.Windows.Forms.Button btnCreateCampus;
        private System.Windows.Forms.Button btnSaveCampus;
        private System.Windows.Forms.Button btnLoadCampus;
    }
}

