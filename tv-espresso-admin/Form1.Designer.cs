namespace tv_espresso_admin
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            selectVideoButton = new Button();
            uriTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            rootTextBox = new TextBox();
            selectRootButton = new Button();
            label3 = new Label();
            titleTextBox = new TextBox();
            translatedTitleTextBox = new TextBox();
            label4 = new Label();
            yearNumeric = new NumericUpDown();
            seasonNumeric = new NumericUpDown();
            episodeNumeric = new NumericUpDown();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            fhdCheckBox = new CheckBox();
            translatedEpisodeTitleTextBox = new TextBox();
            label8 = new Label();
            episodeTitleTextBox = new TextBox();
            label9 = new Label();
            directorTextBox = new TextBox();
            label10 = new Label();
            actorsTextBox = new TextBox();
            label11 = new Label();
            genresTextBox = new TextBox();
            label12 = new Label();
            label13 = new Label();
            uri4kTextBox = new TextBox();
            select4kUriButton = new Button();
            label14 = new Label();
            coverUriTextBox = new TextBox();
            selectCoverUriButton = new Button();
            label15 = new Label();
            themeUriTextBox = new TextBox();
            selectThemeUriButton = new Button();
            label16 = new Label();
            subtitleSrTextBox = new TextBox();
            selectSubtitleSrButton = new Button();
            createButton = new Button();
            label17 = new Label();
            subtitleEnTextBox = new TextBox();
            selectSubtitleEnButton = new Button();
            resTextArea = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)yearNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seasonNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)episodeNumeric).BeginInit();
            SuspendLayout();
            // 
            // selectVideoButton
            // 
            selectVideoButton.Enabled = false;
            selectVideoButton.Location = new Point(12, 57);
            selectVideoButton.Name = "selectVideoButton";
            selectVideoButton.Size = new Size(134, 34);
            selectVideoButton.TabIndex = 0;
            selectVideoButton.Text = "Select Video";
            selectVideoButton.UseVisualStyleBackColor = true;
            selectVideoButton.Click += selectVideoButton_Click;
            // 
            // uriTextBox
            // 
            uriTextBox.Location = new Point(212, 57);
            uriTextBox.Name = "uriTextBox";
            uriTextBox.ReadOnly = true;
            uriTextBox.Size = new Size(576, 31);
            uriTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(162, 60);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 2;
            label1.Text = "URI:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(152, 15);
            label2.Name = "label2";
            label2.Size = new Size(54, 25);
            label2.TabIndex = 3;
            label2.Text = "Root:";
            // 
            // rootTextBox
            // 
            rootTextBox.Location = new Point(212, 12);
            rootTextBox.Name = "rootTextBox";
            rootTextBox.ReadOnly = true;
            rootTextBox.Size = new Size(576, 31);
            rootTextBox.TabIndex = 4;
            // 
            // selectRootButton
            // 
            selectRootButton.Location = new Point(12, 12);
            selectRootButton.Name = "selectRootButton";
            selectRootButton.Size = new Size(134, 34);
            selectRootButton.TabIndex = 5;
            selectRootButton.Text = "Select Root";
            selectRootButton.UseVisualStyleBackColor = true;
            selectRootButton.Click += selectRootButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(158, 97);
            label3.Name = "label3";
            label3.Size = new Size(48, 25);
            label3.TabIndex = 6;
            label3.Text = "Title:";
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(212, 94);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(576, 31);
            titleTextBox.TabIndex = 7;
            // 
            // translatedTitleTextBox
            // 
            translatedTitleTextBox.Location = new Point(212, 131);
            translatedTitleTextBox.Name = "translatedTitleTextBox";
            translatedTitleTextBox.Size = new Size(576, 31);
            translatedTitleTextBox.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(74, 134);
            label4.Name = "label4";
            label4.Size = new Size(132, 25);
            label4.TabIndex = 8;
            label4.Text = "Translated Title:";
            // 
            // yearNumeric
            // 
            yearNumeric.Location = new Point(212, 168);
            yearNumeric.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            yearNumeric.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            yearNumeric.Name = "yearNumeric";
            yearNumeric.Size = new Size(86, 31);
            yearNumeric.TabIndex = 10;
            yearNumeric.Value = new decimal(new int[] { 2010, 0, 0, 0 });
            // 
            // seasonNumeric
            // 
            seasonNumeric.Location = new Point(383, 168);
            seasonNumeric.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            seasonNumeric.Name = "seasonNumeric";
            seasonNumeric.Size = new Size(69, 31);
            seasonNumeric.TabIndex = 11;
            // 
            // episodeNumeric
            // 
            episodeNumeric.Location = new Point(543, 168);
            episodeNumeric.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            episodeNumeric.Name = "episodeNumeric";
            episodeNumeric.Size = new Size(69, 31);
            episodeNumeric.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(158, 170);
            label5.Name = "label5";
            label5.Size = new Size(48, 25);
            label5.TabIndex = 13;
            label5.Text = "Year:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(304, 170);
            label6.Name = "label6";
            label6.Size = new Size(73, 25);
            label6.TabIndex = 14;
            label6.Text = "Season:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(458, 170);
            label7.Name = "label7";
            label7.Size = new Size(79, 25);
            label7.TabIndex = 15;
            label7.Text = "Episode:";
            // 
            // fhdCheckBox
            // 
            fhdCheckBox.AutoSize = true;
            fhdCheckBox.Checked = true;
            fhdCheckBox.CheckState = CheckState.Checked;
            fhdCheckBox.Location = new Point(631, 169);
            fhdCheckBox.Name = "fhdCheckBox";
            fhdCheckBox.Size = new Size(73, 29);
            fhdCheckBox.TabIndex = 16;
            fhdCheckBox.Text = "FHD";
            fhdCheckBox.UseVisualStyleBackColor = true;
            // 
            // translatedEpisodeTitleTextBox
            // 
            translatedEpisodeTitleTextBox.Location = new Point(212, 241);
            translatedEpisodeTitleTextBox.Name = "translatedEpisodeTitleTextBox";
            translatedEpisodeTitleTextBox.Size = new Size(576, 31);
            translatedEpisodeTitleTextBox.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 244);
            label8.Name = "label8";
            label8.Size = new Size(200, 25);
            label8.TabIndex = 20;
            label8.Text = "Translated Episode Title:";
            // 
            // episodeTitleTextBox
            // 
            episodeTitleTextBox.Location = new Point(212, 204);
            episodeTitleTextBox.Name = "episodeTitleTextBox";
            episodeTitleTextBox.Size = new Size(576, 31);
            episodeTitleTextBox.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(90, 207);
            label9.Name = "label9";
            label9.Size = new Size(116, 25);
            label9.TabIndex = 18;
            label9.Text = "Episode Title:";
            // 
            // directorTextBox
            // 
            directorTextBox.Location = new Point(212, 278);
            directorTextBox.Name = "directorTextBox";
            directorTextBox.Size = new Size(576, 31);
            directorTextBox.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(127, 281);
            label10.Name = "label10";
            label10.Size = new Size(79, 25);
            label10.TabIndex = 22;
            label10.Text = "Director:";
            // 
            // actorsTextBox
            // 
            actorsTextBox.Location = new Point(212, 315);
            actorsTextBox.Name = "actorsTextBox";
            actorsTextBox.Size = new Size(576, 31);
            actorsTextBox.TabIndex = 25;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(120, 318);
            label11.Name = "label11";
            label11.Size = new Size(86, 25);
            label11.TabIndex = 24;
            label11.Text = "Actors (,):";
            // 
            // genresTextBox
            // 
            genresTextBox.Location = new Point(212, 352);
            genresTextBox.Name = "genresTextBox";
            genresTextBox.Size = new Size(576, 31);
            genresTextBox.TabIndex = 27;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(117, 355);
            label12.Name = "label12";
            label12.Size = new Size(89, 25);
            label12.TabIndex = 26;
            label12.Text = "Genres (,):";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(137, 392);
            label13.Name = "label13";
            label13.Size = new Size(69, 25);
            label13.TabIndex = 30;
            label13.Text = "4K URI:";
            // 
            // uri4kTextBox
            // 
            uri4kTextBox.Location = new Point(212, 389);
            uri4kTextBox.Name = "uri4kTextBox";
            uri4kTextBox.ReadOnly = true;
            uri4kTextBox.Size = new Size(576, 31);
            uri4kTextBox.TabIndex = 29;
            // 
            // select4kUriButton
            // 
            select4kUriButton.Enabled = false;
            select4kUriButton.Location = new Point(12, 389);
            select4kUriButton.Name = "select4kUriButton";
            select4kUriButton.Size = new Size(80, 34);
            select4kUriButton.TabIndex = 28;
            select4kUriButton.Text = "Select";
            select4kUriButton.UseVisualStyleBackColor = true;
            select4kUriButton.Click += select4kUriButton_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(111, 429);
            label14.Name = "label14";
            label14.Size = new Size(95, 25);
            label14.TabIndex = 33;
            label14.Text = "Cover URI:";
            // 
            // coverUriTextBox
            // 
            coverUriTextBox.Location = new Point(212, 426);
            coverUriTextBox.Name = "coverUriTextBox";
            coverUriTextBox.ReadOnly = true;
            coverUriTextBox.Size = new Size(576, 31);
            coverUriTextBox.TabIndex = 32;
            // 
            // selectCoverUriButton
            // 
            selectCoverUriButton.Enabled = false;
            selectCoverUriButton.Location = new Point(12, 426);
            selectCoverUriButton.Name = "selectCoverUriButton";
            selectCoverUriButton.Size = new Size(80, 34);
            selectCoverUriButton.TabIndex = 31;
            selectCoverUriButton.Text = "Select";
            selectCoverUriButton.UseVisualStyleBackColor = true;
            selectCoverUriButton.Click += selectCoverUriButton_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(104, 466);
            label15.Name = "label15";
            label15.Size = new Size(102, 25);
            label15.TabIndex = 36;
            label15.Text = "Theme URI:";
            // 
            // themeUriTextBox
            // 
            themeUriTextBox.Location = new Point(212, 463);
            themeUriTextBox.Name = "themeUriTextBox";
            themeUriTextBox.ReadOnly = true;
            themeUriTextBox.Size = new Size(576, 31);
            themeUriTextBox.TabIndex = 35;
            // 
            // selectThemeUriButton
            // 
            selectThemeUriButton.Enabled = false;
            selectThemeUriButton.Location = new Point(12, 463);
            selectThemeUriButton.Name = "selectThemeUriButton";
            selectThemeUriButton.Size = new Size(80, 34);
            selectThemeUriButton.TabIndex = 34;
            selectThemeUriButton.Text = "Select";
            selectThemeUriButton.UseVisualStyleBackColor = true;
            selectThemeUriButton.Click += selectThemeUriButton_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(104, 503);
            label16.Name = "label16";
            label16.Size = new Size(102, 25);
            label16.TabIndex = 39;
            label16.Text = "Subtitle SR:";
            // 
            // subtitleSrTextBox
            // 
            subtitleSrTextBox.Location = new Point(212, 500);
            subtitleSrTextBox.Name = "subtitleSrTextBox";
            subtitleSrTextBox.ReadOnly = true;
            subtitleSrTextBox.Size = new Size(576, 31);
            subtitleSrTextBox.TabIndex = 38;
            // 
            // selectSubtitleSrButton
            // 
            selectSubtitleSrButton.Enabled = false;
            selectSubtitleSrButton.Location = new Point(12, 500);
            selectSubtitleSrButton.Name = "selectSubtitleSrButton";
            selectSubtitleSrButton.Size = new Size(80, 34);
            selectSubtitleSrButton.TabIndex = 37;
            selectSubtitleSrButton.Text = "Select";
            selectSubtitleSrButton.UseVisualStyleBackColor = true;
            selectSubtitleSrButton.Click += selectSubtitleSrButton_Click;
            // 
            // createButton
            // 
            createButton.Enabled = false;
            createButton.Location = new Point(676, 574);
            createButton.Name = "createButton";
            createButton.Size = new Size(112, 34);
            createButton.TabIndex = 40;
            createButton.Text = "Create";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(103, 540);
            label17.Name = "label17";
            label17.Size = new Size(103, 25);
            label17.TabIndex = 43;
            label17.Text = "Subtitle EN:";
            // 
            // subtitleEnTextBox
            // 
            subtitleEnTextBox.Location = new Point(212, 537);
            subtitleEnTextBox.Name = "subtitleEnTextBox";
            subtitleEnTextBox.ReadOnly = true;
            subtitleEnTextBox.Size = new Size(576, 31);
            subtitleEnTextBox.TabIndex = 42;
            // 
            // selectSubtitleEnButton
            // 
            selectSubtitleEnButton.Enabled = false;
            selectSubtitleEnButton.Location = new Point(12, 537);
            selectSubtitleEnButton.Name = "selectSubtitleEnButton";
            selectSubtitleEnButton.Size = new Size(80, 34);
            selectSubtitleEnButton.TabIndex = 41;
            selectSubtitleEnButton.Text = "Select";
            selectSubtitleEnButton.UseVisualStyleBackColor = true;
            selectSubtitleEnButton.Click += selectSubtitleEnButton_Click;
            // 
            // resTextArea
            // 
            resTextArea.Enabled = false;
            resTextArea.Location = new Point(794, 12);
            resTextArea.Name = "resTextArea";
            resTextArea.ReadOnly = true;
            resTextArea.Size = new Size(360, 597);
            resTextArea.TabIndex = 44;
            resTextArea.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1166, 621);
            Controls.Add(resTextArea);
            Controls.Add(label17);
            Controls.Add(subtitleEnTextBox);
            Controls.Add(selectSubtitleEnButton);
            Controls.Add(createButton);
            Controls.Add(label16);
            Controls.Add(subtitleSrTextBox);
            Controls.Add(selectSubtitleSrButton);
            Controls.Add(label15);
            Controls.Add(themeUriTextBox);
            Controls.Add(selectThemeUriButton);
            Controls.Add(label14);
            Controls.Add(coverUriTextBox);
            Controls.Add(selectCoverUriButton);
            Controls.Add(label13);
            Controls.Add(uri4kTextBox);
            Controls.Add(select4kUriButton);
            Controls.Add(genresTextBox);
            Controls.Add(label12);
            Controls.Add(actorsTextBox);
            Controls.Add(label11);
            Controls.Add(directorTextBox);
            Controls.Add(label10);
            Controls.Add(translatedEpisodeTitleTextBox);
            Controls.Add(label8);
            Controls.Add(episodeTitleTextBox);
            Controls.Add(label9);
            Controls.Add(fhdCheckBox);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(episodeNumeric);
            Controls.Add(seasonNumeric);
            Controls.Add(yearNumeric);
            Controls.Add(translatedTitleTextBox);
            Controls.Add(label4);
            Controls.Add(titleTextBox);
            Controls.Add(label3);
            Controls.Add(selectRootButton);
            Controls.Add(rootTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(uriTextBox);
            Controls.Add(selectVideoButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "TV Espresso Admin";
            ((System.ComponentModel.ISupportInitialize)yearNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)seasonNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)episodeNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button selectVideoButton;
        private TextBox uriTextBox;
        private Label label1;
        private Label label2;
        private TextBox rootTextBox;
        private Button selectRootButton;
        private Label label3;
        private TextBox titleTextBox;
        private TextBox translatedTitleTextBox;
        private Label label4;
        private NumericUpDown yearNumeric;
        private NumericUpDown seasonNumeric;
        private NumericUpDown episodeNumeric;
        private Label label5;
        private Label label6;
        private Label label7;
        private CheckBox fhdCheckBox;
        private TextBox translatedEpisodeTitleTextBox;
        private Label label8;
        private TextBox episodeTitleTextBox;
        private Label label9;
        private TextBox directorTextBox;
        private Label label10;
        private TextBox actorsTextBox;
        private Label label11;
        private TextBox genresTextBox;
        private Label label12;
        private Label label13;
        private TextBox uri4kTextBox;
        private Button select4kUriButton;
        private Label label14;
        private TextBox coverUriTextBox;
        private Button selectCoverUriButton;
        private Label label15;
        private TextBox themeUriTextBox;
        private Button selectThemeUriButton;
        private Label label16;
        private TextBox subtitleSrTextBox;
        private Button selectSubtitleSrButton;
        private Button createButton;
        private Label label17;
        private TextBox subtitleEnTextBox;
        private Button selectSubtitleEnButton;
        private RichTextBox resTextArea;
    }
}
