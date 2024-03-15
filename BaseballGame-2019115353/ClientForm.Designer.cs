namespace BaseballGame_2019115353
{
    partial class ClientForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ipaddress = new System.Windows.Forms.TextBox();
            this.portnumber = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.num1 = new System.Windows.Forms.TextBox();
            this.num2 = new System.Windows.Forms.TextBox();
            this.num3 = new System.Windows.Forms.TextBox();
            this.num4 = new System.Windows.Forms.TextBox();
            this.recordView = new System.Windows.Forms.ListView();
            this.count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sendData = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // ipaddress
            // 
            this.ipaddress.Location = new System.Drawing.Point(478, 388);
            this.ipaddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ipaddress.Name = "ipaddress";
            this.ipaddress.ReadOnly = true;
            this.ipaddress.Size = new System.Drawing.Size(141, 21);
            this.ipaddress.TabIndex = 9;
            this.ipaddress.Visible = false;
            // 
            // portnumber
            // 
            this.portnumber.Location = new System.Drawing.Point(627, 388);
            this.portnumber.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.portnumber.Name = "portnumber";
            this.portnumber.ReadOnly = true;
            this.portnumber.Size = new System.Drawing.Size(141, 21);
            this.portnumber.TabIndex = 10;
            this.portnumber.Visible = false;
            // 
            // start
            // 
            this.start.BackColor = System.Drawing.SystemColors.Control;
            this.start.FlatAppearance.BorderSize = 0;
            this.start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.start.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.start.Location = new System.Drawing.Point(755, 12);
            this.start.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(100, 27);
            this.start.TabIndex = 0;
            this.start.Text = "게임 시작";
            this.start.UseVisualStyleBackColor = false;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // num1
            // 
            this.num1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.num1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.num1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num1.Location = new System.Drawing.Point(553, 180);
            this.num1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.num1.Name = "num1";
            this.num1.ReadOnly = true;
            this.num1.Size = new System.Drawing.Size(29, 15);
            this.num1.TabIndex = 3;
            this.num1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num1_KeyDown);
            this.num1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num1_KeyPress);
            // 
            // num2
            // 
            this.num2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.num2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.num2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num2.Location = new System.Drawing.Point(590, 180);
            this.num2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.num2.Name = "num2";
            this.num2.ReadOnly = true;
            this.num2.Size = new System.Drawing.Size(29, 15);
            this.num2.TabIndex = 4;
            this.num2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num2_KeyDown);
            this.num2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num2_KeyPress);
            // 
            // num3
            // 
            this.num3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.num3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.num3.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num3.Location = new System.Drawing.Point(627, 180);
            this.num3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.num3.Name = "num3";
            this.num3.ReadOnly = true;
            this.num3.Size = new System.Drawing.Size(29, 15);
            this.num3.TabIndex = 5;
            this.num3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num3_KeyDown);
            this.num3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num3_KeyPress);
            // 
            // num4
            // 
            this.num4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.num4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.num4.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.num4.Location = new System.Drawing.Point(665, 180);
            this.num4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.num4.Name = "num4";
            this.num4.ReadOnly = true;
            this.num4.Size = new System.Drawing.Size(29, 15);
            this.num4.TabIndex = 6;
            this.num4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.num4_KeyDown);
            this.num4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.num4_KeyPress);
            // 
            // recordView
            // 
            this.recordView.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.recordView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.recordView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.count,
            this.number,
            this.result});
            this.recordView.Font = new System.Drawing.Font("한컴 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.recordView.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.recordView.FullRowSelect = true;
            this.recordView.GridLines = true;
            this.recordView.HideSelection = false;
            this.recordView.Location = new System.Drawing.Point(13, 12);
            this.recordView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.recordView.MultiSelect = false;
            this.recordView.Name = "recordView";
            this.recordView.Size = new System.Drawing.Size(378, 397);
            this.recordView.TabIndex = 1;
            this.recordView.UseCompatibleStateImageBehavior = false;
            this.recordView.View = System.Windows.Forms.View.Details;
            // 
            // count
            // 
            this.count.Text = "횟수";
            this.count.Width = 98;
            // 
            // number
            // 
            this.number.Text = "번호";
            this.number.Width = 129;
            // 
            // result
            // 
            this.result.Text = "결과";
            this.result.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("한컴 고딕", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(542, 126);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "[게임 시작] 버튼을 눌러 주세요.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(478, 361);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(289, 21);
            this.textBox1.TabIndex = 8;
            this.textBox1.Visible = false;
            // 
            // sendData
            // 
            this.sendData.BackColor = System.Drawing.SystemColors.Control;
            this.sendData.FlatAppearance.BorderSize = 0;
            this.sendData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendData.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sendData.Location = new System.Drawing.Point(554, 224);
            this.sendData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sendData.Name = "sendData";
            this.sendData.Size = new System.Drawing.Size(140, 24);
            this.sendData.TabIndex = 7;
            this.sendData.Text = "OK(Enter)";
            this.sendData.UseVisualStyleBackColor = false;
            this.sendData.Click += new System.EventHandler(this.sendData_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(554, 201);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 10);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Location = new System.Drawing.Point(590, 201);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 10);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox3.Location = new System.Drawing.Point(627, 201);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 10);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox4.Location = new System.Drawing.Point(663, 201);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 10);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(868, 421);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sendData);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recordView);
            this.Controls.Add(this.num4);
            this.Controls.Add(this.num3);
            this.Controls.Add(this.num2);
            this.Controls.Add(this.num1);
            this.Controls.Add(this.start);
            this.Controls.Add(this.portnumber);
            this.Controls.Add(this.ipaddress);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ipaddress;
        private System.Windows.Forms.TextBox portnumber;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox num1;
        private System.Windows.Forms.TextBox num2;
        private System.Windows.Forms.TextBox num3;
        private System.Windows.Forms.TextBox num4;
        private System.Windows.Forms.ListView recordView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button sendData;
        private System.Windows.Forms.ColumnHeader count;
        private System.Windows.Forms.ColumnHeader number;
        private System.Windows.Forms.ColumnHeader result;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}

