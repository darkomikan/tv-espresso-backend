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
            remove4kUriButton = new Button();
            removeCoverUriButton = new Button();
            removeThemeUriButton = new Button();
            removeSubtitleSrButton = new Button();
            removeSubtitleEnButton = new Button();
            selectShowButton = new Button();
            videoList = new ListBox();
            groupBox1 = new GroupBox();
            showSubtitlesEnCheckBox = new CheckBox();
            titleStartsCheckBox = new CheckBox();
            label20 = new Label();
            episodeRegexTextBox = new TextBox();
            label19 = new Label();
            startsWithTextBox = new TextBox();
            removeDotsCheckBox = new CheckBox();
            label18 = new Label();
            endsWithTextBox = new TextBox();
            skipSegmentsTextBox = new TextBox();
            label21 = new Label();
            previousTitleTextBox = new TextBox();
            label22 = new Label();
            priorityNumeric = new NumericUpDown();
            label23 = new Label();
            ((System.ComponentModel.ISupportInitialize)yearNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)seasonNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)episodeNumeric).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)priorityNumeric).BeginInit();
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
            uriTextBox.Size = new Size(693, 31);
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
            rootTextBox.Size = new Size(693, 31);
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
            titleTextBox.Size = new Size(693, 31);
            titleTextBox.TabIndex = 7;
            // 
            // translatedTitleTextBox
            // 
            translatedTitleTextBox.Location = new Point(212, 131);
            translatedTitleTextBox.Name = "translatedTitleTextBox";
            translatedTitleTextBox.Size = new Size(693, 31);
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
            translatedEpisodeTitleTextBox.Size = new Size(693, 31);
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
            episodeTitleTextBox.Size = new Size(693, 31);
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
            directorTextBox.Size = new Size(693, 31);
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
            actorsTextBox.Size = new Size(693, 31);
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
            genresTextBox.Size = new Size(693, 31);
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
            label13.Location = new Point(137, 466);
            label13.Name = "label13";
            label13.Size = new Size(69, 25);
            label13.TabIndex = 30;
            label13.Text = "4K URI:";
            // 
            // uri4kTextBox
            // 
            uri4kTextBox.Location = new Point(212, 463);
            uri4kTextBox.Name = "uri4kTextBox";
            uri4kTextBox.ReadOnly = true;
            uri4kTextBox.Size = new Size(645, 31);
            uri4kTextBox.TabIndex = 29;
            // 
            // select4kUriButton
            // 
            select4kUriButton.Enabled = false;
            select4kUriButton.Location = new Point(12, 463);
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
            label14.Location = new Point(111, 503);
            label14.Name = "label14";
            label14.Size = new Size(95, 25);
            label14.TabIndex = 33;
            label14.Text = "Cover URI:";
            // 
            // coverUriTextBox
            // 
            coverUriTextBox.Location = new Point(212, 500);
            coverUriTextBox.Name = "coverUriTextBox";
            coverUriTextBox.ReadOnly = true;
            coverUriTextBox.Size = new Size(645, 31);
            coverUriTextBox.TabIndex = 32;
            // 
            // selectCoverUriButton
            // 
            selectCoverUriButton.Enabled = false;
            selectCoverUriButton.Location = new Point(12, 500);
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
            label15.Location = new Point(104, 540);
            label15.Name = "label15";
            label15.Size = new Size(102, 25);
            label15.TabIndex = 36;
            label15.Text = "Theme URI:";
            // 
            // themeUriTextBox
            // 
            themeUriTextBox.Location = new Point(212, 537);
            themeUriTextBox.Name = "themeUriTextBox";
            themeUriTextBox.ReadOnly = true;
            themeUriTextBox.Size = new Size(645, 31);
            themeUriTextBox.TabIndex = 35;
            // 
            // selectThemeUriButton
            // 
            selectThemeUriButton.Enabled = false;
            selectThemeUriButton.Location = new Point(12, 537);
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
            label16.Location = new Point(104, 577);
            label16.Name = "label16";
            label16.Size = new Size(102, 25);
            label16.TabIndex = 39;
            label16.Text = "Subtitle SR:";
            // 
            // subtitleSrTextBox
            // 
            subtitleSrTextBox.Location = new Point(212, 574);
            subtitleSrTextBox.Name = "subtitleSrTextBox";
            subtitleSrTextBox.ReadOnly = true;
            subtitleSrTextBox.Size = new Size(645, 31);
            subtitleSrTextBox.TabIndex = 38;
            // 
            // selectSubtitleSrButton
            // 
            selectSubtitleSrButton.Enabled = false;
            selectSubtitleSrButton.Location = new Point(12, 574);
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
            createButton.Location = new Point(735, 651);
            createButton.Name = "createButton";
            createButton.Size = new Size(170, 34);
            createButton.TabIndex = 40;
            createButton.Text = "Create";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(103, 614);
            label17.Name = "label17";
            label17.Size = new Size(103, 25);
            label17.TabIndex = 43;
            label17.Text = "Subtitle EN:";
            // 
            // subtitleEnTextBox
            // 
            subtitleEnTextBox.Location = new Point(212, 611);
            subtitleEnTextBox.Name = "subtitleEnTextBox";
            subtitleEnTextBox.ReadOnly = true;
            subtitleEnTextBox.Size = new Size(645, 31);
            subtitleEnTextBox.TabIndex = 42;
            // 
            // selectSubtitleEnButton
            // 
            selectSubtitleEnButton.Enabled = false;
            selectSubtitleEnButton.Location = new Point(12, 611);
            selectSubtitleEnButton.Name = "selectSubtitleEnButton";
            selectSubtitleEnButton.Size = new Size(80, 34);
            selectSubtitleEnButton.TabIndex = 41;
            selectSubtitleEnButton.Text = "Select";
            selectSubtitleEnButton.UseVisualStyleBackColor = true;
            selectSubtitleEnButton.Click += selectSubtitleEnButton_Click;
            // 
            // resTextArea
            // 
            resTextArea.Location = new Point(12, 691);
            resTextArea.Name = "resTextArea";
            resTextArea.ReadOnly = true;
            resTextArea.Size = new Size(893, 376);
            resTextArea.TabIndex = 44;
            resTextArea.Text = "";
            // 
            // remove4kUriButton
            // 
            remove4kUriButton.BackColor = Color.OrangeRed;
            remove4kUriButton.Enabled = false;
            remove4kUriButton.ForeColor = SystemColors.ButtonFace;
            remove4kUriButton.Location = new Point(863, 463);
            remove4kUriButton.Name = "remove4kUriButton";
            remove4kUriButton.Size = new Size(42, 34);
            remove4kUriButton.TabIndex = 45;
            remove4kUriButton.Text = "X";
            remove4kUriButton.UseVisualStyleBackColor = false;
            remove4kUriButton.Click += remove4kUriButton_Click;
            // 
            // removeCoverUriButton
            // 
            removeCoverUriButton.BackColor = Color.OrangeRed;
            removeCoverUriButton.Enabled = false;
            removeCoverUriButton.ForeColor = SystemColors.ButtonFace;
            removeCoverUriButton.Location = new Point(863, 500);
            removeCoverUriButton.Name = "removeCoverUriButton";
            removeCoverUriButton.Size = new Size(42, 34);
            removeCoverUriButton.TabIndex = 46;
            removeCoverUriButton.Text = "X";
            removeCoverUriButton.UseVisualStyleBackColor = false;
            removeCoverUriButton.Click += removeCoverUriButton_Click;
            // 
            // removeThemeUriButton
            // 
            removeThemeUriButton.BackColor = Color.OrangeRed;
            removeThemeUriButton.Enabled = false;
            removeThemeUriButton.ForeColor = SystemColors.ButtonFace;
            removeThemeUriButton.Location = new Point(863, 537);
            removeThemeUriButton.Name = "removeThemeUriButton";
            removeThemeUriButton.Size = new Size(42, 34);
            removeThemeUriButton.TabIndex = 47;
            removeThemeUriButton.Text = "X";
            removeThemeUriButton.UseVisualStyleBackColor = false;
            removeThemeUriButton.Click += removeThemeUriButton_Click;
            // 
            // removeSubtitleSrButton
            // 
            removeSubtitleSrButton.BackColor = Color.OrangeRed;
            removeSubtitleSrButton.Enabled = false;
            removeSubtitleSrButton.ForeColor = SystemColors.ButtonFace;
            removeSubtitleSrButton.Location = new Point(863, 574);
            removeSubtitleSrButton.Name = "removeSubtitleSrButton";
            removeSubtitleSrButton.Size = new Size(42, 34);
            removeSubtitleSrButton.TabIndex = 48;
            removeSubtitleSrButton.Text = "X";
            removeSubtitleSrButton.UseVisualStyleBackColor = false;
            removeSubtitleSrButton.Click += removeSubtitleSrButton_Click;
            // 
            // removeSubtitleEnButton
            // 
            removeSubtitleEnButton.BackColor = Color.OrangeRed;
            removeSubtitleEnButton.Enabled = false;
            removeSubtitleEnButton.ForeColor = SystemColors.ButtonFace;
            removeSubtitleEnButton.Location = new Point(863, 611);
            removeSubtitleEnButton.Name = "removeSubtitleEnButton";
            removeSubtitleEnButton.Size = new Size(42, 34);
            removeSubtitleEnButton.TabIndex = 49;
            removeSubtitleEnButton.Text = "X";
            removeSubtitleEnButton.UseVisualStyleBackColor = false;
            removeSubtitleEnButton.Click += removeSubtitleEnButton_Click;
            // 
            // selectShowButton
            // 
            selectShowButton.Enabled = false;
            selectShowButton.Location = new Point(12, 94);
            selectShowButton.Name = "selectShowButton";
            selectShowButton.Size = new Size(134, 34);
            selectShowButton.TabIndex = 50;
            selectShowButton.Text = "Select Show";
            selectShowButton.UseVisualStyleBackColor = true;
            selectShowButton.Click += selectShowButton_Click;
            // 
            // videoList
            // 
            videoList.FormattingEnabled = true;
            videoList.Location = new Point(911, 312);
            videoList.Name = "videoList";
            videoList.Size = new Size(443, 754);
            videoList.TabIndex = 51;
            videoList.SelectedIndexChanged += videoList_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(showSubtitlesEnCheckBox);
            groupBox1.Controls.Add(titleStartsCheckBox);
            groupBox1.Controls.Add(label20);
            groupBox1.Controls.Add(episodeRegexTextBox);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(startsWithTextBox);
            groupBox1.Controls.Add(removeDotsCheckBox);
            groupBox1.Controls.Add(label18);
            groupBox1.Controls.Add(endsWithTextBox);
            groupBox1.Location = new Point(911, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(442, 294);
            groupBox1.TabIndex = 52;
            groupBox1.TabStop = false;
            groupBox1.Text = "Episode Title Extractor";
            // 
            // showSubtitlesEnCheckBox
            // 
            showSubtitlesEnCheckBox.AutoSize = true;
            showSubtitlesEnCheckBox.Location = new Point(104, 259);
            showSubtitlesEnCheckBox.Name = "showSubtitlesEnCheckBox";
            showSubtitlesEnCheckBox.Size = new Size(294, 29);
            showSubtitlesEnCheckBox.TabIndex = 23;
            showSubtitlesEnCheckBox.Text = "Show subtitles are EN by default";
            showSubtitlesEnCheckBox.UseVisualStyleBackColor = true;
            // 
            // titleStartsCheckBox
            // 
            titleStartsCheckBox.AutoSize = true;
            titleStartsCheckBox.Checked = true;
            titleStartsCheckBox.CheckState = CheckState.Checked;
            titleStartsCheckBox.Location = new Point(104, 82);
            titleStartsCheckBox.Name = "titleStartsCheckBox";
            titleStartsCheckBox.Size = new Size(294, 29);
            titleStartsCheckBox.TabIndex = 22;
            titleStartsCheckBox.Text = "Title starts after episode number";
            titleStartsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(6, 45);
            label20.Name = "label20";
            label20.Size = new Size(194, 25);
            label20.TabIndex = 21;
            label20.Text = "Episode number regex:";
            // 
            // episodeRegexTextBox
            // 
            episodeRegexTextBox.Location = new Point(206, 42);
            episodeRegexTextBox.Name = "episodeRegexTextBox";
            episodeRegexTextBox.Size = new Size(230, 31);
            episodeRegexTextBox.TabIndex = 20;
            episodeRegexTextBox.Text = "E\\d{2}";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(6, 122);
            label19.Name = "label19";
            label19.Size = new Size(98, 25);
            label19.TabIndex = 19;
            label19.Text = "Starts with:";
            // 
            // startsWithTextBox
            // 
            startsWithTextBox.Location = new Point(110, 119);
            startsWithTextBox.Name = "startsWithTextBox";
            startsWithTextBox.Size = new Size(326, 31);
            startsWithTextBox.TabIndex = 18;
            // 
            // removeDotsCheckBox
            // 
            removeDotsCheckBox.AutoSize = true;
            removeDotsCheckBox.Checked = true;
            removeDotsCheckBox.CheckState = CheckState.Checked;
            removeDotsCheckBox.Location = new Point(104, 198);
            removeDotsCheckBox.Name = "removeDotsCheckBox";
            removeDotsCheckBox.Size = new Size(143, 29);
            removeDotsCheckBox.TabIndex = 17;
            removeDotsCheckBox.Text = "Remove dots";
            removeDotsCheckBox.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(12, 162);
            label18.Name = "label18";
            label18.Size = new Size(92, 25);
            label18.TabIndex = 9;
            label18.Text = "Ends with:";
            // 
            // endsWithTextBox
            // 
            endsWithTextBox.Location = new Point(110, 159);
            endsWithTextBox.Name = "endsWithTextBox";
            endsWithTextBox.Size = new Size(326, 31);
            endsWithTextBox.TabIndex = 8;
            // 
            // skipSegmentsTextBox
            // 
            skipSegmentsTextBox.Location = new Point(316, 389);
            skipSegmentsTextBox.Name = "skipSegmentsTextBox";
            skipSegmentsTextBox.Size = new Size(589, 31);
            skipSegmentsTextBox.TabIndex = 54;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(6, 392);
            label21.Name = "label21";
            label21.Size = new Size(304, 25);
            label21.TabIndex = 53;
            label21.Text = "Skip Segments (h:mm:ss-h:mm:ss,...):";
            // 
            // previousTitleTextBox
            // 
            previousTitleTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            previousTitleTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            previousTitleTextBox.Location = new Point(212, 426);
            previousTitleTextBox.Name = "previousTitleTextBox";
            previousTitleTextBox.Size = new Size(693, 31);
            previousTitleTextBox.TabIndex = 56;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(54, 429);
            label22.Name = "label22";
            label22.Size = new Size(152, 25);
            label22.TabIndex = 55;
            label22.Text = "Comes After Title:";
            // 
            // priorityNumeric
            // 
            priorityNumeric.Location = new Point(836, 168);
            priorityNumeric.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            priorityNumeric.Name = "priorityNumeric";
            priorityNumeric.Size = new Size(69, 31);
            priorityNumeric.TabIndex = 57;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(727, 170);
            label23.Name = "label23";
            label23.Size = new Size(103, 25);
            label23.TabIndex = 58;
            label23.Text = "List Priority:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1365, 1079);
            Controls.Add(label23);
            Controls.Add(priorityNumeric);
            Controls.Add(previousTitleTextBox);
            Controls.Add(label22);
            Controls.Add(skipSegmentsTextBox);
            Controls.Add(label21);
            Controls.Add(groupBox1);
            Controls.Add(videoList);
            Controls.Add(selectShowButton);
            Controls.Add(removeSubtitleEnButton);
            Controls.Add(removeSubtitleSrButton);
            Controls.Add(removeThemeUriButton);
            Controls.Add(removeCoverUriButton);
            Controls.Add(remove4kUriButton);
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)priorityNumeric).EndInit();
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
        private Button remove4kUriButton;
        private Button removeCoverUriButton;
        private Button removeThemeUriButton;
        private Button removeSubtitleSrButton;
        private Button removeSubtitleEnButton;
        private Button selectShowButton;
        private ListBox videoList;
        private GroupBox groupBox1;
        private CheckBox removeDotsCheckBox;
        private Label label18;
        private TextBox endsWithTextBox;
        private Label label20;
        private TextBox episodeRegexTextBox;
        private Label label19;
        private TextBox startsWithTextBox;
        private CheckBox titleStartsCheckBox;
        private CheckBox showSubtitlesEnCheckBox;
        private TextBox skipSegmentsTextBox;
        private Label label21;
        private TextBox previousTitleTextBox;
        private Label label22;
        private NumericUpDown priorityNumeric;
        private Label label23;
    }
}
