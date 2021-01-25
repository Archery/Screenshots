﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Mew.AppLogAndEventHelper;
using ScreenshotsForCasinos.Properties;

namespace ScreenshotsForCasinos {
    public partial class FCasinos : Form {
        private List<Button> buttons_;
        private List<Button> mandatoryDesktopButtons_;
        private List<Button> optionalDesktopButtons_;
        private List<Button> mandatoryMobileButtons_;
        private List<Button> optionalMobileButtons_;
        public CasinoManager casinoManager_;

        public FCasinos() {
            this.InitializeComponent();

            #region ButtonsInit

            this.mandatoryDesktopButtons_ = new List<Button>() {
                this.bDesktop1,
                this.bDesktop2,
                this.bDesktop3,
                this.bDesktop4,
                this.bDesktop5,
                this.bDesktop6
            };
            this.optionalDesktopButtons_ = new List<Button>() {
                this.bDesktop7,
                this.bDesktop8,
                this.bDesktop9,
                this.bDesktop10,
                this.bDesktop11,
                this.bDesktop12
            };
            this.mandatoryMobileButtons_ = new List<Button>() {
                this.bMobile1,
                this.bMobile2,
                this.bMobile3,
                this.bMobile4,
                this.bMobile5,
                this.bMobile6
            };
            this.optionalMobileButtons_ = new List<Button>() {
                this.bMobile7,
                this.bMobile8,
                this.bMobile9,
                this.bMobile10,
                this.bMobile11,
                this.bMobile12
            };

            this.buttons_ = new List<Button>();
            this.buttons_.AddRange(this.mandatoryDesktopButtons_);
            this.buttons_.AddRange(this.mandatoryMobileButtons_);
            this.buttons_.AddRange(this.optionalDesktopButtons_);
            this.buttons_.AddRange(this.optionalMobileButtons_);

            var m_names = new List<string>() {
                "home_page",
                "casino_games",
                "banking",
                "bonus",
                "login",
                "support"
            };
            var o_names = new List<string>() {
                "sports_betting",
                "live_casino",
                "casino_game_1",
                "casino_game_2",
                "casino_game_3",
                "app"
            };

            for (var i = 0; i < 6; i++) {
                this.mandatoryDesktopButtons_[i].Text = m_names[i];
                this.mandatoryMobileButtons_[i].Text = m_names[i];
                this.optionalDesktopButtons_[i].Text = o_names[i];
                this.optionalMobileButtons_[i].Text = o_names[i];

                this.mandatoryDesktopButtons_[i].Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
                this.mandatoryMobileButtons_[i].Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
                this.optionalDesktopButtons_[i].Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
                this.optionalMobileButtons_[i].Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point);
            }

            foreach (var button in this.buttons_) button.Click += this.ButtonClick;

            #endregion

            this.casinoManager_ = new CasinoManager();
            this.casinoManager_.CreateList();

            this.hScrollBar1.Minimum = this.casinoManager_.Casinos.First(c => c != null).ID;
            this.hScrollBar1.Maximum = this.casinoManager_.Casinos.Last(c => c != null).ID;

            this.hScrollBar1.Value = Math.Max(
                Math.Min(Settings.Default.CurrentId, this.hScrollBar1.Maximum),
                this.hScrollBar1.Minimum);
        }

        private void LoadCasino(Casino casino) {
            this.llDomain.Text = $"{casino.ID} https://{casino.Domain}";

            foreach (var button in this.buttons_) {
                var name = ButtonToSSType(button);
                if (casino.ScreenshotExists(name))
                    button.BackColor = Color.ForestGreen;
                else
                    button.BackColor = Color.RosyBrown;
            }

            this.hScrollBar1.Value = casino.ID;
            this.casinoManager_.CurrentCasino = casino;
            Settings.Default.CurrentId = casino.ID;
        }

        private static string ButtonToSSType(Button button) => $"{button.Parent.Text}_{button.Text}";

        private void ButtonClick(object sender, EventArgs e) {
            var button = (Button) sender;
            var ss_type = ButtonToSSType(button);
            var file_path = this.casinoManager_.CurrentCasino.ScreenshotPath
                (ss_type);
            this.casinoManager_.CurrentCasino.LazyInit(this.casinoManager_.WorkingDir);
            this.GetLastFile(this.casinoManager_.ScreenshotsDir, file_path);
            var b = this.casinoManager_.CurrentCasino.AddScreenshot(ss_type, file_path);
            if (!b) AppLogAndEventHelper.Instance.RaiseError($"No file {file_path}");
        }

        private void GetLastFile(DirectoryInfo dir, string file_path) {
            var f = dir.GetFiles("*.png,*.jpg")
                .OrderByDescending(f => f.LastWriteTime)
                .First();

            f.CopyTo(file_path);
            AppLogAndEventHelper.Instance.RaiseDebugInfo($"{f.FullName} => {file_path}");
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e) {
            if (this.casinoManager_.CurrentCasino == null || this.hScrollBar1.Value != this.casinoManager_.CurrentCasino.ID)
                this.LoadCasino(this.casinoManager_.Casinos[this.hScrollBar1.Value]);
        }
    }
}