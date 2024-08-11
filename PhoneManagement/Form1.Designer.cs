namespace PhoneManagement
{
    partial class SmartPhoneManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartPhoneManagement));
            this.dgwPhoneList = new System.Windows.Forms.DataGridView();
            this.colSmartPhoneID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSmartPhoneName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSmartPhoneType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnnouncedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPlatform = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCamera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBattery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picPhoneImage = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdateSource = new System.Windows.Forms.Button();
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.btnLoadSQL = new System.Windows.Forms.Button();
            this.btnCloseApp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwPhoneList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoneImage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwPhoneList
            // 
            this.dgwPhoneList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwPhoneList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSmartPhoneID,
            this.colSmartPhoneName,
            this.colSmartPhoneType,
            this.colAnnouncedDate,
            this.colPlatform,
            this.colCamera,
            this.colRAM,
            this.colBattery,
            this.colPrice});
            this.dgwPhoneList.Location = new System.Drawing.Point(18, 52);
            this.dgwPhoneList.Name = "dgwPhoneList";
            this.dgwPhoneList.RowHeadersWidth = 51;
            this.dgwPhoneList.RowTemplate.Height = 24;
            this.dgwPhoneList.Size = new System.Drawing.Size(551, 328);
            this.dgwPhoneList.TabIndex = 0;
            this.dgwPhoneList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwPhoneList_CellContentClick);
            // 
            // colSmartPhoneID
            // 
            this.colSmartPhoneID.DataPropertyName = "SmartPhoneID";
            this.colSmartPhoneID.HeaderText = "SmartPhoneID";
            this.colSmartPhoneID.MinimumWidth = 6;
            this.colSmartPhoneID.Name = "colSmartPhoneID";
            this.colSmartPhoneID.Width = 125;
            // 
            // colSmartPhoneName
            // 
            this.colSmartPhoneName.DataPropertyName = "SmartPhoneName";
            this.colSmartPhoneName.HeaderText = "SmartPhoneName";
            this.colSmartPhoneName.MinimumWidth = 6;
            this.colSmartPhoneName.Name = "colSmartPhoneName";
            this.colSmartPhoneName.Width = 125;
            // 
            // colSmartPhoneType
            // 
            this.colSmartPhoneType.DataPropertyName = "SmartPhoneType";
            this.colSmartPhoneType.HeaderText = "SmartPhoneType";
            this.colSmartPhoneType.MinimumWidth = 6;
            this.colSmartPhoneType.Name = "colSmartPhoneType";
            this.colSmartPhoneType.Width = 125;
            // 
            // colAnnouncedDate
            // 
            this.colAnnouncedDate.DataPropertyName = "AnnouncedDate";
            this.colAnnouncedDate.HeaderText = "AnnouncedDate";
            this.colAnnouncedDate.MinimumWidth = 6;
            this.colAnnouncedDate.Name = "colAnnouncedDate";
            this.colAnnouncedDate.Width = 125;
            // 
            // colPlatform
            // 
            this.colPlatform.DataPropertyName = "Platform";
            this.colPlatform.HeaderText = "Platform";
            this.colPlatform.MinimumWidth = 6;
            this.colPlatform.Name = "colPlatform";
            this.colPlatform.Width = 125;
            // 
            // colCamera
            // 
            this.colCamera.DataPropertyName = "Camera";
            this.colCamera.HeaderText = "Camera";
            this.colCamera.MinimumWidth = 6;
            this.colCamera.Name = "colCamera";
            this.colCamera.Width = 125;
            // 
            // colRAM
            // 
            this.colRAM.DataPropertyName = "RAM";
            this.colRAM.HeaderText = "RAM";
            this.colRAM.MinimumWidth = 6;
            this.colRAM.Name = "colRAM";
            this.colRAM.Width = 125;
            // 
            // colBattery
            // 
            this.colBattery.DataPropertyName = "Battery";
            this.colBattery.HeaderText = "Battery";
            this.colBattery.MinimumWidth = 6;
            this.colBattery.Name = "colBattery";
            this.colBattery.Width = 125;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Price";
            this.colPrice.HeaderText = "Price";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 125;
            // 
            // picPhoneImage
            // 
            this.picPhoneImage.Image = ((System.Drawing.Image)(resources.GetObject("picPhoneImage.Image")));
            this.picPhoneImage.Location = new System.Drawing.Point(593, 52);
            this.picPhoneImage.Name = "picPhoneImage";
            this.picPhoneImage.Size = new System.Drawing.Size(191, 179);
            this.picPhoneImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPhoneImage.TabIndex = 1;
            this.picPhoneImage.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(18, 394);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 31);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(137, 394);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 31);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(253, 394);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 31);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdateSource
            // 
            this.btnUpdateSource.Location = new System.Drawing.Point(380, 394);
            this.btnUpdateSource.Name = "btnUpdateSource";
            this.btnUpdateSource.Size = new System.Drawing.Size(189, 31);
            this.btnUpdateSource.TabIndex = 5;
            this.btnUpdateSource.Text = "Update To DataSource";
            this.btnUpdateSource.UseVisualStyleBackColor = true;
            this.btnUpdateSource.Click += new System.EventHandler(this.btnUpdateSource_Click);
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Location = new System.Drawing.Point(18, 10);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(221, 31);
            this.btnLoadExcel.TabIndex = 6;
            this.btnLoadExcel.Text = "Load Data From Excel";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // btnLoadSQL
            // 
            this.btnLoadSQL.Location = new System.Drawing.Point(348, 10);
            this.btnLoadSQL.Name = "btnLoadSQL";
            this.btnLoadSQL.Size = new System.Drawing.Size(221, 31);
            this.btnLoadSQL.TabIndex = 7;
            this.btnLoadSQL.Text = "Load Data From SQL";
            this.btnLoadSQL.UseVisualStyleBackColor = true;
            this.btnLoadSQL.Click += new System.EventHandler(this.btnLoadSQL_Click);
            // 
            // btnCloseApp
            // 
            this.btnCloseApp.Location = new System.Drawing.Point(595, 275);
            this.btnCloseApp.Name = "btnCloseApp";
            this.btnCloseApp.Size = new System.Drawing.Size(188, 40);
            this.btnCloseApp.TabIndex = 8;
            this.btnCloseApp.Text = "Close Application";
            this.btnCloseApp.UseVisualStyleBackColor = true;
            this.btnCloseApp.Click += new System.EventHandler(this.btnCloseApp_Click);
            // 
            // SmartPhoneManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCloseApp);
            this.Controls.Add(this.btnLoadSQL);
            this.Controls.Add(this.btnLoadExcel);
            this.Controls.Add(this.btnUpdateSource);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.picPhoneImage);
            this.Controls.Add(this.dgwPhoneList);
            this.Name = "SmartPhoneManagement";
            this.Text = "Phone Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgwPhoneList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhoneImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwPhoneList;
        private System.Windows.Forms.PictureBox picPhoneImage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdateSource;
        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.Button btnLoadSQL;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSmartPhoneID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSmartPhoneName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSmartPhoneType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnnouncedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPlatform;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCamera;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBattery;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.Button btnCloseApp;
    }
}

