using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mew.AppLogAndEventHelper;
using Mew.AppLogAndEventHelper.Helpers;
using ScreenshotsForCasinos.Properties;

namespace ScreenshotsForCasinos {
    public partial class FCasinos : Form {
        private readonly List<Button> buttons_;
        public CasinoManager casinoManager_;

        private DateTime lastTime_ = DateTime.Now;
        private readonly List<Button> mandatoryDesktopButtons_;
        private readonly List<Button> mandatoryMobileButtons_;
        private readonly List<Button> optionalDesktopButtons_;
        private readonly List<Button> optionalMobileButtons_;

        public FCasinos() {
            this.InitializeComponent();
            AppLogAndEventHelper.Instance.AddReciever(this.RecieveError);

            #region ButtonsInit

            this.mandatoryDesktopButtons_ = new List<Button> {
                this.bDesktop1,
                this.bDesktop2,
                this.bDesktop3,
                this.bDesktop4,
                this.bDesktop5,
                this.bDesktop6
            };
            this.optionalDesktopButtons_ = new List<Button> {
                this.bDesktop7,
                this.bDesktop8,
                this.bDesktop9,
                this.bDesktop10,
                this.bDesktop11,
                this.bDesktop12
            };
            this.mandatoryMobileButtons_ = new List<Button> {
                this.bMobile1,
                this.bMobile2,
                this.bMobile3,
                this.bMobile4,
                this.bMobile5,
                this.bMobile6
            };
            this.optionalMobileButtons_ = new List<Button> {
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

            var m_names = new List<string> {
                "home_page",
                "casino_games",
                "banking",
                "bonus",
                "login",
                "support"
            };
            var o_names = new List<string> {
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

            this.hScrollBar1.Minimum = int.Parse(this.casinoManager_.Casinos.First(c => c != null).ID);
            this.hScrollBar1.Maximum = int.Parse(this.casinoManager_.Casinos.Last(c => c != null).ID);

            this.hScrollBar1.Value = Math.Max(
                Math.Min(Settings.Default.CurrentId, this.hScrollBar1.Maximum),
                this.hScrollBar1.Minimum);
            this.hScrollBar1_ValueChanged(this, null);
        }

        private void LoadCasino(Casino casino) {
            this.llDomain.Text = $"https://{casino.Domain}";

            foreach (var button in this.buttons_) {
                var name = ButtonToSSType(button);
                if (casino.ScreenshotExists(name))
                    button.BackColor = Color.ForestGreen;
                else
                    button.BackColor = Color.RosyBrown;
            }

            this.hScrollBar1.Value = int.Parse(casino.ID);
            this.casinoManager_.CurrentCasino = casino;
            Settings.Default.CurrentId = int.Parse(casino.ID);
            Settings.Default.Save();
        }

        private static string ButtonToSSType(Button button) => $"{button.Parent.Text}{button.Text}";

        private void ButtonClick(object sender, EventArgs e) {
            var button = (Button) sender;
            AppLogAndEventHelper.Instance.RaiseDebugInfo(button.Name, button.Text);
            var ss_type = ButtonToSSType(button);
            var file_path = "";
            try {
                this.casinoManager_.CurrentCasino.LazyInit(this.casinoManager_.DataDir);

                file_path = this.casinoManager_.CurrentCasino.ScreenshotPath(ss_type);
                this.GetLastFile(this.casinoManager_.ScreenshotsDir, file_path);

                if (this.casinoManager_.CurrentCasino.AddScreenshot(ss_type, file_path)) {
                    this.casinoManager_.UpdateCurrentCasino();
                    button.BackColor = Color.ForestGreen;
                }
                else {
                    AppLogAndEventHelper.Instance.RaiseError(button, $"No file {file_path}");
                    button.BackColor = Color.RosyBrown;
                }
            }
            catch (Exception ex) {
                AppLogAndEventHelper.Instance.RaiseError(button, $"No file {file_path}\n{ex}");
            }
        }

        private void GetLastFile(DirectoryInfo dir, string file_path) {
            var f = dir.GetFiles("*.png")
                .OrderByDescending(f => f.CreationTime)
                .FirstOrDefault();
            if (DateTime.Compare(this.lastTime_, f.CreationTime) > 0) throw new Exception($"{f.Name} time {f.CreationTime:O} < {this.lastTime_:O}");

            f.MoveTo(file_path, true);
            this.lastTime_ = DateTime.Now;
            AppLogAndEventHelper.Instance.RaiseDebugInfo($"{f.FullName} => {file_path}");
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e) {
            if (this.casinoManager_.CurrentCasino == null || this.hScrollBar1.Value != int.Parse(this.casinoManager_.CurrentCasino.ID))
                this.LoadCasino(this.casinoManager_.Casinos[this.hScrollBar1.Value]);
        }

        private void llDomain_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            // Specify that the link was visited.
            this.llDomain.LinkVisited = true;

            // Navigate to a URL.
            Process.Start("\"C:\\Users\\rudak\\AppData\\Local\\Mozilla Firefox\\firefox.exe\"", this.llDomain.Text);
        }

        private void miTransparent_Click(object sender, EventArgs e) {
            this.AllowTransparency = !this.AllowTransparency;
        }

        private void miReport_Click(object sender, EventArgs e) {
            var ss_types = "home_page;casino_games;banking;bonus;login;support;sports_betting;live_casino;casino_game_1;casino_game_2;casino_game_3;app;mobile_home_page;mobile_casino_games;mobile_banking;mobile_sports_betting;mobile_live_casino;mobile_bonus;mobile_login;mobile_support;mobile_casino_game_1;mobile_casino_game_2;mobile_casino_game_3;mobile_app";
            var types = ss_types.Split(";");

            var sb = new StringBuilder();
            sb.AppendLine($"id;domain;;{ss_types}");

            foreach (var c in this.casinoManager_.Casinos.Where(x => x != null)) {
                sb.Append($"{c.ID};{c.Domain};;");
                foreach (var t in types) sb.Append($"{(c.ScreenshotExists(t) ? "1" : "0")};");

                sb.AppendLine();
            }

            sb.ToString().WriteToFile2(this.casinoManager_.WorkingDir.GetFile("\\report.csv"));
        }

        private void RecieveError(Event e) {
            //if (e.Type != EventType.Error) return;
            //if (e.Comments[0] is Control)
            //    this.errorProvider1.SetError((Control) e.Comments[0], e.CommentsToString());
            //else this.errorProvider1.SetError(this.llDomain, e.CommentsToString());
        }
    }
}