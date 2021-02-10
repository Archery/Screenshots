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
            this.DataDir = new DirectoryInfo(Settings.Default.DataDir);
            this.ScreenshotsDir = new DirectoryInfo(Settings.Default.ScreenshotsDir);
            this.ConnectionString = this.WorkingDir.GetFile("\\Data.litedb").FullName;
        }

        public void CreateNewList(string[] init) {
            this.Casinos = new List<Casino>();

            var index = 3;
            for (var i = 0; i < index; i++)
                this.Casinos.Add(null);

            using var db = new LiteDatabase(this.ConnectionString);
            var db_casinos = db.GetCollection<CasinoRecord>("casinos");
            if (db_casinos.Count() > 0)
                db_casinos.DeleteAll();

            foreach (var domain in init) {
                var casino = new Casino(index, domain, this.DataDir.FullName);
                this.Casinos.Insert(index, casino);
                db_casinos.EnsureIndex(x => x.ID, true); // Create unique index in Name field
                db_casinos.Insert((CasinoRecord)casino);

                index++;
            }
        }

        public void DownloadList() {
            this.Casinos = new List<Casino>();

            var index = 3;
            for (var i = 0; i < index; i++)
                this.Casinos.Add(null);

            using var db = new LiteDatabase(this.ConnectionString);
            var db_casinos = db.GetCollection<CasinoRecord>("casinos");
            if (db_casinos.Count() <= 0) return;

            foreach (var db_casino in db_casinos.FindAll().OrderBy(x => int.Parse(x.ID))) {
                var casino = Casino.FromCasinoRecord(db_casino);
                AppLogAndEventHelper.Instance.RaiseDebugInfo(db_casino);
                //AppLogAndEventHelper.Instance.RaiseDebugInfo(casino);
                this.Casinos.Insert(int.Parse(casino.ID), casino);
            }
        }

        public void UpdateCurrentCasino() {
            using var db = new LiteDatabase(this.ConnectionString);
            var db_casinos = db.GetCollection<CasinoRecord>("casinos");
            var b= db_casinos.Update((CasinoRecord) this.CurrentCasino);
            if (!b) AppLogAndEventHelper.Instance.RaiseError($"Can't update {this.CurrentCasino}");
        }
    }
}