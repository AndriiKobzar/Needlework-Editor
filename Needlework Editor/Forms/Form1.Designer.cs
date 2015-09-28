namespace Needlework_Editor
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зображенняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsFileTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canvasColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threadColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.налаштуванняПолотнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.розміриToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageOnBcgrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeLayerCMSI = new System.Windows.Forms.ToolStripMenuItem();
            this.inputFromFileTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBox = new System.Windows.Forms.ListBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.canvasCD = new System.Windows.Forms.ColorDialog();
            this.curvePointsNumber = new System.Windows.Forms.NumericUpDown();
            this.threadCD = new System.Windows.Forms.ColorDialog();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFile = new System.Windows.Forms.SaveFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.selectFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.NeedleBtn = new System.Windows.Forms.Button();
            this.threadWidthPicker = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.toolboxPanel = new System.Windows.Forms.Panel();
            this.needleRedactor = new Needlework_Editor.NeedleControl();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.curvePointsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadWidthPicker)).BeginInit();
            this.toolboxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(972, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10F);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.зображенняToolStripMenuItem,
            this.saveAsFileTSMI});
            this.saveToolStripMenuItem.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(205, 28);
            this.saveToolStripMenuItem.Text = "Зберегти як..";
            // 
            // зображенняToolStripMenuItem
            // 
            this.зображенняToolStripMenuItem.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.зображенняToolStripMenuItem.Name = "зображенняToolStripMenuItem";
            this.зображенняToolStripMenuItem.Size = new System.Drawing.Size(199, 28);
            this.зображенняToolStripMenuItem.Text = "Зображення";
            this.зображенняToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsFileTSMI
            // 
            this.saveAsFileTSMI.Name = "saveAsFileTSMI";
            this.saveAsFileTSMI.Size = new System.Drawing.Size(199, 28);
            this.saveAsFileTSMI.Text = "Файл";
            this.saveAsFileTSMI.Click += new System.EventHandler(this.saveAsFileTSMI_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.canvasColorToolStripMenuItem,
            this.threadColorToolStripMenuItem,
            this.налаштуванняПолотнаToolStripMenuItem});
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10F);
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.optionsToolStripMenuItem.Text = "Налаштування";
            // 
            // canvasColorToolStripMenuItem
            // 
            this.canvasColorToolStripMenuItem.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.canvasColorToolStripMenuItem.Name = "canvasColorToolStripMenuItem";
            this.canvasColorToolStripMenuItem.Size = new System.Drawing.Size(304, 28);
            this.canvasColorToolStripMenuItem.Text = "Колір полотна..";
            this.canvasColorToolStripMenuItem.Click += new System.EventHandler(this.canvasColorToolStripMenuItem_Click);
            // 
            // threadColorToolStripMenuItem
            // 
            this.threadColorToolStripMenuItem.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.threadColorToolStripMenuItem.Name = "threadColorToolStripMenuItem";
            this.threadColorToolStripMenuItem.Size = new System.Drawing.Size(304, 28);
            this.threadColorToolStripMenuItem.Text = "Колір нитки..";
            this.threadColorToolStripMenuItem.Click += new System.EventHandler(this.ThreadColorToolStripMenuItem_Click);
            // 
            // налаштуванняПолотнаToolStripMenuItem
            // 
            this.налаштуванняПолотнаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaceToolStripMenuItem,
            this.розміриToolStripMenuItem,
            this.imageOnBcgrToolStripMenuItem,
            this.backTSMI});
            this.налаштуванняПолотнаToolStripMenuItem.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.налаштуванняПолотнаToolStripMenuItem.Name = "налаштуванняПолотнаToolStripMenuItem";
            this.налаштуванняПолотнаToolStripMenuItem.Size = new System.Drawing.Size(304, 28);
            this.налаштуванняПолотнаToolStripMenuItem.Text = "Налаштування полотна";
            // 
            // LaceToolStripMenuItem
            // 
            this.LaceToolStripMenuItem.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LaceToolStripMenuItem.Name = "LaceToolStripMenuItem";
            this.LaceToolStripMenuItem.Size = new System.Drawing.Size(315, 28);
            this.LaceToolStripMenuItem.Text = "Редактор полотна";
            this.LaceToolStripMenuItem.Click += new System.EventHandler(this.LaceToolStripMenuItem_Click);
            // 
            // розміриToolStripMenuItem
            // 
            this.розміриToolStripMenuItem.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.розміриToolStripMenuItem.Name = "розміриToolStripMenuItem";
            this.розміриToolStripMenuItem.Size = new System.Drawing.Size(315, 28);
            this.розміриToolStripMenuItem.Text = "Розміри..";
            this.розміриToolStripMenuItem.Click += new System.EventHandler(this.розміриToolStripMenuItem_Click);
            // 
            // imageOnBcgrToolStripMenuItem
            // 
            this.imageOnBcgrToolStripMenuItem.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.imageOnBcgrToolStripMenuItem.Name = "imageOnBcgrToolStripMenuItem";
            this.imageOnBcgrToolStripMenuItem.Size = new System.Drawing.Size(315, 28);
            this.imageOnBcgrToolStripMenuItem.Text = "Встановити зображення";
            this.imageOnBcgrToolStripMenuItem.Click += new System.EventHandler(this.imageOnBcgrToolStripMenuItem_Click);
            // 
            // backTSMI
            // 
            this.backTSMI.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backTSMI.Name = "backTSMI";
            this.backTSMI.Size = new System.Drawing.Size(315, 28);
            this.backTSMI.Text = "Встановити полотно";
            this.backTSMI.Click += new System.EventHandler(this.backTSMI_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10F);
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.helpToolStripMenuItem.Text = "Довідка";
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.drawingPanel.ContextMenuStrip = this.contextMenuStrip1;
            this.drawingPanel.Location = new System.Drawing.Point(12, 48);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(640, 302);
            this.drawingPanel.TabIndex = 2;
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            this.drawingPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseClick);
            this.drawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseMove);
            this.drawingPanel.Resize += new System.EventHandler(this.drawingPanel_Resize);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeLayerCMSI,
            this.inputFromFileTSMI});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(266, 48);
            // 
            // changeLayerCMSI
            // 
            this.changeLayerCMSI.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeLayerCMSI.Name = "changeLayerCMSI";
            this.changeLayerCMSI.Size = new System.Drawing.Size(265, 22);
            this.changeLayerCMSI.Text = "Змінити нитку";
            this.changeLayerCMSI.Click += new System.EventHandler(this.changeLayerCMSI_Click);
            // 
            // inputFromFileTSMI
            // 
            this.inputFromFileTSMI.Font = new System.Drawing.Font("Arial", 10F);
            this.inputFromFileTSMI.Name = "inputFromFileTSMI";
            this.inputFromFileTSMI.Size = new System.Drawing.Size(265, 22);
            this.inputFromFileTSMI.Text = "Вставити елементи з файлу ";
            this.inputFromFileTSMI.Click += new System.EventHandler(this.inputFromFileTSMI_Click);
            // 
            // toolBox
            // 
            this.toolBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.toolBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolBox.FormattingEnabled = true;
            this.toolBox.ItemHeight = 16;
            this.toolBox.Items.AddRange(new object[] {
            "Відрізок",
            "Дуга",
            "Редагувати голку"});
            this.toolBox.Location = new System.Drawing.Point(17, 3);
            this.toolBox.Name = "toolBox";
            this.toolBox.Size = new System.Drawing.Size(124, 52);
            this.toolBox.TabIndex = 3;
            this.toolBox.SelectedIndexChanged += new System.EventHandler(this.toolBox_SelectedIndexChanged);
            this.toolBox.Enter += new System.EventHandler(this.toolBox_Enter);
            this.toolBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolBox_KeyDown);
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.clearBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearBtn.Location = new System.Drawing.Point(13, 102);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(246, 35);
            this.clearBtn.TabIndex = 4;
            this.clearBtn.Text = "Очистити полотно";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(13, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Прибрати останній";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RemoveBtn_Click);
            // 
            // canvasCD
            // 
            this.canvasCD.AnyColor = true;
            // 
            // curvePointsNumber
            // 
            this.curvePointsNumber.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.curvePointsNumber.Location = new System.Drawing.Point(147, 19);
            this.curvePointsNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.curvePointsNumber.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.curvePointsNumber.Name = "curvePointsNumber";
            this.curvePointsNumber.Size = new System.Drawing.Size(120, 20);
            this.curvePointsNumber.TabIndex = 7;
            this.curvePointsNumber.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // openFile
            // 
            this.openFile.FileName = "openFile";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(13, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(246, 42);
            this.button2.TabIndex = 8;
            this.button2.Text = "Наступний крок";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NeedleBtn
            // 
            this.NeedleBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NeedleBtn.Font = new System.Drawing.Font("Arial", 15.75F);
            this.NeedleBtn.Location = new System.Drawing.Point(13, 232);
            this.NeedleBtn.Name = "NeedleBtn";
            this.NeedleBtn.Size = new System.Drawing.Size(246, 42);
            this.NeedleBtn.TabIndex = 9;
            this.NeedleBtn.Text = "Намалювати голку";
            this.NeedleBtn.UseVisualStyleBackColor = true;
            this.NeedleBtn.Click += new System.EventHandler(this.NeedleBtn_Click);
            // 
            // threadWidthPicker
            // 
            this.threadWidthPicker.Location = new System.Drawing.Point(147, 71);
            this.threadWidthPicker.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.threadWidthPicker.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.threadWidthPicker.Name = "threadWidthPicker";
            this.threadWidthPicker.Size = new System.Drawing.Size(120, 20);
            this.threadWidthPicker.TabIndex = 11;
            this.threadWidthPicker.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Товщина нитки:";
            // 
            // toolboxPanel
            // 
            this.toolboxPanel.Controls.Add(this.toolBox);
            this.toolboxPanel.Controls.Add(this.clearBtn);
            this.toolboxPanel.Controls.Add(this.label1);
            this.toolboxPanel.Controls.Add(this.button1);
            this.toolboxPanel.Controls.Add(this.threadWidthPicker);
            this.toolboxPanel.Controls.Add(this.curvePointsNumber);
            this.toolboxPanel.Controls.Add(this.needleRedactor);
            this.toolboxPanel.Controls.Add(this.button2);
            this.toolboxPanel.Controls.Add(this.NeedleBtn);
            this.toolboxPanel.Location = new System.Drawing.Point(658, 48);
            this.toolboxPanel.Name = "toolboxPanel";
            this.toolboxPanel.Size = new System.Drawing.Size(314, 465);
            this.toolboxPanel.TabIndex = 13;
            this.toolboxPanel.Click += new System.EventHandler(this.toolboxPanel_Click);
            // 
            // needleRedactor
            // 
            this.needleRedactor.BackColor = System.Drawing.Color.White;
            this.needleRedactor.Location = new System.Drawing.Point(13, 280);
            this.needleRedactor.Name = "needleRedactor";
            this.needleRedactor.Size = new System.Drawing.Size(150, 150);
            this.needleRedactor.TabIndex = 10;
            this.needleRedactor.Visible = false;
            this.needleRedactor.AngleChanged += new System.Action(this.needleRedactor_AngleChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 513);
            this.Controls.Add(this.toolboxPanel);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Needlework Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.curvePointsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadWidthPicker)).EndInit();
            this.toolboxPanel.ResumeLayout(false);
            this.toolboxPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.ListBox toolBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changeLayerCMSI;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ColorDialog canvasCD;
        private System.Windows.Forms.ToolStripMenuItem canvasColorToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown curvePointsNumber;
        private System.Windows.Forms.ToolStripMenuItem зображенняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threadColorToolStripMenuItem;
        private System.Windows.Forms.ColorDialog threadCD;
        private System.Windows.Forms.ToolStripMenuItem налаштуванняПолотнаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem розміриToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.FolderBrowserDialog selectFolder;
        private System.Windows.Forms.ToolStripMenuItem imageOnBcgrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backTSMI;
        private System.Windows.Forms.Button NeedleBtn;
        private System.Windows.Forms.ToolStripMenuItem saveAsFileTSMI;
        private System.Windows.Forms.ToolStripMenuItem inputFromFileTSMI;
        private NeedleControl needleRedactor;
        private System.Windows.Forms.NumericUpDown threadWidthPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel toolboxPanel;
    }
}

