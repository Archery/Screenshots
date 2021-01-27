using System.Collections.Generic;
using System.IO;
using System.Linq;
using LiteDB;
using Mew.AppLogAndEventHelper;
using Mew.AppLogAndEventHelper.Helpers;
using ScreenshotsForCasinos.Properties;

namespace ScreenshotsForCasinos {
    public class CasinoManager {
        public List<Casino> Casinos = new List<Casino>(1000);
        private int currentIndex_ = -1;

        public Casino CurrentCasino {
            get => this.currentIndex_ > this.Casinos.Count || this.currentIndex_ < 0 ? null : this.Casinos[this.currentIndex_];
            set {
                if (!this.Casinos.Contains(value)) return;
                this.currentIndex_ = int.Parse(value.ID);
            }
        }
        //public Log Output = new Log(Settings.Default.OutFile, ";", true);

        public DirectoryInfo WorkingDir;
        public DirectoryInfo DataDir;
        public DirectoryInfo ScreenshotsDir;
        public string ConnectionString;

        public CasinoManager() {
            this.WorkingDir = new DirectoryInfo(Settings.Default.WorkingDir);
            this.DataDir = this.WorkingDir.CreateSubdirectory(Settings.Default.DataDir);
            this.ScreenshotsDir = new DirectoryInfo(Settings.Default.ScreenshotsDir);
            this.ConnectionString = this.WorkingDir.GetFile("\\"+Settings.Default.DBFile).FullName;
        }

        public void CreateList() {
            var init = new List<string>() {
                "bingospirit.com",
                "bingoiceland.com",
                "bingolicious.com",
                "bitcasino.io",
                "bitsler.com",
                "bitstarz.com",
                "blackbet.co.uk",
                "blackdiamondcasino.net",
                "blackjackballroom.co.uk",
                "BlackjackBallroom.eu",
                "blackjackballroom.eu",
                "blacklotuscasino.com",
                "blitzspins.com",
                "boaboa.com",
                "bobcasino.com",
                "bohemiacasino.com",
                "bojoko.com",
                "boombangcasino.com",
                "bosscasino.com",
                "bravowin.com",
                "btcbetonline.com",
                "bubblegumbingo.com",
                "bumbet.com",
                "buzzbingo.com",
                "cadoola.com",
                "calvincasino.com",
                "campobet.com",
                "cannonbet.com",
                "canplaycasino.com",
                "captaincookscasino.eu",
                "casharcade.com",
                "cashmo.co.uk",
                "cashpoint.com",
                "casillion.com",
                "casimba.com",
                "casino-x.com",
                "casino1club.org",
                "casinoblusky.com",
                "casinoclub.com",
                "casinodisco.com",
                "casinoestrella.com",
                "casinoextreme.eu",
                "casinogods.com",
                "casinointense.com",
                "casinoirishluck.com",
                "casinoking.com",
                "casinoland.com",
                "casinolavida.com",
                "casinomga.com",
                "casinomoons.com",
                "casinonapoli.com",
                "casinoroyalclub.com",
                "casinovenetian.info",
                "casiplay.com",
                "casitabi.com",
                "casumo.com",
                "cbet.gg",
                "chanz.com",
                "chatmagbingo.com",
                "cheekyriches.com",
                "chericasino.com",
                "cherrygoldcasino.com",
                "cherrywins.com",
                "circus.be",
                "classyslots.com",
                "clemensspillehal.com",
                "cloudbet.com",
                "club.liveroulette.ie",
                "club3000bingo.com",
                "clubplayercasino.com",
                "cocoacasino.com",
                "coconutslots.com",
                "conquercasino.com",
                "conquestador.com",
                "coolhandpoker.com",
                "cosmocasino.com",
                "cosmoswin.com",
                "crazyluckcasino.com",
                "crazywinners.com",
                "cresuscasino.com",
                "crocobet.com",
                "cyberbingo.com",
                "dafa888.com",
                "dafabet.com",
                "dansk777.dk",
                "dasistcasino.com",
                "daybet365.com",
                "dazzlecasino.com",
                "dbestcasino.com",
                "diamond7casino.com",
                "diamondclubvip.com",
                "diamondreels.com",
                "dinkumpokies.com",
                "divawins.com",
                "domgame.com",
                "dottybingo.com",
                "drakecasino.eu",
                "dreamjackpot.com",
                "dreampalacecasino.com",
                "dreamvegas.com",
            };

            var index = 3;
            for (var i = 0; i < index; i++)
                this.Casinos.Add(null);


            using var db = new LiteDatabase(this.ConnectionString);
            var db_casinos = db.GetCollection<CasinoRecord>("casinos");
            //if (db_casinos.Count() <= 0 || db_casinos.Exists(c => c.Domain == null))
            //db_casinos.DeleteAll();

            if (db_casinos.Count() <= 0)
                foreach (var domain in init) {
                    var db_casino = db_casinos.FindOne(x => x.ID == index.ToString());

                    Casino casino;
                    //if (db_casino != null && db_casino.Domain == domain) {
                    //    casino = Casino.FromCasinoRecord(db_casino);
                    //    AppLogAndEventHelper.Instance.RaiseDebugInfo(db_casino);
                    //    AppLogAndEventHelper.Instance.RaiseDebugInfo(casino);
                    //    //casino.LazyInit(this.WorkingDir);
                    //    this.Casinos.Insert(index, casino);
                    //    continue;
                    //}

                    //db_casino = db_casinos.FindOne(c => c.Domain == domain);
                    //if (db_casino != null) {
                    //    AppLogAndEventHelper.Instance.RaiseError("Wrong index", db_casino);
                    //    continue;
                    //}

                    casino = new Casino(index, domain);
                    this.Casinos.Insert(index, casino);
                    db_casinos.EnsureIndex(x => x.ID, true); // Create unique index in Name field
                    db_casinos.Insert((CasinoRecord) casino);

                    index++;
                }
            else
                foreach (var db_casino in db_casinos.FindAll().OrderBy(x=>int.Parse(x.ID))) {
                    //= db_casinos.FindOne(x => x.ID == index.ToString());

                    var casino = Casino.FromCasinoRecord(db_casino);
                    casino = Casino.FromCasinoRecord(db_casino);
                    AppLogAndEventHelper.Instance.RaiseDebugInfo(db_casino);
                    AppLogAndEventHelper.Instance.RaiseDebugInfo(casino);
                    this.Casinos.Insert(int.Parse(casino.ID), casino);
                }
        }

