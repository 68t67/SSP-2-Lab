
namespace ExampleCS
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.таблицыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перваяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.втораяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.третьяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.выбратьТаблицуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.перваяToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.втораяToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.третьяToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.таблицыToolStripMenuItem,
            this.перваяToolStripMenuItem,
            this.втораяToolStripMenuItem,
            this.третьяToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 100);
            // 
            // таблицыToolStripMenuItem
            // 
            this.таблицыToolStripMenuItem.Name = "таблицыToolStripMenuItem";
            this.таблицыToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.таблицыToolStripMenuItem.Text = "Таблицы";
            // 
            // перваяToolStripMenuItem
            // 
            this.перваяToolStripMenuItem.Name = "перваяToolStripMenuItem";
            this.перваяToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.перваяToolStripMenuItem.Text = "первая ";
            // 
            // втораяToolStripMenuItem
            // 
            this.втораяToolStripMenuItem.Name = "втораяToolStripMenuItem";
            this.втораяToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.втораяToolStripMenuItem.Text = "вторая ";
            // 
            // третьяToolStripMenuItem
            // 
            this.третьяToolStripMenuItem.Name = "третьяToolStripMenuItem";
            this.третьяToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.третьяToolStripMenuItem.Text = "третья";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьТаблицуToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1097, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выбратьТаблицуToolStripMenuItem
            // 
            this.выбратьТаблицуToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перваяToolStripMenuItem1,
            this.втораяToolStripMenuItem1,
            this.третьяToolStripMenuItem1});
            this.выбратьТаблицуToolStripMenuItem.Name = "выбратьТаблицуToolStripMenuItem";
            this.выбратьТаблицуToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.выбратьТаблицуToolStripMenuItem.Text = "Выбрать таблицу";
            this.выбратьТаблицуToolStripMenuItem.Click += new System.EventHandler(this.выбратьТаблицуToolStripMenuItem_Click);
            // 
            // перваяToolStripMenuItem1
            // 
            this.перваяToolStripMenuItem1.Name = "перваяToolStripMenuItem1";
            this.перваяToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.перваяToolStripMenuItem1.Text = "Service";
            this.перваяToolStripMenuItem1.Click += new System.EventHandler(this.перваяToolStripMenuItem1_Click);
            // 
            // втораяToolStripMenuItem1
            // 
            this.втораяToolStripMenuItem1.Name = "втораяToolStripMenuItem1";
            this.втораяToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.втораяToolStripMenuItem1.Text = "Products";
            this.втораяToolStripMenuItem1.Click += new System.EventHandler(this.втораяToolStripMenuItem1_Click);
            // 
            // третьяToolStripMenuItem1
            // 
            this.третьяToolStripMenuItem1.Name = "третьяToolStripMenuItem1";
            this.третьяToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.третьяToolStripMenuItem1.Text = "ServiseProducts";
            this.третьяToolStripMenuItem1.Click += new System.EventHandler(this.третьяToolStripMenuItem1_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.выходToolStripMenuItem.Text = "выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_delete);
            this.groupBox1.Controls.Add(this.button_update);
            this.groupBox1.Controls.Add(this.button_add);
            this.groupBox1.Location = new System.Drawing.Point(747, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 336);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Действия";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(29, 172);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(258, 40);
            this.button_delete.TabIndex = 2;
            this.button_delete.Text = "Удалить";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_update
            // 
            this.button_update.Location = new System.Drawing.Point(29, 104);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(258, 40);
            this.button_update.TabIndex = 1;
            this.button_update.Text = "Обновить";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(29, 44);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(258, 33);
            this.button_add.TabIndex = 0;
            this.button_add.Text = "Добавить ";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(671, 336);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 4;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Enabled = false;
            this.maskedTextBox1.Location = new System.Drawing.Point(275, 6);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(138, 22);
            this.maskedTextBox1.TabIndex = 3;
            this.maskedTextBox1.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox1_MaskInputRejected);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 422);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обозреватель таблиц";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem таблицыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перваяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem втораяToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem третьяToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выбратьТаблицуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem перваяToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem втораяToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem третьяToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_update;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
    }
}

