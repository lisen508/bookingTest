namespace BookingPlatform_InitialHospital
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_initialHospital = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_hospitalId = new System.Windows.Forms.TextBox();
            this.cb_select = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_initialHospital
            // 
            this.btn_initialHospital.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_initialHospital.Location = new System.Drawing.Point(137, 150);
            this.btn_initialHospital.Name = "btn_initialHospital";
            this.btn_initialHospital.Size = new System.Drawing.Size(222, 49);
            this.btn_initialHospital.TabIndex = 0;
            this.btn_initialHospital.Text = "初始化";
            this.btn_initialHospital.UseVisualStyleBackColor = true;
            this.btn_initialHospital.Click += new System.EventHandler(this.btn_initialHospital_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入医院ID:";
            // 
            // txb_hospitalId
            // 
            this.txb_hospitalId.Location = new System.Drawing.Point(137, 66);
            this.txb_hospitalId.Name = "txb_hospitalId";
            this.txb_hospitalId.Size = new System.Drawing.Size(222, 21);
            this.txb_hospitalId.TabIndex = 2;
            // 
            // cb_select
            // 
            this.cb_select.AutoSize = true;
            this.cb_select.Location = new System.Drawing.Point(137, 109);
            this.cb_select.Name = "cb_select";
            this.cb_select.Size = new System.Drawing.Size(156, 16);
            this.cb_select.TabIndex = 3;
            this.cb_select.Text = "迭代11及以上版本请选择";
            this.cb_select.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 281);
            this.Controls.Add(this.cb_select);
            this.Controls.Add(this.txb_hospitalId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_initialHospital);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "院区初始化";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_initialHospital;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txb_hospitalId;
        private System.Windows.Forms.CheckBox cb_select;
    }
}