        public void UpdateCurrentCasino() {
            using var db = new LiteDatabase(this.ConnectionString);
            var db_casinos = db.GetCollection<CasinoRecord>("casinos");
            var b= db_casinos.Update((CasinoRecord) this.CurrentCasino);
            if (!b) AppLogAndEventHelper.Instance.RaiseError($"Can't update {this.CurrentCasino}");
        }

        //public CasinoManager(string filename) {
        //    var fi = new FileInfo(filename);
        //    var text = fi.ReadFile();
        //    var rows = text.Split(new[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);

        //    foreach (var row in rows) {
        //        var ss = row.Split(new[] {' ', ';', '\t'});
        //        var id = int.Parse(ss[0]);

        //        if (id < Settings.Default.StartId) continue;
        //        if (id > 20) break;

        //        var game = new Casino(id);

        //        for (var j = 1; j < 5; j++) {
        //            ss[j] = ss[j] == "NULL" ? "http://google.com" : ss[j];
        //            game.Links.Add(new Casino.LinkWorks(ss[j]));
        //        }

        //        game.Publisher = ss[6];
        //        game.GameName = ss[7];
        //        this.Casinos.Add(game);
        //    }
        //}

        //public Casino NextGame() {
        //    AppLogAndEventHelper.Instance.RaiseInfo(this.CurrentCasino);
        //    //this.Output.Write(this.CurrentCasino);

        //    if (this.Casinos.Count <= this.currentIndex_ + 1) return null;
        //    this.currentIndex_++;
        //    return this.CurrentCasino;
        //}

        //public void Dispose() {
        //    var sb = new StringBuilder();
        //    foreach (var game in this.Casinos) {
        //        sb.AppendLine(game.ToString());
        //    }

        //    sb.ToString().WriteToFile2(new FileInfo(Properties.Settings.Default.OutFile));
        //}
    }

    public class Casino : CasinoRecord {
        private DirectoryInfo di_;

        public Casino() : base() { }
        public Casino(int id, string domain) : base(id, domain) { }

        public void LazyInit(DirectoryInfo workingdir) {
            if (this.di_ == null || !this.di_.Exists) {
                this.di_ = workingdir.CreateSubdirectory($"{this.Domain}\\");
                this.Directory = this.di_.FullName;
            }
        }

        public bool ScreenshotExists(string name) {
            if (!this.Screenshots.ContainsKey(name) || string.IsNullOrWhiteSpace(this.Screenshots[name])) return false;
            return new FileInfo(this.Screenshots[name]).Exists;
        }

        public bool AddScreenshot(string screenshot_type, string path) {
            if (!new FileInfo(path).Exists) return false;
            if (this.Screenshots.ContainsKey(screenshot_type))
                this.Screenshots[screenshot_type] = path;
            else
                this.Screenshots.Add(screenshot_type, path);

            return true;
        }

        public string ScreenshotPath(string screenshot_type) =>
            this.di_.GetFile($"{this.Domain}_{screenshot_type}.png").FullName;

        public static Casino FromCasinoRecord(CasinoRecord cr) =>
            new Casino(int.Parse(cr.ID), cr.Domain) {
                Screenshots = cr.Screenshots,
                Directory = cr.Directory
            };
    }

    public class CasinoRecord {
        public string ID { get; set; }
        public string Domain { get; set; }
        public string Directory { get; set; }
        public Dictionary<string, string> Screenshots { get; set; }

        public CasinoRecord() { }

        public CasinoRecord(int id, string domain) {
            this.ID = id.ToString();
            this.Domain = domain;
            this.Screenshots = new Dictionary<string, string>();
        }

        public override string ToString() =>
            $"{this.ID};{this.Domain};{this.Directory};" +
            $"{this.Screenshots.Count};";
    }
}