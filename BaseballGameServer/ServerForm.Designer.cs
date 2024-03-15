namespace BaseballGameServer
{
    partial class ServerForm
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
            this.clientView = new System.Windows.Forms.ListView();
            this.clients = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.question = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.ipaddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portnumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.serveronoff = new System.Windows.Forms.Button();
            this.rankView = new System.Windows.Forms.ListView();
            this.point = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.client = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clientView
            // 
            this.clientView.BackColor = System.Drawing.SystemColors.Control;
            this.clientView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clientView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clients,
            this.question});
            this.clientView.Font = new System.Drawing.Font("한컴 고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.clientView.FullRowSelect = true;
            this.clientView.GridLines = true;
            this.clientView.HideSelection = false;
            this.clientView.Location = new System.Drawing.Point(30, 165);
            this.clientView.MultiSelect = false;
            this.clientView.Name = "clientView";
            this.clientView.Size = new System.Drawing.Size(186, 222);
            this.clientView.TabIndex = 0;
            this.clientView.UseCompatibleStateImageBehavior = false;
            this.clientView.View = System.Windows.Forms.View.Details;
            // 
            // clients
            // 
            this.clients.Text = "클라이언트 번호";
            this.clients.Width = 128;
            // 
            // question
            // 
            this.question.Text = "문제";
            this.question.Width = 54;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("한컴 고딕", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(33, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "접속 클라이언트";
            // 
            // ipaddress
            // 
            this.ipaddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ipaddress.Location = new System.Drawing.Point(30, 55);
            this.ipaddress.Name = "ipaddress";
            this.ipaddress.ReadOnly = true;
            this.ipaddress.Size = new System.Drawing.Size(150, 14);
            this.ipaddress.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("한컴 고딕", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(34, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "서버 IP 주소";
            // 
            // portnumber
            // 
            this.portnumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.portnumber.Location = new System.Drawing.Point(197, 55);
            this.portnumber.Name = "portnumber";
            this.portnumber.ReadOnly = true;
            this.portnumber.Size = new System.Drawing.Size(150, 14);
            this.portnumber.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("한컴 고딕", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(201, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Port 번호";
            // 
            // serveronoff
            // 
            this.serveronoff.BackColor = System.Drawing.SystemColors.Control;
            this.serveronoff.FlatAppearance.BorderSize = 0;
            this.serveronoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.serveronoff.Font = new System.Drawing.Font("한컴 고딕", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.serveronoff.Location = new System.Drawing.Point(368, 18);
            this.serveronoff.Name = "serveronoff";
            this.serveronoff.Size = new System.Drawing.Size(150, 51);
            this.serveronoff.TabIndex = 4;
            this.serveronoff.Text = "서버 OFF";
            this.serveronoff.UseVisualStyleBackColor = false;
            this.serveronoff.Click += new System.EventHandler(this.serveronoff_Click);
            // 
            // rankView
            // 
            this.rankView.BackColor = System.Drawing.SystemColors.Control;
            this.rankView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rankView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.point,
            this.client,
            this.number});
            this.rankView.Font = new System.Drawing.Font("한컴 고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rankView.FullRowSelect = true;
            this.rankView.GridLines = true;
            this.rankView.HideSelection = false;
            this.rankView.Location = new System.Drawing.Point(235, 165);
            this.rankView.MultiSelect = false;
            this.rankView.Name = "rankView";
            this.rankView.Size = new System.Drawing.Size(283, 222);
            this.rankView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.rankView.TabIndex = 0;
            this.rankView.UseCompatibleStateImageBehavior = false;
            this.rankView.View = System.Windows.Forms.View.Details;
            // 
            // point
            // 
            this.point.Text = "점수";
            this.point.Width = 66;
            // 
            // client
            // 
            this.client.Text = "클라이언트 번호";
            this.client.Width = 146;
            // 
            // number
            // 
            this.number.Text = "번호";
            this.number.Width = 66;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label4.Font = new System.Drawing.Font("한컴 고딕", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(238, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "게임 순위";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(550, 405);
            this.Controls.Add(this.serveronoff);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portnumber);
            this.Controls.Add(this.ipaddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rankView);
            this.Controls.Add(this.clientView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ServerForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipaddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portnumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button serveronoff;
        private System.Windows.Forms.ListView rankView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader clients;
        private System.Windows.Forms.ColumnHeader point;
        private System.Windows.Forms.ListView clientView;
        private System.Windows.Forms.ColumnHeader question;
        private System.Windows.Forms.ColumnHeader client;
        private System.Windows.Forms.ColumnHeader number;
    }
}

