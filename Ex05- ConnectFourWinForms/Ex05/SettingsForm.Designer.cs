namespace Ex05
{
    partial class SettingsForm
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
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.txtPlayer1 = new System.Windows.Forms.TextBox();
            this.cbPlayer2 = new System.Windows.Forms.CheckBox();
            this.txtPlayer2 = new System.Windows.Forms.TextBox();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.rowsLabel = new System.Windows.Forms.Label();
            this.colLabel = new System.Windows.Forms.Label();
            this.numCols = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(12, 9);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(44, 13);
            this.labelPlayers.TabIndex = 0;
            this.labelPlayers.Text = "Players:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(25, 40);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(48, 13);
            this.labelPlayer1.TabIndex = 1;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // txtPlayer1
            // 
            this.txtPlayer1.Location = new System.Drawing.Point(91, 37);
            this.txtPlayer1.Name = "txtPlayer1";
            this.txtPlayer1.Size = new System.Drawing.Size(98, 20);
            this.txtPlayer1.TabIndex = 2;
            // 
            // cbPlayer2
            // 
            this.cbPlayer2.AutoSize = true;
            this.cbPlayer2.Location = new System.Drawing.Point(12, 63);
            this.cbPlayer2.Name = "cbPlayer2";
            this.cbPlayer2.Size = new System.Drawing.Size(67, 17);
            this.cbPlayer2.TabIndex = 3;
            this.cbPlayer2.Text = "Player 2:";
            this.cbPlayer2.UseVisualStyleBackColor = true;
            // 
            // txtPlayer2
            // 
            this.txtPlayer2.Enabled = false;
            this.txtPlayer2.Location = new System.Drawing.Point(91, 60);
            this.txtPlayer2.Name = "txtPlayer2";
            this.txtPlayer2.Size = new System.Drawing.Size(98, 20);
            this.txtPlayer2.TabIndex = 4;
            this.txtPlayer2.Text = "[Computer]";
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(12, 120);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(61, 13);
            this.sizeLabel.TabIndex = 5;
            this.sizeLabel.Text = "Board Size:";
            // 
            // numRows
            // 
            this.numRows.Location = new System.Drawing.Point(49, 150);
            this.numRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(30, 20);
            this.numRows.TabIndex = 6;
            this.numRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // rowsLabel
            // 
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Location = new System.Drawing.Point(12, 152);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(37, 13);
            this.rowsLabel.TabIndex = 7;
            this.rowsLabel.Text = "Rows:";
            // 
            // colLabel
            // 
            this.colLabel.AutoSize = true;
            this.colLabel.Location = new System.Drawing.Point(88, 152);
            this.colLabel.Name = "colLabel";
            this.colLabel.Size = new System.Drawing.Size(50, 13);
            this.colLabel.TabIndex = 8;
            this.colLabel.Text = "Columns:";
            // 
            // numCols
            // 
            this.numCols.Location = new System.Drawing.Point(144, 150);
            this.numCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numCols.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numCols.Name = "numCols";
            this.numCols.Size = new System.Drawing.Size(30, 20);
            this.numCols.TabIndex = 9;
            this.numCols.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(9, 185);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(180, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start!";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 220);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.numCols);
            this.Controls.Add(this.colLabel);
            this.Controls.Add(this.rowsLabel);
            this.Controls.Add(this.numRows);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.txtPlayer2);
            this.Controls.Add(this.cbPlayer2);
            this.Controls.Add(this.txtPlayer1);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.TextBox txtPlayer1;
        private System.Windows.Forms.CheckBox cbPlayer2;
        private System.Windows.Forms.TextBox txtPlayer2;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.Label colLabel;
        private System.Windows.Forms.NumericUpDown numCols;
        private System.Windows.Forms.Button btnStart;
    }
}